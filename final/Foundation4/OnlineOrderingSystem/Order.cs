using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;
        foreach (var product in _products)
        {
            totalCost += product.GetTotalCost();
        }
        decimal shippingCost = _customer.LivesInUSA() ? 5 : 35;
        return totalCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder packingLabel = new StringBuilder();
        foreach (var product in _products)
        {
            packingLabel.AppendLine($"{product.Name} ({product.ProductId})");
        }
        return packingLabel.ToString();
    }

    public string GetShippingLabel()
    {
        return $"{_customer.Name}\n{_customer.Address}";
    }
}
