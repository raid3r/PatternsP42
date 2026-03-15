using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Structural;

public interface IPizza
{
    string GetDescription();
    decimal GetCost();
}

public class Pizza : IPizza
{
    public virtual string GetDescription()
    {
        return "Basic pizza";
    }

    public virtual decimal GetCost()
    {
        return 5.00m; // Base cost of a pizza
    }
}

public class PizzaDecorator : IPizza
{
    protected readonly IPizza _pizza;
    protected readonly string _description;
    protected readonly decimal _price;
    public PizzaDecorator(IPizza pizza, string description, decimal price)
    {
        _pizza = pizza;
        _description = description;
        _price = price;
    }
    public virtual string GetDescription()
    {
        return _pizza.GetDescription() + " +" + _description;
    }
    public virtual decimal GetCost() 
    {
        return _pizza.GetCost() + _price;
    }
}


public class  DiscountPizzaDecorator: IPizza
{
    public DiscountPizzaDecorator(IPizza pizza, decimal discount)
    {
        _pizza = pizza;
        _discount = discount / 100; // Convert percentage to decimal
    }
    protected readonly IPizza _pizza;
    protected readonly decimal _discount;

    public virtual string GetDescription()
    {
        return _pizza.GetDescription() + " with discount " + (_discount * 100) + "%";
    }
    public virtual decimal GetCost()
    {
        return _pizza.GetCost() * (1 - _discount);
    }
}


//public class PizzaWithCheese: Pizza
//{
//    public override string GetDescription()
//    {
//        return "Basic pizza + with cheese";
//    }

//    public override decimal GetCost()
//    {
//        return 6.00m; // Base cost of a pizza with cheese
//    }
//}

//public class PizzaWithPepperoni : Pizza
//{
//    public override string GetDescription()
//    {
//        return "Basic pizza with pepperoni";
//    }

//    public override decimal GetCost()
//    {
//        return 7.00m; // Base cost of a pizza with pepperoni
//    }
//}