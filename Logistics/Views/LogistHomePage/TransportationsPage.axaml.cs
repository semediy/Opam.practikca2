using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Logistics.Views.LogistHomePage;


public partial class TransportationsPage : UserControl
{
    public ObservableCollection<StatusRowModel> Transportations { get; set; }

    public TransportationsPage()
    {
        InitializeComponent();

        Transportations = new ObservableCollection<StatusRowModel>
        {
            new StatusRowModel
            {
                Col1 = "Київ → Львів",
                Col2 = "Електроніка",
                Col3 = "25.04.2026",
                Col4 = "Іваненко",
                Group = "t1"
            },
            new StatusRowModel
            {
                Col1 = "Одеса → Харків",
                Col2 = "Продукти",
                Col3 = "26.04.2026",
                Col4 = "Петренко",
                Group = "t2"
            }
        };

        DataContext = this;
    }
}