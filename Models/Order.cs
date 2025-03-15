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
        public CustomerType? CustomerType { get; set; }
        public DeliveryMethod? DeliveryMethod { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public decimal Price { get; set; }
        public string? ProductName { get; set; }
        public string? DeliveryAddr { get; set; }
        public DateTime? OrderDate { get; set; }

        public void PrintDetails()
        {
            Console.WriteLine("Product name: " + ProductName);
            Console.WriteLine("Custome type: " + CustomerType?.Name);
            Console.WriteLine("Payment method: " + PaymentMethod?.Name);
            Console.WriteLine("Delivery method: " + DeliveryMethod?.Name);
            Console.WriteLine("Price: " + Price.ToString());
            Console.WriteLine("Delivery address: " + DeliveryAddr);
        }

        public void PrintExtendedDetails()
        {
            PrintDetails();
            Console.WriteLine("Order date: " + OrderDate.ToString());
            Console.WriteLine("Order status: " + OrderStatus?.Name);
        }
    }
}
