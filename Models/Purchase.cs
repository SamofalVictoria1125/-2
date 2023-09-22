using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Курсовая.Controllers;

namespace Курсовая.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime DateCalculation { get; set; }
        public int Idmanager { get; set; }

        private async Task<Employee> TaskEmployee()
        {


            return await MyHTTPClient.GetEmployeeById(Idmanager);

        }

        [JsonIgnore]
        public Employee Employee
        {
            get
            {
                return GetEmployee();
            }
        }

        private Employee GetEmployee()
        {
            return Task.Run(() => TaskEmployee()).Result;
        }
    }
}
