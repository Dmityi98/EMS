using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Core.Models;

namespace Ems.Core.Interface.Interfaces
{
    public interface IEMSRepository
    {
        Role GetRoleEmployee(Employee employee);
        IEnumerable<Notes> ViewEmployeeNotes(Employee employee);
        Employee AddNewEmploee(Employee employee);
        bool ChangeStatusProgress(int id, Progress status);
        void Save();
    }
}
