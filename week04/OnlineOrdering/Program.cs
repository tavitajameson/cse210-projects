using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            Address addr1 = new Address("123 Main St", "Springfield", "IL", "USA");
            Customer cust1 = new Customer("Alice Smith", addr1);
            Order order1 = new Order(cust1);
            order1.AddProduct(new Product("Keyboard", "P001", 50, 1));
            order1.AddProduct(new Product("Mouse", "P002", 25, 2));

            Address addr2 = new Address("456 High St", "London", "LDN", "UK");
            Customer cust2 = new Customer("Bob Johnson", addr2);
            Order order2 = new Order(cust2);
            order2.AddProduct(new Product("Laptop", "P003", 800, 1));
            order2.AddProduct(new Product("Charger", "P004", 40, 1));
            order2.AddProduct(new Product("Bag", "P005", 60, 1));

            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order1.GetTotalCost()}");
            Console.WriteLine();

            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order2.GetTotalCost()}");
        }
    }
}
