using package_manager.Data;
using package_manager.Models;
using package_manager.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace package_manager.UserInterface
{
    public class OrdersView : OrdersWriter
    {
        public OrdersView(OrderService orderService, int dividerLen) : base(orderService, dividerLen) { }
        public override void HandleCommand()
        {
            List<Order> orders = orderService.GetOrders();
            PrintOrdersExtended(orders);
        }
    }
}
