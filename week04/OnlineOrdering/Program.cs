using System;
using System.Collections.Generic;

class Address
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string Country { get; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country.ToLower() == "usa";
    }

    public override string ToString()
    {
        return $"{Street}\n{City}, {State}\n{Country}";
    }
}

class Customer
{
    public string Name { get; }
    public Address Address { get; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool IsInUSA()
    {
        return Address.IsInUSA();
    }
}

class Product
{
    public string Name { get; }
    public string ProductId { get; }
    public decimal Price { get; }
    public int Quantity { get; }

    public Product(string name, string productId, decimal price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    public decimal CalculateTotalCost()
    {
        return Price * Quantity;
    }
}

class Order
{
    private List<Product> products = new List<Product>();
    public Customer Customer { get; }

    public Order(Customer customer)
    {
        Customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal CalculateTotalPrice()
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.CalculateTotalCost();
        }
        decimal shippingCost = Customer.IsInUSA() ? 5 : 35;
        return total + shippingCost;
    }

    public string GeneratePackingLabel()
    {
        string label = "";
        foreach (var product in products)
        {
            label += $"{product.Name} (ID: {product.ProductId})\n";
        }
        return label;
    }

    public string GenerateShippingLabel()
    {
        return $"{Customer.Name}\n{Customer.Address}";
    }
}

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
