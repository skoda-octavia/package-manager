using package_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace package_manager.Services.DeliveryServices
{
    public interface DeliveryService
    {
        public Task HandleDelivery(Order order);
    }
}
