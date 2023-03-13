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
            /*textBoxID.Text = this.model.ID.ToString();
            textBoxProductName.Text = this.model.ProductName;
            textBoxCategory.Text = this.model.Category;
            textBoxDescription.Text = this.model.Description;
            OpenMode = openMode;
            if (openMode == 0)
            {
                textBoxID.Visibility = Visibility.Hidden;
                label_ID.Visibility = Visibility.Hidden;
            }*/

        }
    }
}
