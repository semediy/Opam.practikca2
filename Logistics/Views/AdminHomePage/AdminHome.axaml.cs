using Avalonia.Controls;
using Avalonia.Interactivity;
using Logistics.Views.DriverHomePage;
using Logistics.Views.LogistHomePage;
using Logistics.Views.UserHomePage;

namespace Logistics.Views.AdminHomePage;

public partial class AdminHome : UserControl
{
    public AdminHome()
    {
        InitializeComponent();
    }
    private void OpenChange(object? sender, RoutedEventArgs e)
    {
        MainContent.IsVisible = false;
        ContentArea.Content = new ChangePage();
    }

    private void OpenUser(object? sender, RoutedEventArgs e)
    {
        MainContent.IsVisible = false;
        ContentArea.Content = new UserHome();
    }

    private void OpenLogist(object? sender, RoutedEventArgs e)
    {
        MainContent.IsVisible = false;
        ContentArea.Content = new LogistHome();
    }

    private void OpenDrivers(object? sender, RoutedEventArgs e)
    {
        MainContent.IsVisible = false;
        ContentArea.Content = new DriverHome();
    }

    private void OpenSettings(object? sender, RoutedEventArgs e)
    {
        MainContent.IsVisible = false;
        ContentArea.Content = new SettingsPage();
    }

    private void GoBack(object? sender, RoutedEventArgs e)
    {
        ContentArea.Content = null;
        MainContent.IsVisible = true;
    }
}