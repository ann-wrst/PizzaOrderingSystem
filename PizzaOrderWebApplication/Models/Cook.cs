using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderWebApplication.Models
{
    public class Cook
    {
        public Cook()
        {
            OrderCooking = new HashSet<OrderCooking>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Ім'я кухара")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Range(0, 75, ErrorMessage = "Введіть коректний стаж роботи")]
        public int Experience { get; set; }

        public virtual ICollection<OrderCooking> OrderCooking { get; set; }
    }
}
