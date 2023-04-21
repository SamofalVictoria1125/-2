using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая.Models
{
    internal class Purchase
    {
        public int Id { get; set; }
        public DateTime DateCalculation { get; set; }
        public int Idmanager { get; set; }
    }
}
