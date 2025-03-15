using package_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace package_manager.UserInterface
{
    public static class InputService
    {
        public static readonly string InvalidComunicate = "Invalid value, try again.";

        public static string GetInput(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }
            }
        }

        public static bool GetInputBool(string prompt)
        {
            string input = GetInput(prompt + "[yes]");
            if (input.ToLower() == "yes")
            {
                return true;
            }
            return false;
        }

        public static int GetIntInput(string prompt)
        {
            Console.Write(prompt);
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine(InvalidComunicate);
                Console.Write(prompt);
            }
            return result;
        }

        public static decimal GetDecimalInput(string prompt)
        {
            Console.Write(prompt);
            decimal result;
            while (!decimal.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine(InvalidComunicate);
                Console.Write(prompt);
            }
            return result;
        }

        public static T GetEnumInput<T>(string prompt) where T : struct, Enum
        {
            while (true)
            {
                Console.WriteLine(prompt);
                foreach (var value in Enum.GetValues(typeof(T)))
                {
                    Console.WriteLine($"* {value}");
                }

                Console.Write("Choose value: ");
                if (Enum.TryParse<T>(Console.ReadLine(), true, out var result))
                {
                    return result;
                }

                Console.WriteLine(InvalidComunicate);
            }
        }

        public static Order CollectOrder()
        {
            string productName = InputService.GetInput("Product name: ");
            decimal total = InputService.GetDecimalInput("Total price: ");
            CustomerTypeEnum customerType = InputService.GetEnumInput<CustomerTypeEnum>("Client type: ");
            PaymentMethodEnum paymentMethod = InputService.GetEnumInput<PaymentMethodEnum>("Payment method: ");
            DeliveryMethodEnum delivery = InputService.GetEnumInput<DeliveryMethodEnum>("Delivery method: ");
            string address = InputService.GetInput("Delivery address: ");

            return new Order()
            {
                CustomerType = new CustomerType(customerType),
                PaymentMethod = new PaymentMethod(paymentMethod),
                ProductName = productName,
                Price = total,
                DeliveryAddr = address,
                OrderDate = DateTime.Now,
                DeliveryMethod = new DeliveryMethod(delivery),
                OrderStatus = new OrderStatus(OrderStatusEnum.New)
            };
        }

        public static string? GetFilterValue(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? null : input;
        }

        public static DateTime? GetDateFilter(string prompt)
        {
            Console.Write(prompt);
            if (DateTime.TryParse(Console.ReadLine(), out var date))
            {
                return date;
            }
            return null;
        }

        public static decimal? GetDecimalFilter(string prompt)
        {
            Console.Write(prompt);
            if (decimal.TryParse(Console.ReadLine(), out var value))
            {
                return value;
            }
            return null;
        }

        public static int? GetIntFilter(string prompt)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out var value))
            {
                return value;
            }
            return null;
        }

        public static T? GetEnumFilter<T>(string prompt) where T : struct, Enum
        {
            Console.Write(prompt);
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                Console.WriteLine($"* {value}");
            }
            var input = Console.ReadLine();
            if (Enum.TryParse<T>(input, true, out var result))
            {
                return result;
            }
            return null;
        }
    }
}
