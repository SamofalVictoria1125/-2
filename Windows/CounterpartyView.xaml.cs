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
using System.Windows.Controls.Primitives;
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
    public partial class CounterpartyView : Window
    {
            //public List<ContactPerson> ContactPersonList { get; set; }
            /*public ContactPerson Selected { get; set; }
            ContactPerson contactPerson;*/
        int OpenMode;
        public Counterparty model;


        /*public event PropertyChangedEventHandler? PropertyChanged;
         void  Signal([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));*/


        public  CounterpartyView(Counterparty model, int openMode)
        {
            

            this.model = model;
            InitializeComponent();
            //DataContext = this;
            textBoxID.Text = this.model.Id.ToString();
            textBoxNameOrganization.Text = this.model.NameOrganization;
            textBoxAddress.Text = this.model.Address;
            //this.model.contactPerson.

            /*Task.Run(async() =>
            {
                ContactPersonList = new List<ContactPerson>(await MyHTTPClient.GetAllContactPersons());
                Selected = ContactPersonList.FirstOrDefault(name => name.FirstName == model.contactPerson);
                Signal(nameof(ContactPersonList));
                Signal(nameof(Selected));
            });*/

            OpenMode = openMode;
            if (openMode == 0)
            {
                textBoxID.Visibility = Visibility.Hidden;
                label_ID.Visibility = Visibility.Hidden;
            }
        }

        

        private async void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            /*if (comboBoxCP.SelectedIndex == -1)
                return;
            model.IdContactPerson = ((ContactPerson)comboBoxCP.SelectedItem).Id;*/
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

        private void buttonSelectContactPerson_Click(object sender, RoutedEventArgs e)
        {
            ContactPersonListView contactPersonList = new ContactPersonListView("Выбор");
            if(contactPersonList.ShowDialog() == true)
            {
                
                if (contactPersonList.MainGrid.SelectedItem != null)
                {
                    ContactPerson contactPerson = (ContactPerson)contactPersonList.MainGrid.SelectedItem;
                    model.ContactPersonId = contactPerson.Id;
                    UpdateContactPersonName();
                    
                }
            }
            
        }

        private void Window_Initialized(object sender, EventArgs e)
        {

           UpdateContactPersonName();
        }

        private async void UpdateContactPersonName()
        {
            
            ContactPerson contactPerson = this.model.ContactPerson;
            if (contactPerson != null)
            {
                textBoxContactPerson.Text = contactPerson.LastName + " " + contactPerson.FirstName.Substring(0, 1) + "." + " " + contactPerson.Patronymic.Substring(0, 1) + ".";
            }
            
        }
    }
}
