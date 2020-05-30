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
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int CustomerId {get;set;}
        public int PaymentId { get; set; }
        public DateTime? OrderTime { get; set; }
        public virtual ICollection<OrderPizza> OrderPizza { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
