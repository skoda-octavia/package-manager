using package_manager.Models;
using package_manager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace package_manager.UserInterface
{
    public class CreateOrderView : CommandHandler
    {
        private OrderService orderService;
        public CreateOrderView(OrderService orderService)
        {
            this.orderService = orderService;
        }

        private Order CollectData()
        {
            string productName = InputService.GetInput("Product name: ");
            decimal total = InputService.GetDecimalInput("Total price: ");
            CustomerTypeEnum customerType = InputService.GetEnumInput<CustomerTypeEnum>("Client type: ");
            PaymentMethodEnum paymentMethod = InputService.GetEnumInput<PaymentMethodEnum>("Payment method: ");
            DeliveryMethodEnum delivery = InputService.GetEnumInput<DeliveryMethodEnum>("Delivery method: ");
            string address = InputService.GetInput("Delivery address: ");

            return new Order()
            {
                CustomerType = new CustomerType(customerType),
                PaymentMethod = new PaymentMethod(paymentMethod),
                ProductName = productName,
                Price = total,
                DeliveryAddr = address,
                OrderDate = DateTime.Now,
                DeliveryMethod = new DeliveryMethod(delivery),
                OrderStatus = new OrderStatus(OrderStatusEnum.New)
            };
        }

        public void HandleCommand()
        {

            Order order = CollectData();



            bool confirmed = InputService.GetInputBool("Do You want to save package?: ");
            if (confirmed)
            {
                orderService.SaveOrder(order);
            }
        }

    }
}
