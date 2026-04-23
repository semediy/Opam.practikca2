using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using BCrypt.Net;

namespace Logistics.Views;

public partial class RegisterPage : UserControl
{
    private const string FilePath = "users.json";

    public RegisterPage()
    {
        InitializeComponent();
    }

    // 📱 Маска телефону
    private void PhoneChanged(object? sender, TextChangedEventArgs e)
    {
        if (PhoneBox.Text == null) return;

        string digits = new string(PhoneBox.Text.Where(char.IsDigit).ToArray());

        if (digits.Length > 12)
            digits = digits.Substring(0, 12);

        string formatted = "+380";

        if (digits.Length > 3)
            formatted += $" ({digits.Substring(3, Math.Min(2, digits.Length - 3))})";

        if (digits.Length > 5)
            formatted += $" {digits.Substring(5, Math.Min(3, digits.Length - 5))}";

        if (digits.Length > 8)
            formatted += $"-{digits.Substring(8, Math.Min(2, digits.Length - 8))}";

        if (digits.Length > 10)
            formatted += $"-{digits.Substring(10, Math.Min(2, digits.Length - 10))}";

        PhoneBox.Text = formatted;
        PhoneBox.CaretIndex = PhoneBox.Text.Length;
    }

    // 🎭 Перемикання ролей
    private void RoleChanged(object? sender, RoutedEventArgs e)
    {
        LogistPanel.IsVisible = Logist.IsChecked == true;
        DriverPanel.IsVisible = Driver.IsChecked == true;
        UserPanel.IsVisible = User.IsChecked == true;
        AdminPanel.IsVisible = Admin.IsChecked == true;
    }

    // 💾 РЕЄСТРАЦІЯ
    private void RegisterClick(object? sender, RoutedEventArgs e)
    {
        string login = LoginBox.Text ?? "";
        string password = PasswordBox.Text ?? "";
        string phone = PhoneBox.Text ?? "";

        string role = "User";
        if (Logist.IsChecked == true) role = "Logist";
        else if (Driver.IsChecked == true) role = "Driver";
        else if (Admin.IsChecked == true) role = "Admin";

        if (string.IsNullOrWhiteSpace(login) ||
            string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(phone))
        {
            ShowInfo("Заповніть всі поля!", true);
            return;
        }

        var users = LoadUsers();

        if (users.Any(u => u.login == login))
        {
            ShowInfo("Користувач вже існує!", true);
            return;
        }

        var newUser = new Users
        {
            login = login,
            password = BCrypt.Net.BCrypt.HashPassword(password),
            role = role,
            phone = phone
        };

        users.Add(newUser);
        SaveUsers(users);

        ShowInfo("Реєстрація успішна!", false);
    }
    // 📂 ЗАВАНТАЖЕННЯ
    private List<Users> LoadUsers()
    {
        if (!File.Exists(FilePath))
            return new List<Users>();

        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Users>>(json) ?? new List<Users>();
    }

    // 💾 ЗБЕРЕЖЕННЯ
    private void SaveUsers(List<Users> users)
    {
        var json = JsonSerializer.Serialize(users, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(FilePath, json);
    }

    // 🪟 Повідомлення
   private async void ShowMessage(string text)
   {
       var window = this.VisualRoot as Window;
   
       if (window == null) return;
   
       var dialog = new Window
       {
           Width = 300,
           Height = 150,
           Title = "Повідомлення",
           Content = new TextBlock
           {
               Text = text,
               HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
               VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
           }
       };
   
       await dialog.ShowDialog(window);
   }
   private void ShowInfo(string text, bool isError)
   {
       InfoText.Text = text;
       InfoText.Foreground = isError ? Avalonia.Media.Brushes.Red : Avalonia.Media.Brushes.Green;
       InfoText.IsVisible = true;
   }
}