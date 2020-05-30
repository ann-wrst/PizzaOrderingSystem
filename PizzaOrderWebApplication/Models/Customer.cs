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
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Неправильний формат e-mail")]

        public String Email { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [RegularExpression(@"^((\+38|38)+([0-9]){10})$", ErrorMessage = "Некоректний номер телефону")]
        public String phoneNumber { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public String Address { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
