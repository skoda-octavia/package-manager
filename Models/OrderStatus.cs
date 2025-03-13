using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace package_manager.Models
{
    public enum OrderStatusEnum
    {
        New,
        InStock,
        Sent,
        Returned,
        Invalid,
        Closed
    }

    public class OrderStatus
    {
        public OrderStatusEnum Id { get; set; }
        public string? Name { get; set; }
    }
}
