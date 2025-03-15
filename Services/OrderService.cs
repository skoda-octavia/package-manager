using Microsoft.EntityFrameworkCore;
using package_manager.Data;
using package_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace package_manager.Services
{
    public class OrderService
    {
        private AppDbContext appDbContext;

        private decimal MaxCashPayment = 2500;

        public OrderService(AppDbContext appDbContext) 
        {
            this.appDbContext = appDbContext;
        }

        private void AttachEnumInstances(Order order)
        {
            order.OrderStatus = appDbContext.OrderStatuses.FirstOrDefault(c => c.Id == order.OrderStatus.Id);
            order.PaymentMethod = appDbContext.PaymentMethods.FirstOrDefault(c => c.Id == order.PaymentMethod.Id);
            order.CustomerType = appDbContext.CustomerTypes.FirstOrDefault(c => c.Id == order.CustomerType.Id);
            order.DeliveryMethod = appDbContext.DeliveryMethods.FirstOrDefault(c => c.Id == order.DeliveryMethod.Id);
        }


        public void SaveOrder(Order order)
        {
            AttachEnumInstances(order);
            appDbContext.Orders.Add(order);
            appDbContext.SaveChangesAsync();
        }

        public List<Order> GetOrders()
        {
            return appDbContext.Orders
                .ToList();
        }

        public Order? GetOrderById(int id)
        {
            return appDbContext.Orders.FirstOrDefault(o => o.Id == id);
        }

        public string StoreOrder(Order order)
        {
            string answer;
            if (order.Price >= MaxCashPayment && order.PaymentMethod.Id == PaymentMethodEnum.Cash)
            {
                order.OrderStatus = appDbContext.OrderStatuses.FirstOrDefault(c => c.Id == OrderStatusEnum.Returned);
                answer = "Package returned to client.";
            }
            else
            {
                order.OrderStatus = appDbContext.OrderStatuses.FirstOrDefault(c => c.Id == OrderStatusEnum.InStock);
                answer = "Package in stock";
            }
            appDbContext.Orders.Update(order);
            appDbContext.SaveChangesAsync();
            return answer;
        }
    }
}
