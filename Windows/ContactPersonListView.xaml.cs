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
    /// Логика взаимодействия для ContactPersonListView.xaml
    /// </summary>
    public partial class ContactPersonListView : Window
    {
        public IEnumerable<ContactPerson> contactPersonList;

        public ContactPersonListView(string openMode)
        {
            InitializeComponent();
            UpdateGrid();
            if (openMode == "Выбор")
            {
                buttonSelect.Visibility = Visibility.Visible;
            }
            else
            {
                buttonSelect.Visibility = Visibility.Collapsed;
            }
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

        public async Task UpdateGrid()
        {
            contactPersonList = await MyHTTPClient.GetAllContactPersons();
            MainGrid.ItemsSource = contactPersonList;
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MainGrid.SelectedItem != null)
            {
                ContactPerson contactPerson = (ContactPerson)MainGrid.SelectedItem;
                System.Net.HttpStatusCode code = await MyHTTPClient.DeleteContactPerson(contactPerson);
                if (code == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Контактное лицо не найдено", "Не удалось удалить контактное лицо");
                }
                else if (code == System.Net.HttpStatusCode.Conflict)
                {
                    MessageBox.Show("Есть связи с другими записями", "Не удалось удалить контактное лицо");
                }
                await UpdateGrid();
            }
        }

        private void buttonSelect_Click(object sender, RoutedEventArgs e)
        {

            DialogResult = true;
        }
    }
}
