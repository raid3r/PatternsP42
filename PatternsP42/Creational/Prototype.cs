using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Creational;


class Circle: ICloneable
{


    public double Radius { get; set; }
    public string Color { get; set; }

    public Circle(double radius, string color)
    {
        Radius = radius;
        Color = color;
    }

    public Circle(Circle other)
    {
        Radius = other.Radius;
        Color = other.Color;
    }

    public object Clone()
    {
        return new Circle(this);
    }
}




