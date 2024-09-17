using Avalonia.Controls;
using Session4.Context;
using System.Linq;

namespace Session4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void SetData()
        {
            LBProducts.ItemsSource = Helper.DataObj.OrderBy(x => x.Id);
        }
    }
}