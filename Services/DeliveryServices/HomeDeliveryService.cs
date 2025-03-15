using package_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace package_manager.Services.DeliveryServices
{
    public class HomeDeliveryService : DeliveryService
    {
        private OrderService orderService;
        private static readonly int deley = 4000;
        public HomeDeliveryService(OrderService orderService) 
        {
            this.orderService = orderService;
        }
        public async Task HandleDelivery(Order order)
        {
            await Task.Delay(deley);
            orderService.MarkSent(order);
        }
    }
}
