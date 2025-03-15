using package_manager.Models;
using package_manager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace package_manager.UserInterface
{
    public class FilterPackagesView : CommandHandler
    {
        private readonly string Divider;
        public FilterPackagesView(OrderService orderService, int dividerLen) : base(orderService) 
        {
            Divider = new string('-', dividerLen);
        }
        public override void HandleCommand()
        {
            Console.WriteLine("Filter Orders:");

            string? productName = InputService.GetFilterValue("Product name (leave empty to skip): ");
            DateTime? orderDate = InputService.GetDateFilter("Order date (YYYY-MM-DD, leave empty to skip): ");
            decimal? price = InputService.GetDecimalFilter("Price (leave empty to skip): ");
            int? orderId = InputService.GetIntFilter("Order ID (leave empty to skip): ");
            OrderStatusEnum? status = InputService.GetEnumFilter<OrderStatusEnum>("Order Status (leave empty to skip): ");
            PaymentMethodEnum? paymentMethod = InputService.GetEnumFilter<PaymentMethodEnum>("Payment Method (leave empty to skip): ");

            List<Order> orders = orderService.FilterOrders(
                productName,
                orderDate,
                price,
                orderId,
                status,
                paymentMethod);

            Console.WriteLine("Found orders: " + orders.Count);
            foreach (var order in orders)
            {
                Console.WriteLine(Divider);
                order.PrintExtendedDetails();
            }
        }
    }
}
