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
    /// Логика взаимодействия для CurrenciesListView.xaml
    /// </summary>
    public partial class CurrenciesListView : Window
    {
        private List<Currency> currencies;
        public CurrenciesListView()
        {
            InitializeComponent();
        }

        public async Task UpdateGrid()
        {
            IEnumerable<Currency> list = await MyHTTPClient.GetAllCurrencies();
            MainGrid.ItemsSource = list;

        }

        private async void MainGrid_Initialized(object sender, EventArgs e)
        {
            await UpdateGrid();
        }
    }
}
