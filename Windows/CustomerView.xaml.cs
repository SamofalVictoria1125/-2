using Microsoft.VisualBasic;
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
    /// Логика взаимодействия для CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Window
    {
        int OpenMode;
        public Customer model;

        public CustomerView(Customer model, int openMode)
        {
            this.model = model;
            InitializeComponent();
            textBoxID.Text = this.model.Id.ToString();

            OpenMode = openMode;
            if (openMode == 0)
            {
                textBoxID.Visibility = Visibility.Hidden;
                label_ID.Visibility = Visibility.Hidden;
            }
        }

        private async void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (OpenMode == 0)
            {
                await MyHTTPClient.CreateCustomer(model);

            }
            else
            {
                await MyHTTPClient.UpdateCustomer(model);
            }
            DialogResult = true;
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonSelectCounterparty_Click(object sender, RoutedEventArgs e)
        {
            CounterpartyListView counterpartyList = new CounterpartyListView("Выбор");
            if (counterpartyList.ShowDialog() == true)
            {

                if (counterpartyList.MainGrid.SelectedItem != null)
                {
                    Counterparty counterparty = (Counterparty)counterpartyList.MainGrid.SelectedItem;
                    model.Idpartner = counterparty.Id;
                    UpdateCounterparty();

                }
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {

            UpdateCounterparty();
        }

        private async void UpdateCounterparty()
        {
            Counterparty counterparty = await this.model.counterparty;
            textBoxCounterparty.Text = counterparty.NameOrganization;
        }
    }
}
