using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models
{
    public class Employee
    {
        public Employee(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Role RoleEmployee { get; set; }
    }
}
