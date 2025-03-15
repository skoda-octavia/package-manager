using package_manager.Models;
using package_manager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace package_manager.UserInterface
{
    public class SendPackageView : CommandHandler
    {
        public SendPackageView(OrderService orderService) : base(orderService) { }

        public override void HandleCommand()
        {
            Order? order = GetOrderByUserInput();
            if (order == null)
            {
                return;
            }
            Console.WriteLine(orderService.PlaceInShipping(order));
        }
    }
}
