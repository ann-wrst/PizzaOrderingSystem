using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderWebApplication.Models
{
    public class Order
    {
        public Order()
        {
            OrderPizza = new HashSet<OrderPizza>();
            OrderCooking = new HashSet<OrderCooking>();           
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int CustomerId {get;set;}     

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public DateTime? OrderTime { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int Bill { get; set; }
        public virtual ICollection<OrderPizza> OrderPizza { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderCooking> OrderCooking { get; set; }
    }
}
