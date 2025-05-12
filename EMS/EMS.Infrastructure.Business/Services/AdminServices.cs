using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ems.Core.Interface.Interfaces;
using EMS.Core.Models;
using EMS.Infrastructure.Data;

namespace EMS.Infrastructure.Business.Services
{
    public class AdminServices : IAdminRepository
    {
        private EMSContext _context = new EMSContext();
        public Notes CreateNewNotes()
        {
            throw new NotImplementedException();
        }

        public Employee NewEmployee(string name, string password)
        {
            var user = new Employee(name, password);
            _context.Employees.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
