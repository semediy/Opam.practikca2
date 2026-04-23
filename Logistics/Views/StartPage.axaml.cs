using Avalonia.Controls;
using Avalonia.Interactivity;
using Logistics;
using Logistics;
using Logistics.Views;

namespace Logistics.Views;

public partial class StartPage : UserControl
{
    public StartPage()
    {
        InitializeComponent();
    }

    private void OpenLogin(object? sender, RoutedEventArgs e)
    {
        MainWindow.MainFrameInstance.Content = new LoginPage();
    }

    private void OpenRegister(object? sender, RoutedEventArgs e)
    {
        MainWindow.MainFrameInstance.Content = new RegisterPage();
    }
}