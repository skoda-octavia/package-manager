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
        public CreateOrderView(OrderService orderService) : base(orderService) { }

        public override void HandleCommand()
        {

            Order order = InputService.CollectOrder();
            bool confirmed = InputService.GetInputBool("Do You want to save package?: ");
            if (confirmed)
            {
                orderService.SaveOrder(order);
            }
        }

    }
}
