using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using BCrypt.Net;

namespace Logistics;

class Program
{
    
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
#if DEBUG
            // .WithDeveloperTools()
#endif
            .WithInterFont()
            .LogToTrace();

    /*List<users> users = LoadData<users> (Users)??createDefaultUsers();
        while (currentUsers == null)
    {
        Console.WriteLine("Вхід в систему: ");
        Console.WriteLine("Логін: ");
        string login = Console.ReadLine();
        Console.WriteLine("Пароль: ");
        string pasword = Console.ReadLine();
        var user = users.FirstOrDefault(u => u.login == login);
        if (user != null && BCrypt.Net.BCrypt.Verify(pasword, user.password))
        {
            currentUsers = user;
            Console.WriteLine($"Вхід виконано:, {currentUsers.role}");
        }
        else
        {
            Console.WriteLine("Невірний логін або пароль");
        }
        static List<users> createDefaultUsers() => new List<users>
        {
            new users { login = "admin", role = "Admin", password = BCrypt.Net.BCrypt.HashPassword("admin123") }
        };
    }*/
}