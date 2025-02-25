using pharmacy.DAL.Database;
using pharmacy.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy.DAL.Rrposatory
{
    public class EmployeeBL
    {
        private AppDbContext _context = new AppDbContext();




        public List<EmployeeEntity> GetEmployee()
        {

            List<EmployeeEntity> employees = _context.Employees.ToList();

            return employees;
        }


        public EmployeeEntity GetEmployeeById(int Id)
        {
            return _context.Employees.FirstOrDefault(C => C.Id == Id);
        }

        public void UpdateEmployee(EmployeeEntity employee)
        {
            _context.Employees.Update(employee);

            _context.SaveChanges();

        }

        public void DeleteEmployee(int id)
        {
            EmployeeEntity employee = GetEmployeeById(id);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }

        }

        public void AddEmployee(EmployeeEntity newemployee)
        {

            if (newemployee != null)
            {
                _context.Employees.AddAsync(newemployee);
            }

            _context.SaveChanges();

        }
    }
}
