using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Logistics.Views.LogistHomePage;

public partial class CalendarPage : UserControl, INotifyPropertyChanged
{
    private DateTimeOffset? _selectedDate;
    private TimeSpan? _selectedTime;
    private string _route = "";
    private string _driver = "";
    private string _note = "";

    public DateTimeOffset? SelectedDate
    {
        get => _selectedDate;
        set { _selectedDate = value; OnPropertyChanged(); }
    }

    public TimeSpan? SelectedTime
    {
        get => _selectedTime;
        set { _selectedTime = value; OnPropertyChanged(); }
    }

    public string Route
    {
        get => _route;
        set { _route = value; OnPropertyChanged(); }
    }

    public string Driver
    {
        get => _driver;
        set { _driver = value; OnPropertyChanged(); }
    }

    public string Note
    {
        get => _note;
        set { _note = value; OnPropertyChanged(); }
    }

    public CalendarPage()
    {
        InitializeComponent();
        DataContext = this;
    }

    private void DatePicker_SelectedDateChanged(object? sender,
        DatePickerSelectedValueChangedEventArgs e)
    {
        if (e.NewDate is DateTimeOffset dto)
        {
            if (dto.DayOfWeek == DayOfWeek.Saturday ||
                dto.DayOfWeek == DayOfWeek.Sunday)
            {
                if (sender is DatePicker dp)
                    dp.SelectedDate = e.OldDate;

                StatusText.Text = "Вихідні недоступні!";
            }
            else
            {
                StatusText.Text = "";
            }
        }
    }

    private void SaveTransport(object? sender, RoutedEventArgs e)
    {
        StatusText.Text = "Збережено ✅";
    }

    public new event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}