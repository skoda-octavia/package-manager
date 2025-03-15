using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace package_manager.Models
{
    public enum PaymentMethodEnum
    {
        Card,
        Cash,
    }

    public class PaymentMethod
    {
        public PaymentMethod(PaymentMethodEnum enumValue)
        {
            Id = enumValue;
            Name = enumValue.ToString();
        }

        public PaymentMethod() { }

        public PaymentMethodEnum Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
    }
}
