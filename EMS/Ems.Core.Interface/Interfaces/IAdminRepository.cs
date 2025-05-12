using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Core.Models;

namespace Ems.Core.Interface.Interfaces
{
    public interface IAdminRepository
    {
        public Employee NewEmployee(string name, string password);
        public Notes CreateNewNotes();
    }
}
