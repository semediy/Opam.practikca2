using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Logistics.Views.AdminHomePage;
using Logistics.Views.DriverHomePage;
using Logistics.Views.LogistHomePage;
using Logistics.Views.UserHomePage;
using Logistics;

namespace Logistics.Views;

public partial class LoginPage : UserControl
{
    private const string FilePath = "users.json";

    public LoginPage()
    {
        InitializeComponent();
    }

    private void LoginClick(object? sender, RoutedEventArgs e)
    {
        ErrorText.IsVisible = false;
        
        string login = LoginBox.Text ?? "";
        string password = PasswordBox.Text ?? "";
        
        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
        {
            ShowError("Введіть логін та пароль");
            return;
        }
        
        var users = LoadUsers();
        var user = users.FirstOrDefault(u => u.login == login);

        if (user == null)
        {
            ShowError("Користувача не знайдено");
            return;
        }

        if (!BCrypt.Net.BCrypt.Verify(password, user.password))
        {
            ShowError("Невірний пароль");
            return;
        }

        NavigateByRole(user.role);
    }

    private void NavigateByRole(string role)
    {
        var content = MainWindow.MainFrameInstance;
        
        if (content == null)
        {
            var tl = TopLevel.GetTopLevel(this);
            if (tl is Window w)
            {
                content = w.FindControl<ContentControl>("MainFrame");
            }
        }

        if (content == null) return;
        
        if (role == "Admin")
            content.Content = new AdminHome();
        else if (role == "User")
            content.Content = new UserHome();
        else if (role == "Logist")
            content.Content = new LogistHome();
        else if (role == "Driver")
            content.Content = new DriverHome();
    }

    private void ShowError(string message)
    {
        ErrorText.Text = message;
        ErrorText.IsVisible = true;
    }

    private List<Users> LoadUsers()
    {
        if (!File.Exists(FilePath))
            return new List<Users>();

        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Users>>(json) ?? new List<Users>();
    }
}