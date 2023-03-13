using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class ProductListView : Window
    {
        public ProductListView()
        {
            InitializeComponent();
            UpdateGrid();

        }

        private void MainGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MainGrid.SelectedItem != null)
            {
                Product product = (Product)MainGrid.SelectedItem;
                ProductView productView = new ProductView(product, 1);
                if (productView.ShowDialog() == true)
                {
                    UpdateGrid();
                }
            }

        }


        public async Task UpdateGrid()
        {
            //IEnumerable<Product> productList = await MyHTTPClient.GetAllProducts();
            IEnumerable<Product> productList = MyHTTPClient.GetAllProducts().Result;
            MainGrid.ItemsSource = productList;
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
