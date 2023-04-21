using Microsoft.AspNetCore.Mvc;
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
using Курсовая.Tools;

namespace Курсовая
{
    /// <summary>
    /// Логика взаимодействия для MainRegistr.xaml
    /// </summary>
    public partial class MainRegistr : Window
    {
        public MainRegistr()
        {
            InitializeComponent();
        }

        private async void Reg(object sender, RoutedEventArgs e)
        {
            var json = await Api.Post("Users", new User
            {
                Login = txt_Login.Text,
                Password = txt_Password.Text,
            }, "SaveUser");
            User result = Api.Deserialize<User>(json);
            MessageBox.Show("Найс!");

            MainAuth m = new MainAuth();
            m.Show();
            this.Close();
        }
    }
}
