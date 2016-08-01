using Controls.Extensions;
using FontAwesome.WPF;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Controls
{
    [TemplatePart(Name = ContainerTemplateName, Type = typeof(ContentControl))]
    public class ToastPrompt : Control
    {
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof(Icon), typeof(FontAwesomeIcon), typeof(ToastPrompt), new PropertyMetadata(default(FontAwesomeIcon)));

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(nameof(Message), typeof(string), typeof(ToastPrompt), new PropertyMetadata(default(string)));

        private const string ContainerTemplateName = "PART_Container";

        public BindableMargin _containerMargin;

        static ToastPrompt()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToastPrompt), new FrameworkPropertyMetadata(typeof(ToastPrompt)));
        }

        public FontAwesomeIcon Icon
        {
            get
            {
                return (FontAwesomeIcon)GetValue(IconProperty);
            }
            set
            {
                SetValue(IconProperty, value);
            }
        }

        public string Message
        {
            get
            {
                return (string)GetValue(MessageProperty);
            }
            set
            {
                SetValue(MessageProperty, value);
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var container = (FrameworkElement)GetTemplateChild(ContainerTemplateName);
            _containerMargin = new BindableMargin(container);
        }

        public async Task ShowAsync(double seconds = 2)
        {
            await this.WaitForNonZeroSizeAsync();

            var width = ActualWidth;

            var storyboard = new Storyboard();
            {
                var animation = new DoubleAnimationUsingKeyFrames();
                animation.KeyFrames.Add(new LinearDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0),
                    Value = 0
                });
                animation.KeyFrames.Add(new LinearDoubleKeyFrame
                {
                    KeyTime = TimeSpan.FromSeconds(0.5),
                    Value = 1
                });
                animation.KeyFrames.Add(new LinearDoubleKeyFrame
                {
                    KeyTime = TimeSpan.FromSeconds(seconds + 0.5),
                    Value = 1
                });
                animation.KeyFrames.Add(new LinearDoubleKeyFrame
                {
                    KeyTime = TimeSpan.FromSeconds(seconds + 1),
                    Value = 0
                });
                Storyboard.SetTarget(animation, this);
                Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimationUsingKeyFrames();
                animation.KeyFrames.Add(new DiscreteDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0),
                    Value = 0 - width
                });
                animation.KeyFrames.Add(new EasingDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0.5),
                    Value = 0,
                    EasingFunction = new BackEase()
                    {
                        EasingMode = EasingMode.EaseOut
                    }
                });
                animation.KeyFrames.Add(new DiscreteDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(seconds + 0.5),
                    Value = 0
                });
                animation.KeyFrames.Add(new EasingDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(seconds + 1),
                    Value = 0 - width,
                    EasingFunction = new BackEase()
                    {
                        EasingMode = EasingMode.EaseIn
                    }
                });
                animation.KeyFrames.Add(new DiscreteDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(seconds + 1),
                    Value = 0
                });
                Storyboard.SetTarget(animation, _containerMargin);
                Storyboard.SetTargetProperty(animation, new PropertyPath("Right"));
                storyboard.Children.Add(animation);
            }
            await storyboard.BeginAsync();
        }
    }
}