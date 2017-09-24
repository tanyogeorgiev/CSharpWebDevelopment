using ShopHierarchy.Data;
using System;
using System.Linq;

namespace ShopHierarchy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new MyDbContext())
            {
                PrepareDatabase(db);
                SaveSalesman(db);
                SaveItems(db);
                ProcessCommands(db);
                // PrintSalesmanWithCustomers(db);
                // PrintCustomersWithOrdersReviews(db);
                // PrintCustomersOrdersAndReviews(db);
                // PrintCustomerData(db);
                // PrintOrdersWithMoreThanOneItem(db);


            }
        }


        private static void PrepareDatabase(MyDbContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }


        private static void SaveSalesman(MyDbContext db)
        {
            var salesmen = Console.ReadLine().Split(';');

            foreach (var salesman in salesmen)
            {
                db.Salesmans.Add(new Salesman { Name = salesman });


            }
            db.SaveChanges();
        }


        private static void ProcessCommands(MyDbContext db)
        {
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }
                var parts = line.Split('-');
                var command = parts[0];
                var argument = parts[1];

                switch (command)
                {
                    case "register":
                        RegisterCustomer(db, argument);
                        break;
                    case "order":
                        SaveOrder(db, argument);
                        break;
                    case "review":
                        SaveReview(db, argument);
                        break;
                    default:
                        break;
                }

            }
        }



        private static void RegisterCustomer(MyDbContext db, string argument)
        {
            var parts = argument.Split(';');
            var customerName = parts[0];
            var salesmanId = int.Parse(parts[1]);

            db.Add(new Customer
            {
                Name = customerName,
                SalesmanId = salesmanId
            });
            db.SaveChanges();
        }



        private static void PrintSalesmanWithCustomers(MyDbContext db)
        {
            var salesmenData = db
                .Salesmans
                .Select(sm => new
                {
                    sm.Name,
                    Customers = sm.Customers.Count
                })
                .OrderByDescending(s => s.Customers)
                .ThenBy(s => s.Name)
                .ToList();

            foreach (var salesman in salesmenData)
            {
                Console.WriteLine($"{salesman.Name} - {salesman.Customers} customers");
            }

        }


        private static void SaveReview(MyDbContext db, string argument)
        {
            var parts = argument.Split(';');

            var itemId = int.Parse(parts[1]);


            var customerId = int.Parse(parts[0]);
            db.Add(new Review
            {
                CustomerId = customerId,
                ItemId = itemId
            });
            db.SaveChanges();
        }

        private static void SaveOrder(MyDbContext db, string argument)
        {
            var parts = argument.Split(';');

            var customerId = int.Parse(parts[0]);

            var order = new Order { CustomerId = customerId };

            for (int i = 1; i < parts.Length; i++)
            {
                var itemId = int.Parse(parts[i]);
                order.Items.Add(new OrderItems
                {
                    ItemId = itemId
                });
            }

            db.Add(order);
            db.SaveChanges();
        }



        private static void PrintCustomersWithOrdersReviews(MyDbContext db)
        {
            var customers = db.Customers.Select(c => new
            {
                c.Name,
                Orders = c.Orders.Count,
                Reviews = c.Reviews.Count,

            })
            .OrderByDescending(o => o.Orders)
            .ThenBy(r => r.Reviews)
            .ToList();

            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Name}");
                Console.WriteLine($"Orders: {customer.Orders}");
                Console.WriteLine($"Reviews: {customer.Reviews}");


            }
        }
        private static void SaveItems(MyDbContext db)
        {
            while (true)
            {
                var line = Console.ReadLine();

                if (line == "END")
                {

                    break;
                }

                var parts = line.Split(';');
                var itemName = parts[0];
                var itemPrice = decimal.Parse(parts[1]);

                db.Add(new Item
                {
                    Name = itemName,
                    Price = itemPrice
                });

            }

            db.SaveChanges();
        }


        private static void PrintCustomersOrdersAndReviews(MyDbContext db)
        {
            var customerId = int.Parse(Console.ReadLine());

            var customerData = db.Customers
                .Where(w => w.Id == customerId)
                .Select(s => new
                {
                    Orders = s.Orders.Select(o => new
                    {
                        Id = o.Id,
                        ItemCount = o.Items.Count
                    })
                   .OrderBy(o => o.Id),
                    Reviews = s.Reviews.Count
                }).FirstOrDefault();

            foreach (var order in customerData.Orders)
            {
                Console.WriteLine($"order {order.Id}: {order.ItemCount} items ");
            }

            Console.WriteLine($"Reviews: {customerData.Reviews}");
        }



        private static void PrintCustomerData(MyDbContext db)
        {
            var customerId = int.Parse(Console.ReadLine());

            var customerData = db.Customers
                                .Where(w => w.Id == customerId)
                                .Select(c => new
                                {
                                    c.Name,
                                    Orders = c.Orders.Count,
                                    Revews = c.Reviews.Count,
                                    Salesman = c.Salesman.Name
                                })
                                .FirstOrDefault();

            Console.WriteLine($"Customer: {customerData.Name}");
            Console.WriteLine($"Orders cunt: {customerData.Orders}");
            Console.WriteLine($"Reviews count: {customerData.Revews}");
            Console.WriteLine($"Salesman: {customerData.Salesman}");
        }


        private static void PrintOrdersWithMoreThanOneItem(MyDbContext db)
        {

            var customerId = int.Parse(Console.ReadLine());

            var orders = db.Orders
                .Where(o => o.Items.Count > 1 && o.CustomerId == customerId)
                .Count();

            Console.WriteLine($"Orders: {orders}");
        }

    }
}
