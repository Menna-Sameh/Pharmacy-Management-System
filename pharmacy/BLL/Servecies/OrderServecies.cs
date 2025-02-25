using pharmacy.DAL.Entities;
using pharmacy.DAL.Repository;
using pharmacy.DAL.Rrposatory;
using System.Collections.Generic;
using System.Linq;

namespace pharmacy.BLL.Servecies
{
    public class OrderServecies
    {
        private readonly OrderDL _ordersBL = new OrderDL();

        public List<OrderEntityDto> GetOrders()
        {
            var orders = _ordersBL.GetOrders();
            var ordersDto = orders.Select(o => new OrderEntityDto
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount,
                Status = o.Status,
                CustomerId = o.CustomerId,
                EmployeeId = o.EmployeeId,
                OrderMedicines = o.OrderMedicines
            }).ToList();

            return ordersDto;
        }

        public OrderEntityDto GetOrderById(int Id)
        {
            var order = _ordersBL.GetOrderById(Id);
            var orderDto = new OrderEntityDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                OrderMedicines = order.OrderMedicines
            };

            return orderDto;
        }

        public void UpdateOrder(OrderEntity order)
        {
            _ordersBL.UpdateOrder(order);
        }

        public void DeleteOrder(int id)
        {
            _ordersBL.DeleteOrder(id);
        }

        public void AddOrder(OrderEntity newOrder)
        {
            _ordersBL.AddOrderAsync(newOrder);
        }
    }
}
