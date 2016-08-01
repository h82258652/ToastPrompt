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
        public static async Task ShowErrorAsync(string message)
        {
            ToastPrompt toastPrompt = new ToastPrompt();
            toastPrompt.Background = new SolidColorBrush(Color.FromRgb(232, 17, 35));
            toastPrompt.Background = new SolidColorBrush(Color.FromRgb(206, 61, 58));
            toastPrompt.Background = new SolidColorBrush(Color.FromRgb(230, 0, 51));
            toastPrompt.Background = new SolidColorBrush(Color.FromRgb(255, 64, 64));
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
            toastPrompt.Background = new SolidColorBrush(Color.FromRgb(0, 120, 215));
            toastPrompt.Background = new SolidColorBrush(Color.FromRgb(00, 149, 217));
            toastPrompt.Background = new SolidColorBrush(Color.FromRgb(00, 128, 255));
            toastPrompt.Message = message;
            toastPrompt.Icon = FontAwesomeIcon.Check;

            var main = Application.Current.MainWindow as MainWindow;
            main.RootGrid.Children.Add(toastPrompt);

            await toastPrompt.ShowAsync();

            main.RootGrid.Children.Remove(toastPrompt);
        }
    }
}