using FontAwesome.WPF;
using System.Windows;
using System.Windows.Media;

namespace Controls.Wpf.Demo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            await ToastPromptHelper.ShowErrorAsync("Hello world");

            //ToastPrompt toastPrompt = new ToastPrompt();
            //RootGrid.Children.Add(toastPrompt);
            //toastPrompt.Background = new SolidColorBrush(Colors.Red);
            //toastPrompt.Message = "Hello world";
            //toastPrompt.Icon = FontAwesomeIcon.Check;
            //await toastPrompt.ShowAsync();
        }
    }
}