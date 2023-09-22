using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Курсовая.Controllers;

namespace Курсовая.Models
{
    internal class CurrencyRate
    {
        public int Id { get; set; }
        public int Idcurrency { get; set; }
        public string DateRate { get; set; } = null!;
        public string Rate { get; set; } = null!;

        public Task<Currency> currency
        {
            get
            {
                return MyHTTPClient.GetCurrencyById(Idcurrency);
            }
        }
    }
}
