using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace package_manager.Models
{
    public class Order
    {
        public int Id { get; set; }
        public CustomerType CustomerType { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal Price { get; set; }
        public string? ProductName { get; set; }
        public string? DeliveryAddr { get; set; }
    }
}
