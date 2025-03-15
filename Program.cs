// See https://aka.ms/new-console-template for more information
using package_manager.Data;
using package_manager.Services;
using package_manager.UserInterface;


class Program
{
    static void Main()
    {

        using var db = new AppDbContext();
        OrderService orderService = new OrderService(db);
        const int dividerLen = 20;
        string commandDivider = new string('*', dividerLen);

        var handlers = new Dictionary<int, CommandHandler>
        {
            { 1, new CreateOrderView(orderService) },
            { 2, new StoreView(orderService) },
            { 3, new OrdersViewer(orderService, dividerLen) },
            { 4, new SendPackageView(orderService) },
            { 5, new FilterPackagesView(orderService, dividerLen) }
        };

        Console.WriteLine($"Database path: {db.DbPath}.");

        foreach (var e in db.OrderStatuses)
        {
            Console.WriteLine(e.Name);
        }

        while (true)
        {
            Console.WriteLine("1. Create order");
            Console.WriteLine("2. Send to magazine");
            Console.WriteLine("3. View orders");
            Console.WriteLine("4. Send package");
            Console.WriteLine("5. Find package");
            Console.WriteLine("6. Exit");

            int choice = InputService.GetIntInput("Choose option: ");

            if (choice == 6)
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