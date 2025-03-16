using package_manager.Models;
using package_manager.UserInterface;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace package_manager.Tests
{
    [TestFixture]
    public class CollectOrderTests
    {
        private Order _order;

        [SetUp]
        public void Setup()
        {
            var simulatedInput = "Laptop\n" +
                                 "3000\n" +
                                 "Company\n" +
                                 "Card\n" +
                                 "Locker\n" +
                                 "123 Street\n";

            var stringReader = new StringReader(simulatedInput);
            Console.SetIn(stringReader);

            _order = InputService.CollectOrder();
        }

        [Test]
        public void CollectOrder_ProductName_Correct()
        {
            Assert.That(_order.ProductName, Is.EqualTo("Laptop"));
        }

        [Test]
        public void CollectOrder_Price_Correct()
        {
            Assert.That(_order.Price, Is.EqualTo(3000m));
        }

        [Test]
        public void CollectOrder_CustomerType_Correct()
        {
            Assert.That(_order.CustomerType.Id, Is.EqualTo(CustomerTypeEnum.Company));
        }

        [Test]
        public void CollectOrder_PaymentMethod_Correct()
        {
            Assert.That(_order.PaymentMethod.Id, Is.EqualTo(PaymentMethodEnum.Card));
        }

        [Test]
        public void CollectOrder_DeliveryMethod_Correct()
        {
            Assert.That(_order.DeliveryMethod.Id, Is.EqualTo(DeliveryMethodEnum.Locker));
        }

        [Test]
        public void CollectOrder_DeliveryAddress_Correct()
        {
            Assert.That(_order.DeliveryAddr, Is.EqualTo("123 Street"));
        }

        [Test]
        public void CollectOrder_OrderDate_Correct()
        {
            Assert.That(_order.OrderDate, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromSeconds(1))); // Uwzględnia czas wykonania testu
        }

        [Test]
        public void CollectOrder_OrderStatus_Correct()
        {
            Assert.That(_order.OrderStatus.Id, Is.EqualTo(OrderStatusEnum.New));
        }
    }
}
