using package_manager.Services;
using package_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace package_manager.UserInterface
{
    public abstract class OrdersWriter(OrderService orderService, int dividerLen) : CommandHandler(orderService)
    {
        protected internal readonly string Divider = new string('-', dividerLen);

        protected internal void PrintOrdersExtended(List<Order> orders)
        {
            Console.WriteLine("Found orders: " + orders.Count);
            foreach (var item in orders)
            {
                Console.WriteLine(Divider);
                item.PrintExtendedDetails();
            }
        }
    }
}
