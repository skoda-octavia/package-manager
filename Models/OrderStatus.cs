using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        Closed,
    }

    public class OrderStatus
    {
        public OrderStatus(OrderStatusEnum status)
        {
            Id = status;
            Name = status.ToString();
        }

        public OrderStatus() { }
        public OrderStatusEnum Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
    }
}
