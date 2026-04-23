using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Logistics.Views.AdminHomePage;

public partial class ChangePage : UserControl
{
    public ChangePage()
    {
        InitializeComponent();
        DriversList.Items.Add("Водій 1");
        DriversList.Items.Add("Водій 2");

        LogistsList.Items.Add("Логіст 1");
        LogistsList.Items.Add("Логіст 2");
    }
    private void AddDriver(object? sender, RoutedEventArgs e)
    {
        DriversList.Items.Add("Новий водій");
    }

    private void RemoveDriver(object? sender, RoutedEventArgs e)
    {
        if (DriversList.SelectedItem != null)
            DriversList.Items.Remove(DriversList.SelectedItem);
    }

    private void AddLogist(object? sender, RoutedEventArgs e)
    {
        LogistsList.Items.Add("Новий логіст");
    }

    private void RemoveLogist(object? sender, RoutedEventArgs e)
    {
        if (LogistsList.SelectedItem != null)
            LogistsList.Items.Remove(LogistsList.SelectedItem);
    }
}