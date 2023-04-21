using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Курсовая.Windows;

namespace Курсовая.Models
{
    public class Counterparty
    {
        public int Id { get; set; }
        public string NameOrganization { get; set; } = null!;
        public int IdContactPerson { get; set; }
        public string Address { get; set; } = null!;
    }
}
