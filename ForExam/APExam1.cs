using System.Text;
using System;
using System.ComponentModel;

namespace E1;

public class TwoNumbers : IComparable<TwoNumbers>, IComparable<int>, IComparable<string>, INotifyPropertyChanged
{

    private int _first;
    private int _second;

    public event PropertyChangedEventHandler? PropertyChanged;

    public int Sum => First + Second;

    public int First
    {
        get => _first;
        set
        {
            if (value >= 0) 
            {
                _first = value;
                OnPropertyChanged(nameof(First));
            }
        }
    }

    public int Second
    {
        get => _second;
        set
        {
            if (value >= 0)
            {
                _second = value;
                OnPropertyChanged(nameof(Second));
            }
        }
    }


    public TwoNumbers(int a, int b)
    {
        First = a;
        Second = b;
    }

    public int GetFirst()
    {
        return First;
    }

    public int GetSecond()
    {
        return Second;
    }

    public static TwoNumbers Parse(string s)
    {
        try
        {
            string[] parts = s.Split(" ");
            if (parts.Length != 2) throw new IndexOutOfRangeException(); 
            int FirstNumber = int.Parse(s.Split(" ")[0]);
            int SecondNumber = int.Parse(s.Split(" ")[1]);
            return new TwoNumbers(FirstNumber, SecondNumber);
        }
        catch (FormatException)
        {
            throw new InvalidDataException();
        }
        // catch (IndexOutOfRangeException)
        // {
        //     throw;
        // }
    }
    public static TwoNumbers operator +(TwoNumbers tn1, TwoNumbers tn2)
    {
        return new TwoNumbers(tn1.First + tn2.First, tn1.Second + tn2.Second);
    }

    public static bool operator ==(TwoNumbers tn1, TwoNumbers tn2)
    {
        return (tn1.First == tn2.First && tn1.Second == tn2.Second);
    }
    public static bool operator !=(TwoNumbers tn1, TwoNumbers tn2)
    {
        if (tn1.First == tn2.First && tn1.Second == tn2.Second) return false;
        else return true;
    }
    
    public static bool operator >(TwoNumbers tn1, TwoNumbers tn2)
    {
        return ((tn1.First + tn1.Second) > (tn2.First + tn2.Second));
    }

    public static bool operator <(TwoNumbers tn1, TwoNumbers tn2)
    {
        return ((tn1.First + tn1.Second) < (tn2.First + tn2.Second));
    }

    public override bool Equals(object tn1) 
    {
        if (tn1 is not TwoNumbers other) return false;
        // if (!(tn1 is TwoNumbers)) return false;
        // TwoNumbers other = (TwoNumbers)tn1;

        return First == other.First && Second == other.Second;    
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(First, Second);
    }

    public override string ToString()
    {
        return $"{First} {Second}";
    }

    public int CompareTo(TwoNumbers other)
    {
        return Sum.CompareTo(other.Sum);
    }

    public int CompareTo(int a)
    {
        return Sum.CompareTo(a);
    }

    public int CompareTo(string s)
    {
        TwoNumbers tn1 = Parse(s);
        return Sum.CompareTo(tn1.Sum);
    }
    // public event Action SumBecameEven;
    // if ((this.Sum / 2) == 0) 
    // {
    //     SumBecameEven?.Invoke();
    // }
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public event EventHandler SumBecameEven;
}

public class FirstComparer : IComparer<TwoNumbers>
{
    public int Compare(TwoNumbers tn1, TwoNumbers tn2)
    {
        return tn1.First.CompareTo(tn2.First);
    }
}

public class SecondComparer : IComparer<TwoNumbers>
{
    public int Compare(TwoNumbers tn1, TwoNumbers tn2)
    {
        return tn1.Second.CompareTo(tn2.Second);
    }
}

public class SumComparer : IComparer<TwoNumbers>
{
    public int Compare(TwoNumbers tn1, TwoNumbers tn2)
    {
        return tn1.Sum.CompareTo(tn2.Sum);
    }
}

public class TwoNumbersComparers
{
    public static FirstComparer FirstComparer = new FirstComparer();
    public static SecondComparer SecondComparer = new SecondComparer();
    public static SumComparer SumComparer = new SumComparer();
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
