using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Structural;

public interface ICompanyElement
{
    string Name { get; }
    void Display(int indent = 0);
    public void AddChild(ICompanyElement child);
    public List<ICompanyElement> Children { get; }
    public decimal GetSalary();
}

public class AbstractCompanyElement : ICompanyElement
{
    public string Name { get; set; }
    public List<ICompanyElement> Children { get; set; } = new List<ICompanyElement>();
    public AbstractCompanyElement(string name)
    {
        Name = name;
    }
    public void AddChild(ICompanyElement child)
    {
        Children.Add(child);
    }
    public void Display(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + Name + " - Salary: " + GetSalary());
        foreach (var child in Children)
        {
            child.Display(indent + 2);
        }
    }
    public virtual decimal GetSalary()
    {
        return 0;
    }
}


public class Employee: AbstractCompanyElement
{
    public decimal Salary { get; set; }
    public Employee(string name, decimal salary) : base(name + " " + "Employee")
    {
        Salary = salary;
    }
    public override decimal GetSalary()
    {
        return Salary;
    }
}

public class Manager: AbstractCompanyElement
{
    public decimal Salary { get; set; }
    public Manager(string name, decimal salary) : base(name + " " + "Manager")
    {
        Salary = salary;
    }
    public override decimal GetSalary()
    {
        return Salary;
    }

}

public class Department: AbstractCompanyElement
{
    public Department(string name) : base(name + " " + "Department") { }

    public override decimal GetSalary()
    {
        decimal totalSalary = 0;
        foreach (var child in Children)
        {
            totalSalary += child.GetSalary();
        }
        return totalSalary;
    }
}



//class CompanyElement
//{
//    public string Name { get; set; }
//    public List<CompanyElement> Children { get; set; } = new List<CompanyElement>();
//    public CompanyElement(string name)
//    {
//        Name = name;
//    }
//    public void AddChild(CompanyElement child)
//    {
//        Children.Add(child);
//    }

//    public void Display(int indent = 0)
//    {
//        Console.WriteLine(new string(' ', indent) + Name);
//        foreach (var child in Children)
//        {
//            child.Display(indent + 2);
//        }
//    }
//}

/* 
 * Структура компанія
 * 
 *            Директор
 * Заступник директора  Заступник директора
 * Бухгалтерія       Відділ продажів Відділ розробки Відділ маркетингу
 *                                                  Відділення 1 Відділення 2 Відділення 3
 * 
 * 
 * Елемент
 * - Назва
 * - Дочерні елементи
 * 
 * 
 * 
 * 
 * 
 * 
 */






