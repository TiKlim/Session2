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
            SetData();
        }
        public void SetData()
        {
            LBProducts.ItemsSource = Helper.DataObj.Products;
        }
    }
}