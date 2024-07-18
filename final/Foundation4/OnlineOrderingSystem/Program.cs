using System;

class Program
{
    static void Main(string[] args)
    {
        var address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        var address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        var customer1 = new Customer("John Doe", address1);
        var customer2 = new Customer("Jane Smith", address2);

        var product1 = new Product("Laptop", "A123", 1000, 1);
        var product2 = new Product("Mouse", "B456", 50, 2);
        var product3 = new Product("Keyboard", "C789", 75, 1);
        var product4 = new Product("Monitor", "D101", 300, 1);

        var order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        var order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        Console.WriteLine("Order 1:");
        Console.WriteLine($"Packing Label:\n{order1.GetPackingLabel()}");
        Console.WriteLine($"Shipping Label:\n{order1.GetShippingLabel()}");
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}");

        Console.WriteLine("\nOrder 2:");
        Console.WriteLine($"Packing Label:\n{order2.GetPackingLabel()}");
        Console.WriteLine($"Shipping Label:\n{order2.GetShippingLabel()}");
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}");
    }
}
