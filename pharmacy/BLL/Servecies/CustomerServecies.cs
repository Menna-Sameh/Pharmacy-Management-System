using Microsoft.EntityFrameworkCore;
using pharmacy.DAL.Entities;
using pharmacy.DAL.Rrposatory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy.BLL.Servecies
{
    public class CustomerServecies
    {
        private readonly CustomersBL _customersBL = new CustomersBL();
        public List<CustomerEntityDto> GetCustomers()
        {
            var customers = _customersBL.GetCustomers();
            var customersDto = customers.Select(c => new CustomerEntityDto
            {
                Id = c.Id,
                Name = c.Name,
                Phone = c.Phone,
                Address = c.Address,
                Orders = c.Orders
            }).ToList();

            return customersDto;

        }


        public CustomerEntity GetCustomerById(int Id)
        {
            var customer = _customersBL.GetCustomerById(Id);
            var customerDto = new CustomerEntity
            {
                Id = customer.Id,
                Name = customer.Name,
                Phone = customer.Phone,
                Address = customer.Address,
                Orders = customer.Orders
            };

            return customerDto;
        }
        public void UpdateCustomer(CustomerEntity customer)
        {
            _customersBL.UpdateCustomer(customer);


        }
        public void DeleteCustomer(int id)
        {
            _customersBL.DeleteCustomer(id);
;

        }
        public void AddCustomer(CustomerEntity newcustomer)
        {
            _customersBL.AddCustomer(newcustomer);
        }

    }
}
