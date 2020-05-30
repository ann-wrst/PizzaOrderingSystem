using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderWebApplication.Models
{
    public class PizzaContext : DbContext   {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderPizza> OrderPizza { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public PizzaContext(DbContextOptions<PizzaContext> options): base(options)
        {
            Database.EnsureCreated();
        }

    }
}
