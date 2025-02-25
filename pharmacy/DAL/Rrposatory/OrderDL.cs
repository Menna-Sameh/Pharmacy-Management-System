using pharmacy.DAL.Database;
using pharmacy.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pharmacy.DAL.Repository
{
    public class OrderDL
    {
        private readonly AppDbContext _context = new AppDbContext();

        public List<OrderEntity> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public OrderEntity GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public void UpdateOrder(OrderEntity order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = GetOrderById(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public async Task AddOrderAsync(OrderEntity newOrder)
        {
            if (newOrder != null)
            {
                await _context.Orders.AddAsync(newOrder);
                await _context.SaveChangesAsync();
            }
        }
    }
}
