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
        public StoreView(OrderService orderService) : base(orderService) { }

        public override void HandleCommand()
        {
            Order? order = GetOrderByUserInput();
            if (order == null)
            {
                return;
            }

            if (order.OrderStatus.Id == OrderStatusEnum.Sent) 
            {
                Console.WriteLine("Package already sent.");
                return;
            }
            Console.WriteLine(orderService.StoreOrder(order));
        }
    }
}
