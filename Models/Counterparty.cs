using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Курсовая.Controllers;
using Курсовая.Windows;

namespace Курсовая.Models
{
    public class Counterparty
    {
        public int Id { get; set; }
        public string NameOrganization { get; set; } = null!;
        public int ContactPersonId { get; set; }
        public string Address { get; set; } = null!;

        //[JsonIgnore]
        private async Task<ContactPerson> TaskContactPerson()
        {
            
            
             return await MyHTTPClient.GetContactPersonById(ContactPersonId);
            
        }

        [JsonIgnore]
        public ContactPerson ContactPerson
        {
            get
            {
                return GetContactPerson();
            }
        }

        private ContactPerson GetContactPerson()
        {
            return Task.Run(() => TaskContactPerson()).Result;
        }

        

    }
}
