﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Курсовая.Windows;

namespace Курсовая
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ContactPersonListView contactPersonList= new ContactPersonListView();
            contactPersonList.ShowDialog();
        }

        private void buttonProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductListView2 productListView = new ProductListView2();
            productListView.ShowDialog();
        }

        private void Button_Counterparty(object sender, RoutedEventArgs e)
        {
            CounterpartyListView counterpartylistView = new CounterpartyListView();
            counterpartylistView.ShowDialog();
        }

        private void buttonCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerListView customerListView = new CustomerListView();
            customerListView.ShowDialog();
        }

        private void Button_DeliveryCompositions(object sender, RoutedEventArgs e)
        {

        }

        private void buttonEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Purchase(object sender, RoutedEventArgs e)
        {

        }
    }
}
