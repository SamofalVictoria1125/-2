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
using Курсовая.Models;

namespace Курсовая.Windows
{
    /// <summary>
    /// Логика взаимодействия для ContactPersonListView.xaml
    /// </summary>
    public partial class ContactPersonListView : Window
    {
        public ContactPersonListView()
        {
            InitializeComponent();
            UpdateGrid();
        }

        private void MainGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MainGrid.SelectedItem != null)
            {
                ContactPerson contactPerson = (ContactPerson)MainGrid.SelectedItem;
                ContactPersonView contactPersonView = new ContactPersonView(contactPerson, 1);
                if (contactPersonView.ShowDialog() == true)
                {
                    UpdateGrid();
                }
            }

        }


        public void UpdateGrid()
        {
            /*List<ContactPerson> contactPersonList = DBModel.SelectAllProducts();
            MainGrid.ItemsSource = contactPersonList;*/
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            ContactPerson contactPerson;
            contactPerson = new ContactPerson();
            ContactPersonView contactPersonView = new ContactPersonView(contactPerson, 0);//создание формы
            if (contactPersonView.ShowDialog() == true)//запуск формы на показ
            {
                UpdateGrid();
            }

        }
    }
}
