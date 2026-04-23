using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Avalonia.Interactivity;
using System;
using System.Linq;
using Avalonia.Markup.Xaml.Styling; 

namespace Logistics.Views.LogistHomePage;

public partial class SettingsPage : UserControl
{
    public SettingsPage()
    {
        InitializeComponent();
    }
     private void DarkClick(object? sender, RoutedEventArgs e) 
     {
         if(Application.Current != null) 
         {
                Application.Current.RequestedThemeVariant = ThemeVariant.Dark;
            
         }
     }
     private void LightClick(object? sender, RoutedEventArgs e)
     {
         if(Application.Current != null)
         { 
             Application.Current.RequestedThemeVariant = ThemeVariant.Light;   
         }
     }
     private void LangUA_Checked(object? sender, RoutedEventArgs e)
     {
         SetLanguage("ua");
     }

     private void LangEN_Checked(object? sender, RoutedEventArgs e)
     {
         SetLanguage("en");
     }

     private void SetLanguage(string lang)
     {
         var app = Application.Current;
         if (app == null) return;

         var merged = app.Resources.MergedDictionaries;

         var old = merged
             .OfType<ResourceInclude>()
             .FirstOrDefault(x => x.Source?.ToString()?.Contains("Lang.") == true);

         if (old != null)
             merged.Remove(old);

         var uri = new Uri($"avares://Logistics/Resources/Lang.{lang}.axaml");
         merged.Add(new ResourceInclude(uri) { Source = uri });
     }
}