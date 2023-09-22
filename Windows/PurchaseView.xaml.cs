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
    /// Логика взаимодействия для PurchaseView.xaml
    /// </summary>
    public partial class PurchaseView : Window
    {

        int OpenMode;
        Purchase model;


        public PurchaseView(Purchase model, int openMode)
        {
            InitializeComponent();
            this.model = model;
            textBoxID.Text = this.model.Id.ToString();
            BoxDate.DisplayDate = this.model.DateCalculation;
            OpenMode = openMode;
            if (openMode == 0)
            {
                textBoxID.Visibility = Visibility.Hidden;
                label_ID.Visibility = Visibility.Hidden;
            }


        }

        public async Task UpdateGrid()
        {

            IEnumerable<PurchaseComposition> purchaseCompositionList = await MyHTTPClient.GetPurchasesCompositionsByPurchaseId(model.Id);
            DataGridPurchaseComposition.ItemsSource = purchaseCompositionList;

        }

        private async void Window_Initialized(object sender, EventArgs e)
        {
            await UpdateGrid();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private async void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            this.model.DateCalculation = BoxDate.DisplayDate;
            if (OpenMode == 0)
            {
                await MyHTTPClient.CreatePurchase(model);

            }
            else
            {
                await MyHTTPClient.UpdatePurchase(model);
            }
            DialogResult = true;
        }
    }
}
