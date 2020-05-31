using System;
using Xunit;
using PizzaOrderWebApplication;
using PizzaOrderWebApplication.Controllers;
using PizzaOrderWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PizzaOrderingTests
{
    public class UnitTest1
    {
        [Fact] 
        public void PostOrder()
        {
            var options = new DbContextOptionsBuilder<PizzaContext>()
                .UseSqlServer("Server=localhost;Database=PizzaOrderingSystem;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;
            var context = new PizzaContext(options);
            CustomersController customersController = new CustomersController(context);
            Customer customer = new Customer { 
                Id=11,
                Name = "Олександр Олександрович", 
                Email = "test@gmail.com", 
                phoneNumber = "+380505009090", 
                Address = "Сеченова, 10", 
                Order = null };
            int result = (customersController.PutCustomer(11, customer).Result as StatusCodeResult).StatusCode;
            int statusCode = 204;
            Assert.Equal(statusCode, result);
        }
        [Fact]
        public void GetOrder()
        {
            var options = new DbContextOptionsBuilder<PizzaContext>()
                .UseSqlServer("Server=localhost;Database=PizzaOrderingSystem;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;
            var context = new PizzaContext(options);
            OrdersController ordersController = new OrdersController(context);
            var order = ordersController.GetOrder(4).Result.Value;
            int actualCustomerId = 11;
            Assert.Equal(actualCustomerId, order.CustomerId);
        }
    }
}
