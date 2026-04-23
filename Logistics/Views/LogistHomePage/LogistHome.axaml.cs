using Avalonia.Controls;
using Avalonia.Interactivity;
using Logistics.Views.LogistHomePage;

namespace Logistics.Views.LogistHomePage;

public partial class LogistHome : UserControl
{
    public LogistHome()
    {
        InitializeComponent();

    }

    private void OpenTransport(object? sender, RoutedEventArgs e)
    {
        MainContent.IsVisible = false;
        ContentArea.Content = new TransportationsPage();
    }

    private void OpenDrivers(object? sender, RoutedEventArgs e)
    {
        MainContent.IsVisible = false;
        ContentArea.Content = new DriversPage();
    }

    private void OpenRoutes(object? sender, RoutedEventArgs e)
    {
        MainContent.IsVisible = false;
        ContentArea.Content = new RoutesPage();
    }

    private void OpenVehicles(object? sender, RoutedEventArgs e)
    {
        MainContent.IsVisible = false;
        ContentArea.Content = new VehiclesPage();
    }

    private void OpenCalendar(object? sender, RoutedEventArgs e)
    {
        MainContent.IsVisible = false;
        ContentArea.Content = new CalendarPage();
    }

    private void OpenSettings(object? sender, RoutedEventArgs e)
    {
        MainContent.IsVisible = false;
        ContentArea.Content = new SettingsPage();
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
}