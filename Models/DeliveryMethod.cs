using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace package_manager.Models
{
    public enum DeliveryMethodEnum
    {
        Locker,
        HomeDelivery,
    }

    public class DeliveryMethod
    {

        public DeliveryMethodEnum Id { get; set; }
        public string? Name { get; set; }
    }
}
