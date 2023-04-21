using Microsoft.VisualBasic;
using System;
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
    /// Логика взаимодействия для CounterpartyView.xaml
    /// </summary>
    public partial class CounterpartyView : Window, INotifyPropertyChanged
    {
        public List<ContactPerson> ContactPersonList { get; set; }
        public ContactPerson Selected { get; set; }
        ContactPerson contactPerson;
        int OpenMode;
        Counterparty model;

        public event PropertyChangedEventHandler? PropertyChanged;
        void  Signal([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        
        public CounterpartyView(Counterparty model, int openMode)
        {
            InitializeComponent();
            this.model = model;
            DataContext = this;
            textBoxID.Text = this.model.Id.ToString();
            textBoxNameOrganization.Text = this.model.NameOrganization;
            textBoxAddress.Text = this.model.Address;
            
            Task.Run(async() =>
            {
                ContactPersonList = new List<ContactPerson>(await MyHTTPClient.GetAllContactPersons());
                Selected = ContactPersonList.FirstOrDefault(s => s.Id == model.IdContactPerson);
                Signal(nameof(ContactPersonList));
                Signal(nameof(Selected));
            });
            OpenMode = openMode;
            if (openMode == 0)
            {
                textBoxID.Visibility = Visibility.Hidden;
                label_ID.Visibility = Visibility.Hidden;
            }
        }



        private async void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxCP.SelectedIndex == -1)
                return;
            model.IdContactPerson = ((ContactPerson)comboBoxCP.SelectedItem).Id;
            model.NameOrganization = textBoxNameOrganization.Text;
            model.Address = textBoxAddress.Text;
            if (OpenMode == 0)
            {
                await MyHTTPClient.CreateCounterparty(model);

            }
            else
            {
                await MyHTTPClient.UpdateCounterparty(model);
            }
            DialogResult = true;

        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
