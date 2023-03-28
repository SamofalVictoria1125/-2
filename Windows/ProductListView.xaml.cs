﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Курсовая.Controllers;
using Курсовая.Models;


namespace Курсовая.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductListView.xaml
    /// </summary>
    public partial class ProductListView : Window, INotifyPropertyChanged
    {
        private List<Product> products;

        public event PropertyChangedEventHandler? PropertyChanged;

        void Signal([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public List<Product> Products { 
            get => products;
            set
            {
                products = value;
                Signal();
            }
        }
        public ProductListView()
        {
            InitializeComponent();
            Task.Run(async () => await UpdateGrid());
            DataContext = this;
        }

        private async void MainGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MainGrid.SelectedItem != null)
            {
                Product product = (Product)MainGrid.SelectedItem;
                ProductView productView = new ProductView(product, 1);
                if (productView.ShowDialog() == true)
                {
                    await UpdateGrid();
                }
            }

        }


        public async Task UpdateGrid()
        {
            //IEnumerable<Product> productList = await MyHTTPClient.GetAllProducts();
            IEnumerable<Product> productList = await MyHTTPClient.GetAllProducts();
            Products = new List<Product>(productList);
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            Product product;
            product = new Product();
            ProductView productView = new ProductView(product, 0);//создание формы
            if (productView.ShowDialog() == true)//запуск формы на показ
            {
                UpdateGrid();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
