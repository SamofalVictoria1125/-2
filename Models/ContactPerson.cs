using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая.Models
{
    public partial class ContactPerson
    {
        public ContactPerson()
        {
            //Counterparties = new HashSet<Counterparty>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string Sex { get; set; } = null!;

        public virtual ICollection<Counterparty> Counterparties { get; set; }
    }
}
