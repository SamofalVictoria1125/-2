using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Курсовая.Controllers;

namespace Курсовая.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public int Idpartner { get; set; }

        public Task<Counterparty> counterparty
        {
            get
            {
                return MyHTTPClient.GetPartnerById(Idpartner);
            }
        }
    }
}
