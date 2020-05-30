using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderWebApplication.Models
{
    public class Pizza
    {
        public Pizza()
        {
            OrderPizza = new HashSet<OrderPizza>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Назва піци")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Range(40, 1000, ErrorMessage = "Введіть коректну ціну")]
        public int Price { get; set; }

        public virtual ICollection<OrderPizza> OrderPizza { get; set; }
    }
}
