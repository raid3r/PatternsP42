using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Behavioral;


public class StateClientCode
{
    public void Run()
    {
        var box = new Box();
        box.Open();
        box.PutIn();
        box.Close();
        try
        {
            box.PutIn(); // викличе помилку, оскільки коробка закрита
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}


public interface IBoxState
{
    void Open(Box box);
    void Close(Box box);
    void PutIn(Box box);
    void TakeOut(Box box);
}

public class OpenState : IBoxState
{
    public void Open(Box box)
    {
        throw new InvalidOperationException("Box is already open.");
    }
    public void Close(Box box)
    {
        box.IsOpen = false;
        box.SetState(new ClosedState());
    }
    public void PutIn(Box box)
    {
        if (!box.IsEmpty)
        {
            throw new InvalidOperationException("Box is already full.");
        }
        box.IsEmpty = false;
    }
    public void TakeOut(Box box)
    {
        if (box.IsEmpty)
        {
            throw new InvalidOperationException("Box is already empty.");
        }
        box.IsEmpty = true;
    }
}

public class ClosedState : IBoxState
{
    public void Open(Box box)
    {
        box.IsOpen = true;
        box.SetState(new OpenState());
    }
    public void Close(Box box)
    {
        throw new InvalidOperationException("Box is already closed.");
    }
    public void PutIn(Box box)
    {
        throw new InvalidOperationException("Box must be open to put something in.");
    }
    public void TakeOut(Box box)
    {
        throw new InvalidOperationException("Box must be open to take something out.");
    }
}



// коробока відкрита, закрита
public class Box
{
    private IBoxState _state;

    public void SetState(IBoxState state)
    {
        _state = state;
    }

    public Box()
    {
        _state = new ClosedState();
        IsOpen = false;
        IsEmpty = true;
    }

    public bool IsOpen { get; set; }
    public bool IsEmpty { get; set; }

    public void Open()
    {
        _state.Open(this);
    }

    public void Close()
    {
        _state.Close(this); 
    }

    public void PutIn()
    {
        _state.PutIn(this);
    }
    public void TakeOut()
    {
        _state.TakeOut(this);
    }
}

