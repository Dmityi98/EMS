using Ems.Core.Interface.Interfaces;
using EMS.Core.Models;

namespace EMS.Infrastructure.Data
{
    public class EMSRepository : IEMSRepository
    {
        private EMSContext _context;
        public EMSRepository()
        {
            _context = new EMSContext();
        }
        public Employee AddNewEmploee(Employee employee)
        {
            _context.Employees.Add(employee);
            Save();
            return employee;
        }

        public bool ChangeStatusProgress(int id, Progress status)
        {
            var notes = _context.Notes.FirstOrDefault(x => x.Id == id);
            if (notes != null)
            {
                notes.Progress = status;
                return true;
            }
            return false;
        }

        public Role GetRoleEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Notes> ViewEmployeeNotes(Employee employee)
        {
            return _context.Notes.Where(t=> t.EmployeeId == employee.Id).ToList();
        }
    }
}
