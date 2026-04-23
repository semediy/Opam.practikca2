using Avalonia.Controls;
using Logistics.Views;

namespace Logistics;

public partial class MainWindow : Window
{
    public static ContentControl MainFrameInstance = null!;

    public MainWindow()
    {
        InitializeComponent();

        MainFrameInstance = MainFrame;

        MainFrame.Content = new StartPage();
    }
}