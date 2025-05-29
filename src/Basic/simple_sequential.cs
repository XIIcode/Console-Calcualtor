using System;

namespace console_calc.basic.simple_sequential
{
    public class Calc
{

    // Fetch numbers from user
    public static string sequentialGetOperation()
    {

        Console.Write("Enter the operation you wish to perform [use spaces to separate numbers and operators e.g 1 + 34 - 78] :  ");

        string? operation = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(operation))
        {
            Console.WriteLine("Can not have a null or empty value");
            return "";
        }

        return operation;    
    }

    //MAin function to do Calculation
    public static void Calculate(string operation)
    {
        string[] tokens = operation.Split(' ');
        if (tokens.Length < 3)
        {
            Console.WriteLine("Invalid input. Example: 2 + 3");
            return;
        }

        double result;
        if (!double.TryParse(tokens[0], out result))
        {
            Console.WriteLine("Invalid number: " + tokens[0]);
            return;
        }

        for (int i = 1; i < tokens.Length; i += 2)
        {
            if (i + 1 >= tokens.Length)
            {
                Console.WriteLine("Operator without a following number.");
                return;
            }
            string op = tokens[i];
            double nextNum;
            if (!double.TryParse(tokens[i + 1], out nextNum))
            {
                Console.WriteLine("Invalid number: " + tokens[i + 1]);
                return;
            }

            switch (op)
            {
                case "+":
                    result += nextNum;
                    break;
                case "-":
                    result -= nextNum;
                    break;
                case "*":
                    result *= nextNum;
                    break;
                case "/":
                    if (nextNum == 0)
                    {
                        Console.WriteLine("Division by zero.");
                        return;
                    }
                    result /= nextNum;
                    break;
                case "%":
                    result %= nextNum;
                    break;
                default:
                    Console.WriteLine("Unknown operator: " + op);
                    return;
            }
        }
        Console.WriteLine("Result: " + result);
    }


}

}
