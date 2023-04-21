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
    /// Логика взаимодействия для CounterpartyListView.xaml
    /// </summary>
    public partial class CounterpartyListView : Window
    {
        private List<Counterparty> counterparties;



        public CounterpartyListView()
        {
            InitializeComponent();
            UpdateGrid();

        }

        private async void MainGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MainGrid.SelectedItem != null)
            {
                Counterparty counterparty = (Counterparty)MainGrid.SelectedItem;
                CounterpartyView counterpartyView = new CounterpartyView(counterparty, 1);
                if (counterpartyView.ShowDialog() == true)
                {
                    await UpdateGrid();
                }
            }

        }


        public async Task UpdateGrid()
        {

            IEnumerable<Counterparty> counterpartyList = await MyHTTPClient.GetAllCounterparties();
            MainGrid.ItemsSource = counterpartyList;

        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            Counterparty counterparty;
            counterparty = new Counterparty();
            CounterpartyView counterpartyView = new CounterpartyView(counterparty, 0);//создание формы
            if (counterpartyView.ShowDialog() == true)//запуск формы на показ
            {
                UpdateGrid();
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
