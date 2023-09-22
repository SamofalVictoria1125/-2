using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Курсовая.Controllers;

namespace Курсовая.Models
{
    internal class Sale
    {
        public int Id { get; set; }
        public DateTime DateCalculation { get; set; }
        public int Idmanager { get; set; }
        public int IdcurrencyCalculation { get; set; }

        public Task<Employee> employee
        {
            get
            {
                return MyHTTPClient.GetManagerById(Idmanager);
            }
        }
    }
}
