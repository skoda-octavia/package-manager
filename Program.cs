﻿// See https://aka.ms/new-console-template for more information
using package_manager.Data;
using package_manager.Services;
using package_manager.UserInterface;


class Program
{
    static void Main()
    {
        const int dividerLen = 20;
        const decimal maxCashPayment = 2500;
        using var db = new AppDbContext();
        OrderService orderService = new OrderService(db, maxCashPayment);
        
        string commandDivider = new string('*', dividerLen);

        var handlers = new Dictionary<int, CommandHandler>
        {
            { 1, new CreateOrderView(orderService) },
            { 2, new StoreView(orderService) },
            { 3, new OrdersView(orderService, dividerLen) },
            { 4, new SendPackageView(orderService) },
            { 5, new FilterPackagesView(orderService, dividerLen) },
            { 6, new CloserView(orderService) },
        };

        while (true)
        {
            Console.WriteLine("1. Create order");
            Console.WriteLine("2. Send to magazine");
            Console.WriteLine("3. View orders");
            Console.WriteLine("4. Send package");
            Console.WriteLine("5. Find package");
            Console.WriteLine("6. Close package");
            Console.WriteLine("7. Exit");

            int choice = InputService.GetIntInput("Choose option: ");

            if (choice == 7)
            {
                break;
            }

            if (handlers.TryGetValue(choice, out var handler))
            {
                handler.HandleCommand();
            }
            else
            {
                Console.WriteLine("Invalid.");
            }
            Console.WriteLine(commandDivider);
        }
    }
}