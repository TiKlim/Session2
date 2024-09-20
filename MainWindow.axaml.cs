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
            SearchBox.SelectedText += TextBox_SelectionChanged;
            Output.Text = $"{LBProducts.ItemCount}";
            Total.Text = $"{Helper.DataObj.Products.Count()}";
            SetData();
        }

        private void SetData()
        {
            LBProducts.ItemsSource = products; 
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

        private void FilterBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        { 
            // Сортировка по производителям
            if (FilterBox == null) return;

            var datalist = Helper.DataObj.Products.ToList();

            switch (FilterBox.SelectedIndex)
            {
                case 0:
                    products = datalist;
                    break;
                case 1:
                    products = datalist.Where(x => x.Manufacturer == ((Manufacturer)FilterBox.SelectedItem!).Id).ToList();
                    FilterBox.SelectedItem = products;
                    break;
            }

            SetData();
        }

        private void TextBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            // Поиск по названию товара
            //if (SearchBox == null) return;

            //var datalist = Helper.DataObj.Products.ToList();

            //string search = SearchBox.Text != null ? SearchBox.Text : "";

            

            /*if (!string.IsNullOrEmpty(SearchBox.Text))
            {
                string[] searchText = SearchBox.Text.ToLower().Split(" ");

                //products = datalist.Where(x => x.ProductName!.Contains(SearchBox.Text)).ToList();
                //string[] findText = datalist.Where(x => x.ProductName.ToLower());
            }*/

            //SetData();
        }
    }
}