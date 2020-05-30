using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderWebApplication.Models
{
    public class OrderCooking
    {
        public int Id { get; set; }
        public int CookId { get; set; }
        public int OrderId { get; set; }
        public virtual Cook Cook { get; set; }
        public virtual Order Order { get; set; }

    }
}
