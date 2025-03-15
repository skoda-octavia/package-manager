using package_manager.Data;
using package_manager.Models;
using package_manager.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace package_manager.UserInterface
{
    public class OrdersViewer : CommandHandler
    {
        private OrderService orderService;
        readonly string Divider;

        public OrdersViewer(OrderService orderService, int dividerLen)
        {
            this.orderService = orderService;
            this.Divider = new string('-', dividerLen);
        }

        public void HandleCommand()
        {
            List<Order> orders = orderService.GetOrders();
            foreach (var item in orders)
            {
                Console.WriteLine(Divider);
                item.PrintExtendedDetails();
            }
        }

    }
}
