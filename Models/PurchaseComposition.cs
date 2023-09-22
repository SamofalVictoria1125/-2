using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Курсовая.Controllers;

namespace Курсовая.Models
{
    internal class PurchaseComposition
    {
        public int Id { get; set; }
        public int Idpurchase { get; set; }
        public int Idproduct { get; set; }
        public int Quantity { get; set; }
        public int Volume { get; set; }
        public int Weight { get; set; }
        public int Sum { get; set; }

        public Task<Product> product
        {
            get
            {
                return MyHTTPClient.GetProductById(Idproduct);
            }
        }

        public Task<Purchase> purchase
        {
            get
            {
                return MyHTTPClient.GetPurchaseById(Idpurchase);
            }
        }
    }
}
