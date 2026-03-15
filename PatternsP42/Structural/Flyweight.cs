using PatternsP42.Creational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Structural;






public class Item
{
    public int Y { get; set; }
    public int X { get; set; }
    public SomeResourse Resourse { get; set; }
}

public class SomeResourse
{
    public string Name { get; set; }
    public byte[] Data { get; set; }
}


public class ResourseContext
{
    private static readonly Lazy<ResourseContext> _instance = new Lazy<ResourseContext>(() => {
        var context = new ResourseContext();
        //context.InitializeResourses();
        return context;
        });

    public static ResourseContext Instance => _instance.Value;


    private Dictionary<string, SomeResourse> _resourses = new Dictionary<string, SomeResourse>();
    //private void InitializeResourses()
    //{
    //    var resourse1 = new SomeResourse { Name = "Resourse1", Data = new byte[] { 1, 2, 3 } };
    //    var resourse2 = new SomeResourse { Name = "Resourse2", Data = new byte[] { 4, 5, 6 } };
    //    // Store the resources in a dictionary for reuse
    //    _resourses["Resourse1"] = resourse1;
    //    _resourses["Resourse2"] = resourse2;
    //}

    public SomeResourse GetResourse(string name)
    {
        if (_resourses.ContainsKey(name))
        {
            return _resourses[name];
        }
        else {
            // lazy loading of resources if not already loaded
            if (name == "Resourse1")
            {
                var resourse1 = new SomeResourse { Name = "Resourse1", Data = new byte[] { 1, 2, 3 } };
                _resourses["Resourse1"] = resourse1;
                return resourse1;
            }
            else if (name == "Resourse2")
            {
                var resourse2 = new SomeResourse { Name = "Resourse2", Data = new byte[] { 4, 5, 6 } };
                _resourses["Resourse2"] = resourse2;
                return resourse2;
            }


        }


        if (_resourses.TryGetValue(name, out var resourse))
        {
            return resourse;
        }



        throw new Exception($"Resource with name {name} not found.");
    }
}


public class ClientCodeWithResourses
{

    public void UseResources()
    {
        var items = new List<Item>();

        items.Add(new Item { 
            X = 1, 
            Y = 1, 
            Resourse = ResourseContext.Instance.GetResourse("Resourse1")
        });
        items.Add(new Item { X = 1, Y = 1, Resourse = ResourseContext.Instance.GetResourse("Resourse1") });
        items.Add(new Item { X = 1, Y = 1, Resourse = ResourseContext.Instance.GetResourse("Resourse2") });
        items.Add(new Item { X = 1, Y = 1, Resourse = ResourseContext.Instance.GetResourse("Resourse2") });

    }

}
