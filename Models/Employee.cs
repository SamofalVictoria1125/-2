using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Курсовая.Controllers;

namespace Курсовая.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int IdcontactPerson { get; set; }

        public Task<ContactPerson> contactPerson
        {
            get
            {
                return MyHTTPClient.GetContactPersonById(IdcontactPerson);
            }
        }
    }
}
