using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Exceptions;
using pharmacy.DAL.Database;
using pharmacy.DAL.Entities;

namespace pharmacy.DAL.Rrposatory
{
    public class CustomersBL
    {
        private  AppDbContext _context = new AppDbContext();




        public  List<CustomerEntity> GetCustomers()
        {

            List<CustomerEntity> customers = _context.Customers.ToList();

            return customers;
        }


        public  CustomerEntity GetCustomerById(int Id)
        {
            return  _context.Customers.FirstOrDefault(C => C.Id == Id);
        }

        public  void UpdateCustomer(CustomerEntity customer)
        {
            _context.Customers.Update(customer);

            _context.SaveChanges();

        }

        public void  DeleteCustomer(int id)
        {
            CustomerEntity customer =  GetCustomerById(id);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }

        }

        public  void AddCustomer(CustomerEntity newcustomer)
        {

            if (newcustomer != null)
            {
                 _context.Customers.AddAsync(newcustomer);
            }

             _context.SaveChanges();

        }

    }
}
