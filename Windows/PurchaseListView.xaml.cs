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
    /// Логика взаимодействия для PurchaseListView.xaml
    /// </summary>
    public partial class PurchaseListView : Window
    {
        private List<Purchase> purchases;
        public PurchaseListView()
        {
            InitializeComponent();
        }

        private async void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MainGrid.SelectedItem != null)
            {
                Purchase purchase = (Purchase)MainGrid.SelectedItem;
                System.Net.HttpStatusCode code = await MyHTTPClient.DeletePurchase(purchase);
                if (code == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Продукт не найден", "Не удалось удалить продукт");
                }
                else if (code == System.Net.HttpStatusCode.Conflict)
                {
                    MessageBox.Show("Есть связи с другими записями", "Не удалось удалить продукт");
                }
                await UpdateGrid();
            }
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {

                Purchase purchase;
                purchase = new Purchase();
                PurchaseView purchaseView = new PurchaseView(purchase, 0);//создание формы
                if (purchaseView.ShowDialog() == true)//запуск формы на показ
                {
                    UpdateGrid();
                }

            
        }

        public async Task UpdateGrid()
        {

            IEnumerable<Purchase> purchaseList = await MyHTTPClient.GetAllPurchases();
            MainGrid.ItemsSource = purchaseList;

        }

        private async void Window_Initialized(object sender, EventArgs e)
        {
            await UpdateGrid();
        }

        private async void MainGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MainGrid.SelectedItem != null)
            {
                Purchase purchase = (Purchase)MainGrid.SelectedItem;//конвертация выбранной строки в тип продукт
                PurchaseView purchaseView = new PurchaseView(purchase, 1);
                if (purchaseView.ShowDialog() == true)
                {
                    await UpdateGrid();
                }
            }
        }
    }
}
