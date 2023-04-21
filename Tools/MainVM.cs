using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Курсовая.Models;

namespace Курсовая.Tools
{
    public class MainVM : BaseVM
    {
        public Page currentPage;
        public CommandVM Order { get; set; }
        public CommandVM Product { get; set; }
        public CommandVM Exit { get; set; }

        public Page CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                Signal();
            }
        }

        public MainVM()
        {
           

            Exit = new CommandVM(() =>
            {
                MessageBoxResult Result = MessageBox.Show("Закрыть приложение?", "Уведомление", MessageBoxButton.YesNo);
                if (Result == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();

                }
                else if (Result == MessageBoxResult.No)
                {
                    MessageBox.Show("...");
                }

            });


        }

    }
}
