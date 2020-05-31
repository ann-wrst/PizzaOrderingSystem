using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderWebApplication.Models
{
    public class OrderPizza
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int PizzaId { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int OrderId { get; set; }
        public virtual Pizza Pizza { get; set; }
        public virtual Order Order { get; set; }
    }
}
