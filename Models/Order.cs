using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(64)]
        public string ProductName { get; set; }
        [MaxLength(64)]
        public string? DeliveryAddr { get; set; }
        public DateTime OrderDate { get; set; }

        public Order(int id, CustomerType customerType, DeliveryMethod deliveryMethod, OrderStatus orderStatus, PaymentMethod paymentMethod, decimal price, string productName, string? deliveryAddr, DateTime orderDate)
        {
            Id = id;
            CustomerType = customerType;
            DeliveryMethod = deliveryMethod;
            OrderStatus = orderStatus;
            PaymentMethod = paymentMethod;
            Price = price;
            ProductName = productName;
            DeliveryAddr = deliveryAddr;
            OrderDate = orderDate;
        }

        public Order(CustomerType customerType, DeliveryMethod deliveryMethod, OrderStatus orderStatus, PaymentMethod paymentMethod, decimal price, string productName, string? deliveryAddr, DateTime orderDate)
        {
            CustomerType = customerType;
            DeliveryMethod = deliveryMethod;
            OrderStatus = orderStatus;
            PaymentMethod = paymentMethod;
            Price = price;
            ProductName = productName;
            DeliveryAddr = deliveryAddr;
            OrderDate = orderDate;
        }

        public Order() { }

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
            Console.WriteLine("Id: " + Id);
            PrintDetails();
            Console.WriteLine("Order date: " + OrderDate.ToString());
            Console.WriteLine("Order status: " + OrderStatus?.Name);
        }
    }
}
