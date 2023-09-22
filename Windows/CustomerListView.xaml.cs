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
    /// Логика взаимодействия для CustomerListView.xaml
    /// </summary>
    public partial class CustomerListView : Window
    {
        private List<Customer> customers;

        public CustomerListView()
        {
            InitializeComponent();
            UpdateGrid();
        }

        public async Task UpdateGrid()
        {

            IEnumerable<Customer> customerList = await MyHTTPClient.GetAllCustomers();
            MainGrid.ItemsSource = customerList;

        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            Customer customer;
            customer = new Customer();
            CustomerView customerView = new CustomerView(customer, 0);//создание формы
            if (customerView.ShowDialog() == true)//запуск формы на показ
            {
                UpdateGrid();
            }
        }

        private async void MainGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MainGrid.SelectedItem != null)
            {
                Customer customer = (Customer)MainGrid.SelectedItem;
                CustomerView customerView = new CustomerView(customer, 1);
                if (customerView.ShowDialog() == true)
                {
                    await UpdateGrid();
                }
            }

        }
    }
}
