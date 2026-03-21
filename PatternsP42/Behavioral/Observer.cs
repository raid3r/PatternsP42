using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Behavioral;




public class ObserverClientCode
{
    public void NotifyBySms(string message)
    {
        // відправити SMS повідомлення
        Console.WriteLine($"SMS notification: {message}");
    }

    public void NotifyByEmail(string message)
    {
        // відправити email повідомлення
        Console.WriteLine($"Email notification: {message}");
    }

    public void Run()
    {
        
        var stock = new Stock();
        var smsNotify = new SmsNotify();
        stock.ProductAdded += smsNotify.NotifyProductAdded;
        stock.ProductAdded += (name, price) => NotifyByEmail($"New product added: {name} with price {price}");
        stock.ProductAdded += (name, price) => Console.WriteLine($"Console notification: New product added: {name} with price {price}");


        var productName = "Laptop";
        var productPrice = 999.99m;
        stock.AddProduct(productName, productPrice);

        stock.ProductAdded -= smsNotify.NotifyProductAdded;

        var productName2 = "Smartphone";
        var productPrice2 = 499.99m;
        stock.AddProduct(productName2, productPrice2);

        



    }
}

public class  SmsNotify
{
    // Action<string, decimal> 
    public void NotifyProductAdded(string name, decimal price)
    {
        Console.WriteLine($"SMS notification: New product added: {name} with price {price}");
    }
}


public class Stock
{
    public event Action<string, decimal> ProductAdded;

    public void AddProduct(string name, decimal price)
    {
        // додати товар до складу
        Console.WriteLine($"Product {name} added to stock with price {price}");
        // повідомити підписників про додавання товару
        ProductAdded?.Invoke(name, price);
    }


}