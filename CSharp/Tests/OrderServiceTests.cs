using System;
using System.Collections.Generic;
using System.Linq;
using CSharp.Models;
using CSharp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Tests
{
    [TestClass]
    public class OrderServiceTests
    {
        private OrderService _orderService;
        private List<Order> _orders;

        [TestInitialize]
        public void Setup()
        {
            // Initialize OrderService and some sample data
            _orderService = new OrderService();
            _orders = new List<Order>
            {
                new Order { Id = 1, CustomerName = "Sneaky Snake", OrderDate = DateTime.UtcNow, TotalAmount = 100.00m, IsCancelled = false },
                new Order { Id = 2, CustomerName = "Master Chief", OrderDate = DateTime.UtcNow, TotalAmount = 150.00m, IsCancelled = false }
            };
            _orderService.SetOrders( _orders );
        }

        [TestMethod]
        public void GetOrder_Returns_Order_With_Valid_Id()
        {
            // Arrange
            int orderId = 1;

            // Act
            var order = _orderService.GetOrder(orderId);

            // Assert
            Assert.IsNotNull(order);
            Assert.AreEqual(orderId, order.Id);
        }

        [TestMethod]
        public void GetOrder_Returns_Null_With_Invalid_Id()
        {
            // Arrange
            int orderId = 3; // Assumes order with Id 3 does not exist

            // Act
            var order = _orderService.GetOrder(orderId);

            // Assert
            Assert.IsNull(order);
        }

        [TestMethod]
        public void UpdateOrder_Updates_Existing_Order()
        {
            // Arrange
            var updatedOrder = new Order { Id = 1, CustomerName = "President Obama", TotalAmount = 150.00m };

            // Act
            _orderService.UpdateOrder(updatedOrder);

            // Assert
            var modifiedOrder = _orders.FirstOrDefault(o => o.Id == updatedOrder.Id);
            Assert.IsNotNull(modifiedOrder);
            Assert.AreEqual(updatedOrder.CustomerName, modifiedOrder.CustomerName);
            Assert.AreEqual(updatedOrder.TotalAmount, modifiedOrder.TotalAmount);
        }

        [TestMethod]
        public void UpdateOrder_Throws_Exception_When_Order_Not_Found()
        {
            // Arrange
            var updatedOrder = new Order { Id = 3, CustomerName = "Jane Smith", TotalAmount = 150.00m };

            // Act and Assert
            Assert.ThrowsException<Exception>(() => _orderService.UpdateOrder(updatedOrder));
        }

        [TestMethod]
        public void CancelOrder_Cancels_Existing_Order()
        {
            // Arrange
            int orderId = 2;

            // Act
            _orderService.CancelOrder(orderId);

            // Assert
            var cancelledOrder = _orders.FirstOrDefault(o => o.Id == orderId);
            Assert.IsNotNull(cancelledOrder);
            Assert.IsTrue(cancelledOrder.IsCancelled);
        }

        [TestMethod]
        public void CancelOrder_Throws_Exception_When_Order_Not_Found()
        {
            // Arrange
            int orderId = 3;

            // Act and Assert
            Assert.ThrowsException<Exception>(() => _orderService.CancelOrder(orderId));
        }
    }
}
