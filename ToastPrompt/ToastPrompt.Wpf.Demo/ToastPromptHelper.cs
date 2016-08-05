using FontAwesome.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Controls.Wpf.Demo
{
    public class ToastPromptHelper
    {
        public static async Task ShowWarningAsync(string message)
        {
            ToastPrompt toastPrompt = new ToastPrompt();
            toastPrompt.Background = new SolidColorBrush(Color.FromRgb(255, 193, 0));
            toastPrompt.Message = message;
            toastPrompt.Icon = FontAwesomeIcon.Warning;

            var main = Application.Current.MainWindow as MainWindow;
            main.RootGrid.Children.Add(toastPrompt);

            await toastPrompt.ShowAsync();

            main.RootGrid.Children.Remove(toastPrompt);
        }

        public static async Task ShowInformationAsync(string message)
        {
            ToastPrompt toastPrompt = new ToastPrompt();
            toastPrompt.Background = new SolidColorBrush(Color.FromRgb(0, 156, 243));
            toastPrompt.Message = message;
            toastPrompt.Icon = FontAwesomeIcon.InfoCircle;

            var main = Application.Current.MainWindow as MainWindow;
            main.RootGrid.Children.Add(toastPrompt);

            await toastPrompt.ShowAsync();

            main.RootGrid.Children.Remove(toastPrompt);
        }

        public static async Task ShowErrorAsync(string message)
        {
            ToastPrompt toastPrompt = new ToastPrompt();
            toastPrompt.Background = new SolidColorBrush(Color.FromRgb(234, 23, 32));
            toastPrompt.Message = message;
            toastPrompt.Icon = FontAwesomeIcon.Close;

            var main = Application.Current.MainWindow as MainWindow;
            main.RootGrid.Children.Add(toastPrompt);

            await toastPrompt.ShowAsync();

            main.RootGrid.Children.Remove(toastPrompt);
        }

        public static async Task ShowMessageAsync(string message)
        {
            ToastPrompt toastPrompt = new ToastPrompt();
            toastPrompt.Background = new SolidColorBrush(Color.FromRgb(19, 192, 77));
            toastPrompt.Message = message;
            toastPrompt.Icon = FontAwesomeIcon.Check;

            var main = Application.Current.MainWindow as MainWindow;
            main.RootGrid.Children.Add(toastPrompt);

            await toastPrompt.ShowAsync();

            main.RootGrid.Children.Remove(toastPrompt);
        }
    }
}