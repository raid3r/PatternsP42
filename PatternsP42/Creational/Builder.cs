using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Creational;


public interface IWheel
{
    void Rotate();
}

public interface IEngine
{
    void Start();
}

public interface IExtraOption
{
    void Use();
}

public class Wheel16R : IWheel
{
    public void Rotate()
    {
        Console.WriteLine("Wheel 16R is rotating.");
    }
}

public class Wheel18R : IWheel
{
    public void Rotate()
    {
        Console.WriteLine("Wheel 18R is rotating.");
    }
}

public class PetrolEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Petrol engine is starting.");
    }
}

public class ElectricEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Electric engine is starting.");
    }
}

public class LeatherSeats : IExtraOption
{
    public void Use()
    {
        Console.WriteLine("Leather seats are being used.");
    }
}

public class Sunroof : IExtraOption
{
    public void Use()
    {
        Console.WriteLine("Sunroof is opening.");
    }
}




public class Car
{

    public IWheel? Wheel { get; set; }
    public IEngine? Engine { get; set; }
    public List<IExtraOption> ExtraOptions { get; set; } = new List<IExtraOption>();

    public void PrintDetails()
    {
        Console.WriteLine($"Car details: Wheel - {(Wheel != null ? "Present" : "Missing")}, Engine - {(Engine != null ? "Present" : "Missing")}");
        Wheel?.Rotate();
        Engine?.Start();
        ExtraOptions.ForEach(option => option.Use());
    }
}



public abstract class CarBuilder
{
    protected Car _car = new Car();
    public abstract void BuildWheel();
    public abstract void BuildEngine();
    public abstract void BuildExtraOptions();
    public virtual Car GetCar()
    {
        return _car;
    }
}


public class ElectricCarBuilder : CarBuilder
{
    
    public override void BuildWheel()
    {
        _car.Wheel = new Wheel18R();
    }
    public override void BuildEngine()
    {
        _car.Engine = new ElectricEngine();
    }
    public override void BuildExtraOptions()
    {
        _car.ExtraOptions.Add(new LeatherSeats());
        _car.ExtraOptions.Add(new Sunroof());
    }
    
}

public class  StandardCarBuilder: CarBuilder
{
    public override void BuildWheel()
    {
        _car.Wheel = new Wheel16R();
    }
    public override void BuildEngine()
    {
        _car.Engine = new PetrolEngine();
    }
    public override void BuildExtraOptions()
    {
        // No extra options for standard car
    }
}