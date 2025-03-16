using Microsoft.EntityFrameworkCore;
using package_manager.Data;
using package_manager.Models;
using package_manager.Services.DeliveryServices;
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

        private readonly decimal maxCashPayment;

        private Dictionary<DeliveryMethodEnum, DeliveryService> deliveryServices;

        public OrderService(AppDbContext appDbContext, decimal maxCashPaymant)
        {
            this.appDbContext = appDbContext;
            this.maxCashPayment = maxCashPaymant;
            deliveryServices = new Dictionary<DeliveryMethodEnum, DeliveryService>
            {
                {DeliveryMethodEnum.HomeDelivery, new HomeDeliveryService(this) },
                {DeliveryMethodEnum.Locker, new LockerDeliveryService(this) },
            };
        }

        private void AttachEnumInstances(Order order)
        {
            order.OrderStatus = appDbContext.OrderStatuses.FirstOrDefault(c => c.Id == order.OrderStatus.Id) ?? new OrderStatus(OrderStatusEnum.New);
            order.PaymentMethod = appDbContext.PaymentMethods.FirstOrDefault(c => c.Id == order.PaymentMethod.Id) ?? new PaymentMethod(PaymentMethodEnum.Card);
            order.CustomerType = appDbContext.CustomerTypes.FirstOrDefault(c => c.Id == order.CustomerType.Id) ?? new CustomerType(CustomerTypeEnum.Company);
            order.DeliveryMethod = appDbContext.DeliveryMethods.FirstOrDefault(c => c.Id == order.DeliveryMethod.Id) ?? new DeliveryMethod(DeliveryMethodEnum.Locker);
        }


        public string SaveOrder(Order order)
        {
            string answer;
            if (order.DeliveryAddr == null)
            {
                order.OrderStatus = new OrderStatus(OrderStatusEnum.Invalid);
                answer = "No address given, order marked as invalid.";
            }
            else
            {
                answer = "Order saved";
            }
            AttachEnumInstances(order);
            appDbContext.Orders.Add(order);
            appDbContext.SaveChangesAsync();
            return answer;
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
            if (order.Price >= maxCashPayment && order.PaymentMethod.Id == PaymentMethodEnum.Cash)
            {
                order.OrderStatus = appDbContext.OrderStatuses.FirstOrDefault(c => c.Id == OrderStatusEnum.Returned) ?? new OrderStatus(OrderStatusEnum.Returned);
                answer = "Package returned to client.";
            }
            else
            {
                order.OrderStatus = appDbContext.OrderStatuses.FirstOrDefault(c => c.Id == OrderStatusEnum.InStock) ?? new OrderStatus(OrderStatusEnum.InStock);
                answer = "Package in stock";
            }
            appDbContext.Orders.Update(order);
            appDbContext.SaveChangesAsync();
            return answer;
        }

        public string PlaceInShipping(Order order)
        {
            string answer;

            if (order.OrderStatus.Id == OrderStatusEnum.InStock
                && deliveryServices.TryGetValue(order.DeliveryMethod.Id, out DeliveryService? deliveryService))
            {
                answer = "Package is in shipping.";
                Task.Run(async () =>
                {
                    await deliveryService.HandleDelivery(order);
                });
            }
            else
            {
                answer = "Invalid order status or delivery service.";
            }
            return answer;
        }

        public void MarkSent(Order order)
        {
            order.OrderStatus = appDbContext.OrderStatuses.FirstOrDefault(c => c.Id == OrderStatusEnum.Sent) ?? new OrderStatus(OrderStatusEnum.Sent);
            appDbContext.Orders.Update(order);
            appDbContext.SaveChangesAsync();
        }

        public List<Order> FilterOrders(
            string? productName = null,
            DateTime? orderDate = null,
            decimal? price = null,
            int? orderId = null,
            OrderStatusEnum? status = null,
            PaymentMethodEnum? paymentMethod = null)
        {
            IQueryable<Order> query = appDbContext.Orders;

            if (!string.IsNullOrEmpty(productName)) { query = query.Where(o => o.ProductName.Contains(productName)); }
            if (orderDate.HasValue) { query = query.Where(o => o.OrderDate.Date == orderDate.Value.Date); }
            if (price.HasValue) { query = query.Where(o => o.Price == price.Value); }
            if (orderId.HasValue) { query = query.Where(o => o.Id == orderId.Value); }
            if (status.HasValue) { query = query.Where(o => o.OrderStatus.Id == status.Value); }
            if (paymentMethod.HasValue) { query = query.Where(o => o.PaymentMethod.Id == paymentMethod.Value); }

            return query.ToList();
        }

        public string CloseOrder(Order order)
        {
            string answer;
            if (order.OrderStatus.Id == OrderStatusEnum.Sent)
            {
                order.OrderStatus = appDbContext.OrderStatuses.FirstOrDefault(c => c.Id == OrderStatusEnum.Closed) ?? new OrderStatus(OrderStatusEnum.Closed);
                appDbContext.Orders.Update(order);
                appDbContext.SaveChangesAsync();
                answer = "Order closed.";
            }
            else
            {
                answer = "Order not sent.";
            }
            return answer;
        }
    }
}
