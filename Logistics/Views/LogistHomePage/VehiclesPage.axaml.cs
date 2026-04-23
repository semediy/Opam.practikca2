using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Logistics.Views.LogistHomePage;
public partial class VehiclesPage : UserControl
 {
     public ObservableCollection<StatusRowModel> Vehicles { get; set; }
 
     public VehiclesPage()
     {
         InitializeComponent();
 
         Vehicles = new ObservableCollection<StatusRowModel>
         {
             new StatusRowModel
             {
                 Col1 = "AA1234BB",
                 Col2 = "Volvo FH",
                 Col3 = "20000 кг",
                 Col4 = "Зайняте",
                 Group = "v1"
             },
             new StatusRowModel
             {
                 Col1 = "BC5678AA",
                 Col2 = "MAN TGX",
                 Col3 = "18000 кг",
                 Col4 = "Вільне",
                 Group = "v2"
             }
         };
 
         DataContext = this;
     }
 }