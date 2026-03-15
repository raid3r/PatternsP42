using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Structural;

public interface ILibraryFacade
{
    void UseLibrary();
}

public class ComplexLibraryFacade : ILibraryFacade
{
    private readonly ComplexLibrary _complexLibrary;
    public ComplexLibraryFacade()
    {
        _complexLibrary = new ComplexLibrary();
    }
    public void UseLibrary()
    {
        _complexLibrary.MethodA();
        _complexLibrary.MethodB();
        _complexLibrary.MethodC();
        _complexLibrary.MethodA();
        _complexLibrary.MethodB();
        _complexLibrary.MethodD();
    }
}

public class ComplexLibrary2Facade : ILibraryFacade
{
    private readonly ComplexLibrary2 _complexLibrary2;
    public ComplexLibrary2Facade()
    {
        _complexLibrary2 = new ComplexLibrary2();
    }
    public void UseLibrary()
    {
        _complexLibrary2.Method3();
        _complexLibrary2.Method1();
        _complexLibrary2.Method2();
        _complexLibrary2.Method4();
    }
}



public class ClientCode
{
    private readonly ILibraryFacade _libraryFacade;
    public ClientCode(ILibraryFacade libraryFacade)
    {
        _libraryFacade = libraryFacade;
    }

    public void Execute()
    {
        Console.WriteLine("Client is using the library through the facade...");
        _libraryFacade.UseLibrary();
        Console.WriteLine("Client has finished using the library.");
    }
}


public class  ComplexLibrary
{
    public void MethodA()
    {
        Console.WriteLine("Executing MethodA from ComplexLibrary");
    }

    public void MethodB()
    {
        Console.WriteLine("Executing MethodB from ComplexLibrary");
    }

    public void MethodC()
    {
        Console.WriteLine("Executing MethodC from ComplexLibrary");
    }

    public void MethodD()
    {
        Console.WriteLine("Executing MethodD from ComplexLibrary");
    }


}

public class  ComplexLibrary2 
{
    public void Method1()
    {
        Console.WriteLine("Executing Method1 from ComplexLibrary2");
    }

    public void Method2()
    {
        Console.WriteLine("Executing Method2 from ComplexLibrary2");
    }

    public void Method3()
    {
        Console.WriteLine("Executing Method3 from ComplexLibrary2");
    }

    public void Method4()
    {
        Console.WriteLine("Executing Method4 from ComplexLibrary4");
    }
}

