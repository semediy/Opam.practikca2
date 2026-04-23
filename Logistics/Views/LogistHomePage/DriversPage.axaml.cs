using Avalonia.Controls;
using System.Collections.ObjectModel;
using Logistics.Views;

namespace Logistics.Views.LogistHomePage;

public partial class DriversPage : UserControl
{
    public ObservableCollection<StatusRowModel> Drivers { get; set; }

    public DriversPage()
    {
        InitializeComponent();

        Drivers = new ObservableCollection<StatusRowModel>
        {
            new StatusRowModel { Col1 = "Іваненко Іван", Group = "d1" },
            new StatusRowModel { Col1 = "Петренко Олег", Group = "d2" }
        };

        DataContext = this;
    }
}