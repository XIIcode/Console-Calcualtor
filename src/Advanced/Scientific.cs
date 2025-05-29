using System;
using System;

namespace console_calc.Advanced.Scientific;

class Scientific
{
    public double Result { get; private set; }
    // Factorials
    public void Factorials(int number)
    {
        if (number < 0)
            throw new ArgumentException("Factorial is not defined for negative numbers!!");
        Result = 1;
        for (int i = 2; i <= number; i++)
        {
            Result *= i;
        }

    }
    // Roots
    public void Roots(int number, double n)
    {
        if (number < 0 && number == 0)
            throw new ArgumentException("Roots for negative or degree zero numbers not defined!");
        if (n == 2)
        {
            Result = Math.Sqrt(number);
        }
        else
        {
            Result = Math.Pow(Result, 1.0 / n);
        }
    }
    // Logarithms
    public void Logarithm(int num, string logType)
    {
        if (num <= 0)
            throw new ArgumentException("Logarithm undefined for zero and negative numbers!");
        if (logType == "log")
        {
            Result = Math.Log10(num);
        }
        else if (logType == "ln")
        {
            Result = Math.Log(num);
        }
        else if (logType == "log2")
        {
            Result = Math.Log2(num);
        }
        else
            throw new ArgumentException("Invalid log!! Use 'log' for base 10, 'ln' for natural log or 'log2' for base2 ");

    }

}