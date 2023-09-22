using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Курсовая.Controllers;

namespace Курсовая.Models
{
    internal class DeliveryComposition
    {
        public int Id { get; set; }
        public int Idsupply { get; set; }
        public int Idproduct { get; set; }
        public int Quantity { get; set; }
        public int Volume { get; set; }
        public int Weight { get; set; }
        public int Sum { get; set; }

        public virtual Product IdproductNavigation { get; set; } = null!;
        public virtual Supply IdsupplyNavigation { get; set; } = null!;

        public Task<Product> product
        {
            get
            {
                return MyHTTPClient.GetProductById(Idproduct);
            }
        }
    }
}
