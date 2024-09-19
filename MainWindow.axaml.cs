using Avalonia.Controls;
using Session4.Context;
using Session4.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Session4
{
    public partial class MainWindow : Window
    {
        private List<Product> products = Helper.DataObj.Products.ToList();
        public MainWindow()
        {
            InitializeComponent();
            SetData();
        }
        private void SetData()
        {
            LBProducts.ItemsSource = products;

            var datalist = products.ToList();

            string search = SearchBox.Text != null ? SearchBox.Text : "";
            if (!string.IsNullOrEmpty(search))
                datalist = datalist.Where(x => x.ProductName.Contains(search)).ToList();

            datalist = SortBox.SelectedIndex switch
            {
                1 => datalist.OrderBy(x => x.Price).ToList(),
                2 => datalist.OrderByDescending(x => x.Price).ToList(),
                _ => datalist
            };
        }
    }
}