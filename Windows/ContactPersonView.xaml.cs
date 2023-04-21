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
    /// Логика взаимодействия для ContactPersonView.xaml
    /// </summary>
    public partial class ContactPersonView : Window
    {
        int OpenMode;

        ContactPerson model;
        public ContactPersonView(ContactPerson model, int openMode)
        {
            
            InitializeComponent();
            this.model = model;
            textBoxID.Text = this.model.Id.ToString();
            textBoxFirstName.Text = this.model.FirstName;
            textBoxLastName.Text = this.model.LastName;
            textBoxPatronymic.Text = this.model.Patronymic;
            textBoxSex.Text = this.model.Sex;
            OpenMode = openMode;
            if (openMode == 0)
            {
                textBoxID.Visibility = Visibility.Hidden;
                label_ID.Visibility = Visibility.Hidden;
            }

        }

        private async void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            model.FirstName = textBoxFirstName.Text;
            model.LastName = textBoxLastName.Text;
            model.Patronymic = textBoxPatronymic.Text;
            model.Sex = textBoxSex.Text;
            if (OpenMode == 0)
            {
                await MyHTTPClient.CreateContactPerson(model);

            }
            else
            {
                await MyHTTPClient.UpdateContactPerson(model);
            }
            DialogResult = true;
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
