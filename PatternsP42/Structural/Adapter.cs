using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Structural;

public interface IEngine
{
    void Start();
    void Stop();
}

public class PetrolEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Petrol engine is starting.");
    }
    public void Stop()
    {
        Console.WriteLine("Petrol engine is stopping.");
    }
}

public class ElectricEngine
{
    public void On()
    {
        Console.WriteLine("Electric engine is ON");
    }

    public void Off()
    {
        Console.WriteLine("Electric engine is OFF");
    }
}

public class ElectricEngineAdapter : IEngine
{
    private readonly ElectricEngine _electricEngine;
    public ElectricEngineAdapter(ElectricEngine electricEngine)
    {
        _electricEngine = electricEngine;
    }
    
    public void Start()
    {
        _electricEngine.On();
    }
    public void Stop()
    {
        _electricEngine.Off();
    }
}


public class Car
{
    public IEngine Engine { get; set; }

    virtual public void Use()
    {
        Engine.Start();
        Console.WriteLine("Car is being used.");
        Engine.Stop();
    }

}

