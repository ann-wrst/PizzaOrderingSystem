using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PizzaOrderWebApplication.Models
{
    public class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [RegularExpression(@" ^([A-Z][a-z]+)\ ([A-Z][a-z]+)(\ ?([A-Z][a-z]+)?)|([А-ЯІЇЄЩ][а-яіїщє]+)\ ([А-ЯІЇЄЩ][а-яіїщє]+)(\ ?([А-ЯІЇЄЩ][а-яіїщє]+)?)$", ErrorMessage = "Неправильний формат імені")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [UIHint("EmailAddress")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public String phoneNumber { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public String Address { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
