using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace Controls.Uwp.Demo
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ToastPrompt toastPrompt = new ToastPrompt();
            RootGrid.Children.Add(toastPrompt);
            toastPrompt.Background = new SolidColorBrush(Colors.Red);
            toastPrompt.Message = "Hello world";
            toastPrompt.Icon = new SymbolIcon(Symbol.Accept);
            await toastPrompt.ShowAsync();
        }
    }
}