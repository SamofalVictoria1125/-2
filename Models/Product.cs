using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая.Models
{
    public class Product
    {
        /*public Product()
        {
            DeliveryCompositions = new HashSet<DeliveryComposition>();
            PurchaseCompositions = new HashSet<PurchaseComposition>();
            ShipmentCompositions = new HashSet<ShipmentComposition>();
        }*/

        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;

        /*public virtual ICollection<DeliveryComposition> DeliveryCompositions { get; set; }
        public virtual ICollection<PurchaseComposition> PurchaseCompositions { get; set; }
        public virtual ICollection<ShipmentComposition> ShipmentCompositions { get; set; }*/
    }
}
