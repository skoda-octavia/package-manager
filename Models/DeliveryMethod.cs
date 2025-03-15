using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public DeliveryMethod(DeliveryMethodEnum id)
        {
            Id = id;
            Name = id.ToString();
        }
        public DeliveryMethod() { }
        public DeliveryMethodEnum Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
    }
}
