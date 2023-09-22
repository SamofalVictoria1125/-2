using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
using static System.Net.Mime.MediaTypeNames;

namespace Курсовая.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductListView2.xaml
    /// </summary>
    public partial class ProductListView2 : Window
    {
        
        private List<Product> products;

        
       
        public ProductListView2()
        {
            InitializeComponent();
  
        }

        private async void MainGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MainGrid.SelectedItem != null)
            {
                Product product = (Product)MainGrid.SelectedItem;//конвертация выбранной строки в тип продукт
                ProductView productView = new ProductView(product, 1);
                if (productView.ShowDialog() == true)
                {
                    await UpdateGrid();
                }
            }

        }


        public async Task UpdateGrid()
        {
           
            IEnumerable<Product> productList = await MyHTTPClient.GetAllProducts();
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


        private async void Window_Initialized(object sender, EventArgs e)
        {
            await UpdateGrid();
        }

        private async void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MainGrid.SelectedItem != null)
            {
                Product product = (Product)MainGrid.SelectedItem;
                System.Net.HttpStatusCode code = await MyHTTPClient.DeleteProduct(product);
                if(code == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Продукт не найден", "Не удалось удалить продукт");
                }
                else if(code == System.Net.HttpStatusCode.Conflict)
                {
                    MessageBox.Show("Есть связи с другими записями", "Не удалось удалить продукт");
                }
                await UpdateGrid();
            }
        }

    }
}
