using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string UserRol { get; set; } 
    }
}
