using System.ComponentModel;
using System.Text;

namespace Exam1;

public class Q1_Add
{
    public int a{get;set;}
    public int b{get;set;}
    public Q1_Add(int _a, int _b)
    {
        this.a = _a;
        this.b = _b;
    }
    public static int Add(int a , int b)
    {
        return a + b;
    }
}

public class Basics
{
    public int a{get;set;}
    public int b{get;set;}
    public Basics(int _a, int _b)
    {
        this.a = _a;
        this.b = _b;
    }
    public static void Q2MultiplyAndReset(ref int a ,ref int b)
    {
        a *= b;
        b = 1;
    }

    // public static void Q5TryCatchFinally(bool a, List<string> list, bool b)
    // {
        
    // }

    // public static string Q5TryCatchFinally(bool a, List<string> list)
    // {
    //     StringBuilder sb = new StringBuilder();
    //     StringWriter swr = new StringWriter(sb);

    //     try
    //     {
    //         swr.Write("When shouldThrow is ");

    //         if (a == false)
    //         {
    //             swr.Write("false");
    //             throw new InvalidOperationException();
    //         }
    //         else if (a == true)
    //         {
    //             swr.Write("true");
    //             throw new InvalidDataException();
    //         }
    //         swr.Write(", expect Try →");
    //     }
    //     catch (InvalidOperationException)
    //     {
    //         swr.Write(" AfterTry → ");
    //     }
    //     catch (InvalidDataException)
    //     {
    //         swr.Write(" Catch → ");
    //     }
    //     finally
    //     {
    //         swr.Write("Finally");
    //     }
    //     return swr.ToString();
    // }
}

public class Q4Person
{
    public string Name{get;set;}
    public int Age{get;set;}
    public Q4Person(string _name, int _age)
    {
        this.Name = _name;
        this.Age = _age;
    }

    public string Introduce()
    {
        return $"Hello, my name is {Name} and I am {Age} years old.";
    }
}

public class Q6Temperature : INotifyPropertyChanged
{
    private double cel = -100;
    private double fah = -100;
    public double Fahrenheit
    {
        get
        {
            if (fah == -100) return (cel * 1.8) + 32;
            else return fah;
        }
        set
        {
            fah = value;
        }
    }
    public double Celsius
    {
        get
        {
            if (cel == -100) return (fah - 32) * 5 / 9;
            else return cel;
        }
        set
        {
            cel = value;            
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public interface IShape
{
    public double GetArea();
    public double GetPerimeter();
}

public class Q7Circle : IShape
{
    public double radius{get;set;}

    public Q7Circle(double r)
    {
        radius = r;
    }

    public double GetArea()
    {
        return radius * radius * Math.PI;
    }

    public double GetPerimeter()
    {
        return radius * 2 * Math.PI;
    }
}
public class Q7Rectangle : IShape
{
    public double a {get;set;}
    public double b {get;set;}

    public Q7Rectangle(double length, double arz)
    {
        a = arz;
        b = length;
    }

    public double GetArea()
    {
        return a * b;
    }

    public double GetPerimeter()
    {
        return (a + b) * 2;
    }
}

public class ShapeUtils
{
    public static double Q7TotalArea(IShape[] ishape)
    {
        double area = 0;
        foreach(var item in ishape)
        {
            area += item.GetArea();
        }
        return area;
    }
}

public struct Type1
{
    public int Count{get; set;}
}
public struct Type2
{
    public int Count{get;set;}
}