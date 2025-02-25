using pharmacy.DAL.Entities;
using pharmacy.DAL.Rrposatory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pharmacy.BLL.Servecies
{
    public class EmployeeServiesces
    {
        private readonly EmployeeBL _employeeBL = new EmployeeBL();

        public List<EmployeeEntityDto> GetEmployees()
        {
            var employees = _employeeBL.GetEmployee();
            return employees.Select(e => new EmployeeEntityDto
            {
                Id = e.Id,
                Name = e.Name,
                Salary = e.Salary,
                HireDate = e.HireDate
            }).ToList();
        }

        public EmployeeEntityDto GetEmployeeById(int id)
        {
            var employee = _employeeBL.GetEmployeeById(id);

            if (employee == null)
            {
                Console.WriteLine($"❌ Employee with ID {id} not found.");
                return null; // يمكنكِ رمي Exception بدلاً من إرجاع null حسب الحاجة
            }

            return new EmployeeEntityDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Salary = employee.Salary,
                HireDate = employee.HireDate
            };
        }

        public void UpdateEmployee(EmployeeEntity employeeDto)
        {
            if (employeeDto == null)
            {
                Console.WriteLine("❌ Cannot update a null employee.");
                return;
            }

            var employeeEntity = new EmployeeEntity
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Salary = employeeDto.Salary,
                HireDate = employeeDto.HireDate
            };

            _employeeBL.UpdateEmployee(employeeEntity);
        }

        public void DeleteEmployee(int id)
        {
            _employeeBL.DeleteEmployee(id);
        }

        public void AddEmployee(EmployeeEntityDto newEmployeeDto)
        {
            if (newEmployeeDto == null)
            {
                Console.WriteLine("❌ Cannot add a null employee.");
                return;
            }

            var newEmployee = new EmployeeEntity
            {
                Name = newEmployeeDto.Name,
                Salary = newEmployeeDto.Salary,
                HireDate = newEmployeeDto.HireDate
            };

            _employeeBL.AddEmployee(newEmployee);
        }
    }

    public class EmployeeEntityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
    }
}
