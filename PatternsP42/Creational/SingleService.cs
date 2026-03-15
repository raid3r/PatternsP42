using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Creational;

public sealed class SingleService
{
    private static readonly Lazy<SingleService> _instance = new Lazy<SingleService>(() => new SingleService());

    public static SingleService Instance => _instance.Value;


    private DateTime _createdAt;

    private SingleService()
    {


        _createdAt = DateTime.Now;
    }
    
    public void DoSomething()
    {
        Console.WriteLine($"Doing something. Service created: {_createdAt.ToString("yyyy-MM-dd HH:mm:ss")}");
    }
}
