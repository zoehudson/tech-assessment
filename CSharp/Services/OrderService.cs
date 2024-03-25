using System.Collections.Generic;
using System;
using CSharp.Models;
using CSharp.Controllers;
using System.Linq;
namespace CSharp.Services
{
    public class OrderService : IOrderService
    {
        private readonly List<Order> _orders;

        public OrderService()
        {
            _orders = new List<Order>
        {
            new Order { Id = 1, CustomerName = "John Doe", OrderDate = DateTime.UtcNow, TotalAmount = 100.00m, IsCancelled = false },
            new Order { Id = 2, CustomerName = "Jane Smith", OrderDate = DateTime.UtcNow, TotalAmount = 150.00m, IsCancelled = false }

        };
        }
        // Method to set orders externally for testing purposes in place of mocking
        public void SetOrders(List<Order> orders)
        {
            _orders.Clear();
            _orders.AddRange(orders);
        }

        public Order GetOrder(int orderId)
        {
            return _orders.FirstOrDefault(o => o.Id == orderId);
        }

        public void UpdateOrder(Order updatedOrder)
        {
            var existingOrder = _orders.FirstOrDefault(o => o.Id == updatedOrder.Id);
            if (existingOrder == null)
            {
                throw new Exception("order not found");
            }
            //update order if found
            existingOrder.CustomerName = updatedOrder.CustomerName;
            existingOrder.TotalAmount = updatedOrder.TotalAmount;
        }

        public void CancelOrder(int orderId)
        {
            //find order with id
            var existingOrder = _orders.FirstOrDefault(o => o.Id == orderId);

            if (existingOrder == null)
            {
                throw new Exception("order not found");
            }
            //cancel if found
            existingOrder.IsCancelled = true;
        }
    }
}
