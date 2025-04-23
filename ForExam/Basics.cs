using System;
using System.IO;

namespace E1
{
    public static partial class Basics
    {
        public static int CalculateSum(string expression)
        {
            // if (string.IsNullOrWhiteSpace(expression)) 
            //     throw new InvalidDataException("Expression cannot be empty!");

            // if (!expression.Contains("+")) 
            //     throw new InvalidDataException("Expression must contain '+' operator!");

            string[] string_numbers = expression.Split("+");
            int sum = 0;

            foreach (string item in string_numbers)
            {
                if (string.IsNullOrWhiteSpace(item))
                    throw new InvalidDataException();

                if (!int.TryParse(item, out int number))
                    throw new FormatException();

                sum += number; 
            }

            return sum;
        }


        public static bool TryCalculateSum(string expression, out int value)
        {
            #region TODO
            // value = 0;
            // try
            // {
            //     string[] string_numbers = expression.Split("+");
            //     foreach (string item in string_numbers)
            //     {
            //         if (!int.TryParse(item, out int number))
            //         {
            //             throw new FormatException();
            //         }
            //         if(string.IsNullOrWhiteSpace(item))
            //         {
            //             throw new InvalidDataException();
            //         }
            //         value += number;
            //     }
            //     return true;
            // }
            // catch (InvalidDataException)
            // {
            //     return false;
            // }
            // catch (FormatException)
            // {
            //     return false;
            // }
            value = 0;

            // if (string.IsNullOrWhiteSpace(expression) || !expression.Contains("+"))
            //     return false; 

            string[] string_numbers = expression.Split("+");

            foreach (string item in string_numbers)
            {
                if (string.IsNullOrWhiteSpace(item) || !int.TryParse(item, out int number))
                    return false; 

                value += number; 
            }

            return true;
            #endregion
        }

        public static int PIPrecision()
        {
            #region TODO
            throw new NotImplementedException();
            #endregion
        }

        public static int Fibonacci(this int n)
        {
            #region 
            if (n <= 1) return 1;

            // return (n-1).Fibonacci() + (n-2).Fibonacci();
            return Fibonacci(n - 1) + Fibonacci(n - 2);
            #endregion
        }
    }
}