using package_manager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using package_manager.Models;

namespace package_manager.UserInterface
{
    public class StoreView : CommandHandler
    {
        private OrderService orderService;

        public StoreView(OrderService orderService) 
        {
            this.orderService = orderService;
        }

        public void HandleCommand()
        {
            Order? order = null;
            do
            {
                string input = InputService.GetInput("Enter package Id or [exit] to abort: ");
                if (input == "exit")
                {
                    return;
                }
                if (int.TryParse(input, out int result))
                {
                    order = orderService.GetOrderById(result);
                }
            } while (order == null);

            if (order.OrderStatus.Id == OrderStatusEnum.InStock
                || order.OrderStatus.Id == OrderStatusEnum.Closed
                || order.OrderStatus.Id == OrderStatusEnum.Invalid) 
            {
                Console.WriteLine("Invalid order status: " +  order.OrderStatus.Name);
                return;
            }
            Console.WriteLine(orderService.StoreOrder(order));
        }
    }
}
