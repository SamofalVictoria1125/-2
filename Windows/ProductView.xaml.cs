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
    /// Логика взаимодействия для ProductView.xaml
    /// </summary>
    public partial class ProductView : Window
    {
        int OpenMode;

        Product model;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="openMode">если 0 - добавление, если 1 - редактирование</param>
        public ProductView(Product model, int openMode)
        {
            
            InitializeComponent();
            this.model = model;
            textBoxID.Text = this.model.Id.ToString();
            textBoxProductName.Text = this.model.ProductName;
            textBoxCategory.Text = this.model.Category;
            textBoxDescription.Text = this.model.Description;
            OpenMode = openMode;
            if (openMode == 0)
            {
                textBoxID.Visibility = Visibility.Hidden;
                label_ID.Visibility = Visibility.Hidden;
            }

        }

        private async void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            model.ProductName = textBoxProductName.Text;
            model.Category = textBoxCategory.Text;
            model.Description = textBoxDescription.Text;
            if (OpenMode == 0)
            {
                await MyHTTPClient.CreateProduct(model);

            }
            else
            {
                await MyHTTPClient.UpdateProduct(model);
            }
            DialogResult = true;
           

        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
