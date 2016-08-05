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

        private async void ErrorClick(object sender, RoutedEventArgs e)
        {
            await ToastPromptHelper.ShowErrorAsync("error");
        }

        private async void MessageClick(object sender, RoutedEventArgs e)
        {
            await ToastPromptHelper.ShowMessageAsync("message");
        }

        private async void InfoClick(object sender, RoutedEventArgs e)
        {
            await ToastPromptHelper.ShowInformationAsync("info");
        }

        private async void WarningClick(object sender, RoutedEventArgs e)
        {
            await ToastPromptHelper.ShowWarningAsync("warning");
        }
    }
}