using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Курсовая.Controllers;

namespace Курсовая.Models
{
    internal class Shipment
    {
        public int Id { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int Idmanager { get; set; }

        public Task<Employee> employee
        {
            get
            {
                return MyHTTPClient.GetManagerById(Idmanager);
            }
        }
    }
}
