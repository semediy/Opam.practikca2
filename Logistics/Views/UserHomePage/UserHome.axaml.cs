using Avalonia.Controls;
using Avalonia.Interactivity;
using Logistics.Views.LogistHomePage;

namespace Logistics.Views.UserHomePage;

public partial class UserHome : UserControl
{
    public UserHome()
    {
        InitializeComponent();
        ShowMain();
    }

    private void ShowMain()
    {
        MainContent.IsVisible = true;
        ContentArea.Content = null;
    }

    private void OpenContact(object? sender, RoutedEventArgs e)
    {
        MainContent.IsVisible = false;
        ContentArea.Content = new Contact();
    }

    private void OpenSettings(object? sender, RoutedEventArgs e)
    {
        MainContent.IsVisible = false;
        ContentArea.Content = new SettingsPage();
    }
    

    private void OpenBack(object? sender, RoutedEventArgs e)
    {
        ShowMain();
    }
}