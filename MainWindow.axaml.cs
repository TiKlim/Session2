using Avalonia.Controls;
using Avalonia.Metadata;
using Microsoft.EntityFrameworkCore;
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
        private List<Manufacturer> manufacturers = Helper.DataObj.Manufacturers.ToList();
        public MainWindow()
        {
            InitializeComponent();
            SortBox.SelectionChanged += ComboBox_SelectionChanged;
            FilterBox.SelectionChanged += FilterBox_SelectionChanged;
            SearchBox.TextChanged += SearchBox_TextChanged;
            Add.Click += Add_Click;
            Output.Text = $"{LBProducts.ItemCount}";
            Total.Text = $"{Helper.DataObj.Products.Count()}";
            SetData();
            Manuf();
        }

        private void Add_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
            Close();
        } 

        private void SearchBox_TextChanged(object? sender, TextChangedEventArgs e) => SetData();

        private void SetData()
        {
            LBProducts.ItemsSource = products.ToList();

            string SearchSearch = SearchBox.Text ?? "";
            if (SearchSearch.Length > 0)
            {
                products = products.Where(x => x.ProductName.ToLower().Contains(SearchSearch)).ToList();
            }

            if (FilterBox.SelectedIndex > 0)
            {
                var selectedManufacturer = (Manufacturer)FilterBox.SelectedItem;
                products = products.Where(p => p.Id == selectedManufacturer.Id).ToList();
            }
        }

        private void ComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            // Сортировка по цене
            if (SortBox == null) return;

            var datalist = Helper.DataObj.Products.ToList();

            switch (SortBox.SelectedIndex)
            {
                case 0:
                    products = datalist;
                    break;
                case 1:
                    products = datalist.OrderBy(x => x.Price).ToList();
                    break;
                case 2:
                    products = datalist.OrderByDescending(x => x.Price).ToList();
                    break;
            }

            SetData();
        }

        private void FilterBox_SelectionChanged(object? sender, SelectionChangedEventArgs e) => Manuf();

        public void Manuf()
        {
            List<Manufacturer> man = new List<Manufacturer>();
            man = Helper.DataObj.Manufacturers.ToList();
            man.Add(new Manufacturer() { Manufacturersname = "Princeton Review" });

            FilterBox.ItemsSource = man.OrderByDescending(x => x.Manufacturersname == "Princeton Review").ToList();
            FilterBox.SelectedIndex = 0;
        }
    }
}