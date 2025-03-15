using package_manager.Models;
using package_manager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace package_manager.UserInterface
{
    public abstract class CommandHandler
    {
        protected OrderService orderService;

        protected CommandHandler(OrderService orderService)
        {
            this.orderService = orderService;
        }

        protected Order? GetOrderByUserInput()
        {
            Order? order = null;
            do
            {
                string input = InputService.GetInput("Enter package Id or [exit] to abort: ");
                if (input.ToLower() == "exit")
                {
                    return null;
                }
                if (int.TryParse(input, out int orderId))
                {
                    order = orderService.GetOrderById(orderId);
                    if (order == null)
                    {
                        Console.WriteLine("Order not found. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid order ID.");
                }
            } while (order == null);

            return order;
        }

        public abstract void HandleCommand();
    }
}
