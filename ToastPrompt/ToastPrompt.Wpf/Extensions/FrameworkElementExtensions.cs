using System;
using System.Threading.Tasks;
using System.Windows;

namespace Controls.Extensions
{
    public static class FrameworkElementExtensions
    {
        public static async Task WaitForLoadedAsync(this FrameworkElement frameworkElement)
        {
            if (frameworkElement == null)
            {
                throw new ArgumentNullException(nameof(frameworkElement));
            }

            if (frameworkElement.IsLoaded)
            {
                return;
            }
            if (frameworkElement.IsInVisualTree())
            {
                return;
            }

            var tcs = new TaskCompletionSource<object>();
            RoutedEventHandler handler = null;
            handler = (sender, e) =>
            {
                frameworkElement.Loaded -= handler;
                tcs.SetResult(null);
            };
            frameworkElement.Loaded += handler;
            await tcs.Task;
        }

        public static async Task WaitForNonZeroSizeAsync(this FrameworkElement frameworkElement)
        {
            if (frameworkElement == null)
            {
                throw new ArgumentNullException(nameof(frameworkElement));
            }

            while (frameworkElement.ActualWidth <= 0 && frameworkElement.ActualHeight <= 0)
            {
                var tcs = new TaskCompletionSource<object>();
                SizeChangedEventHandler handler = null;
                handler = (sender, e) =>
                {
                    frameworkElement.SizeChanged -= handler;
                    tcs.SetResult(null);
                };
                frameworkElement.SizeChanged += handler;
                await tcs.Task;
            }
        }
    }
}