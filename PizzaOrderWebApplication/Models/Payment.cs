using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderWebApplication.Models
{
    public class Payment
    {
        public Payment()
        {
            Order = new HashSet<Order>();
        }
        public int Id { get; set; }
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Range(1, 15000, ErrorMessage = "Введіть коректний рахунок")]
        public int Bill { get; set; }
        public virtual ICollection<Order> Order { get; set; }

    }
}
