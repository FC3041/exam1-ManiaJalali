using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace A7;

public class ExceptionHandler 
{
    public string ErrorMsg { get; set; }
    public readonly bool DoNotThrow;
    private string _Input;

    public string Input
    {
        get
        {
            try
            {
                if (_Input.Length < 50)
                    return _Input;
            }
            catch
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = "Caught exception in GetMethod";
            }
            return null;
        }
        set
        {
            try
            {
                if (value.Length < 50)
                    _Input = value;
            }
            catch
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = "Caught exception in SetMethod";
            }
        }
    }


    public ExceptionHandler( string input, bool causeExceptionInConstructor, bool doNotThrow=false )
    {
        DoNotThrow = doNotThrow;
        this._Input = input;
        try
        {
            if (causeExceptionInConstructor)
            {
                string test = null;
                if (test.Length > 0)
                    Console.WriteLine("test");
            }
        }
        catch
        {
            if (!DoNotThrow)
                throw;
            ErrorMsg = "Caught exception in constructor";
        }
    }
    
    public void OverflowExceptionMethod()
    {
        try
        {
            int i = int.Parse(Input);
            if (i>10)
            {
            checked
                {
                    int x = int.MaxValue;
                    x += 1;
                }
            }
        }
        catch (OverflowException e)
        {
            if (!DoNotThrow)
            {
                throw;
            }
            ErrorMsg = $"Caught exception {e.GetType()}";

        }
    }


    public void FormatExceptionMethod()
    {
        try
        {
            int i = int.Parse(Input);
        }
        catch(FormatException e)
        {
            if (!DoNotThrow)
                throw;
            ErrorMsg = $"Caught exception {e.GetType()}";
        }
    }

    public void FileNotFoundExceptionMethod()
    {
        #region 
        try
        {
            if (int.Parse(Input) == 10) return;
            else File.OpenRead(Input);
        }
        catch (FileNotFoundException e)
        {
            if (!DoNotThrow)
                throw;
            ErrorMsg = $"Caught exception {e.GetType()}";
        }
        #endregion
    }

    public void IndexOutOfRangeExceptionMethod()
    {
        #region 
        try
        {
            int[] arr = new int[1];
            int a = arr[int.Parse(Input)];
        }
        catch(IndexOutOfRangeException e)
        {
            if (!DoNotThrow)
                throw;
            ErrorMsg = $"Caught exception {e.GetType()}";
        }
        #endregion
    }

    public void OutOfMemoryExceptionMethod()
    {
        try
        {
            int[] arr = new int[int.Parse(Input)];
        }
        catch (OutOfMemoryException e)
        {
            if (!DoNotThrow)
                throw;
            ErrorMsg = $"Caught exception {e.GetType()}";
        }
    }

    public void MultiExceptionMethod()
    {
        #region
        if (int.Parse(Input) == 1) IndexOutOfRangeExceptionMethod();
        else OutOfMemoryExceptionMethod();
        #endregion
    }

    public static void ThrowIfOdd(int n)
    {
        #region 
        if (n % 2 != 0)
        {
            throw new InvalidDataException($"Error");
        }
        #endregion
    }

    public string FinallyBlockStringOut;

    public void FinallyBlockMethod(string s)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter swr = new StringWriter(sb);

        try
        {
            swr.Write("InTryBlock:");

            if (s == "beautiful")
            {
                swr.Write("beautiful:9:DoneWriting");
            }
            else if (s == "ugly") return;
            else
            {
                swr.Write(":Object reference not set to an instance of an object.");
            }
        }
        catch (NullReferenceException nre)
        {
            swr.Write($"{nre.Message}:");
            if (!DoNotThrow) throw;
        }
        finally
        {
            swr.Write(":InFinallyBlock");
            FinallyBlockStringOut = sb.ToString();
        }

        FinallyBlockStringOut += ":EndOfMethod";
    }


    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void NestedMethods()
    {
        MethodA();
    }
    private static void MethodA()
    {
        MethodB();
    }
    private static void MethodB()
    {
        MethodC();
    }
    private static void MethodC()
    {
        MethodD();
    }
    private static void MethodD()
    {
        throw new NotImplementedException();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
