using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace package_manager.Models
{
    public enum PaymentMethodEnum
    {
        Card,
        Cash,
        Blik,
    }

    public class PaymentMethod
    {

        public PaymentMethodEnum Id { get; set; }
        public string? Name { get; set; }
    }
}
