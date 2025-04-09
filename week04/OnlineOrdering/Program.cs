using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Customer customer1 = new Customer("Alice Johnson", new Address("123 Main St", "New York", "NY", "USA"));
        Customer customer2 = new Customer("Bob Smith", new Address("456 Maple Ave", "Toronto", "ON", "Canada"));

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "A123", 999.99m, 1));
        order1.AddProduct(new Product("Mouse", "B456", 25.99m, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Headphones", "C789", 79.99m, 1));
        order2.AddProduct(new Product("Keyboard", "D012", 49.99m, 1));

        List<Order> orders = new List<Order> { order1, order2 };

        for (int i = 0; i < orders.Count; i++)
        {
            Console.WriteLine($"Order {i + 1}:");
            Console.WriteLine("Packing Label:\n" + orders[i].GeneratePackingLabel());
            Console.WriteLine("Shipping Label:\n" + orders[i].GenerateShippingLabel());
            Console.WriteLine($"Total Price: ${orders[i].CalculateTotalPrice():F2}\n");
            Console.WriteLine(new string('-', 40));
        }
    }
}