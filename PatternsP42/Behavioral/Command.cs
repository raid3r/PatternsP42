using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Behavioral;


public class CommandClientCode
{
    public void Run()
    {
        
        var light = new Light();



        //// Включити світло, режим блимання включений
        //light.BlinkState = true;
        //light.On();
        //// Виключити світло, режим блимання вимкнений
        //light.BlinkState = false;
        //light.Off();
        //// Включити світло, режим блимання вимкнений
        //light.On();
        //light.Off();
        //// Виключити світло, режим блимання включений
        //light.BlinkState = true;
        //light.Off();

        var commands = new List<ICommand>
        {
            new LightCommand(light) { IsOn = true, BlinkState = true },
            new LightCommand(light) { IsOn = false, BlinkState = false },
            new LightCommand(light) { IsOn = true, BlinkState = false },
            new LightCommand(light) { IsOn = false, BlinkState = true }
        };


        foreach (var command in commands)
        {
            command.Execute();
            Thread.Sleep(2000); // Додайте затримку для кращого візуального ефекту
        }






    }
}

public interface ICommand
{
    void Execute();
}

public class LightCommand : ICommand
{
    public bool BlinkState { get; set; } = false;
    public bool IsOn { get; set; } = false;

    private readonly Light _light;
    public LightCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        if (IsOn) {
            _light.BlinkState = BlinkState;
            _light.On();
        } else {
            _light.BlinkState = BlinkState;
            _light.Off();
        }
    }
}



public class Light
{
    public bool BlinkState { get; set; } = false;


    public void On() { 
        Console.WriteLine($"Light is ON. Blink mode: {(BlinkState ? "ON": "OFF")}");
    }
    public void Off() { 
        Console.WriteLine($"Light is OFF. Blink mode: {(BlinkState ? "ON": "OFF")}");
    }
}
