using Avalonia.Controls;
using Avalonia.Interactivity;
using Logistics.Views.LogistHomePage;

namespace Logistics.Views.DriverHomePage;

public partial class DriverHome : UserControl
{
    public DriverHome()
    {
        InitializeComponent();
    }

    private void OpenCalendar(object? sender, RoutedEventArgs e)
    {
        MainContent.IsVisible = false;
        ContentArea.Content = new CalendarPage();
    }

    private void OpenRoutes(object? sender, RoutedEventArgs e)
    {
        MainContent.IsVisible = false;
        ContentArea.Content = new RoutesPage();
    }

    private void OpenContact(object? sender, RoutedEventArgs e)
    {
        MainContent.IsVisible = false;
        ContentArea.Content = new Contact();
    }

    private void GoBack(object? sender, RoutedEventArgs e)
    {
        ContentArea.Content = null;
        MainContent.IsVisible = true;
    }
    private void OpenSettings(object? sender, RoutedEventArgs e)
    {
        MainContent.IsVisible = false;
        ContentArea.Content = new SettingsPage();
    }
}