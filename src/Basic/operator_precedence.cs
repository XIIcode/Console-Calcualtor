using System;
using System.Collections.Generic;

namespace console_calc.basic.operator_precedence
{
    public class MathEvaluator
{
    public static void Calculate(string operation)
    {
        try
        {
            var rpn = ToRPN(operation);
            double result = EvaluateRPN(rpn);
            Console.WriteLine("Result: " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // Convert infix to Reverse Polish Notation
    private static List<string> ToRPN(string input)
    {
        string[] tokens = input.Split(' ');
        Stack<string> operators = new Stack<string>();
        List<string> output = new List<string>();

        Dictionary<string, int> precedence = new Dictionary<string, int>
        {
            { "+", 1 }, { "-", 1 },
            { "*", 2 }, { "/", 2 }, { "%", 2 }
        };

        foreach (string token in tokens)
        {
            double number;
            if (double.TryParse(token, out number))
            {
                output.Add(token);
            }
            else if (precedence.ContainsKey(token))
            {
                while (operators.Count > 0 && precedence.ContainsKey(operators.Peek()) &&
                       precedence[operators.Peek()] >= precedence[token])
                {
                    output.Add(operators.Pop());
                }
                operators.Push(token);
            }
            else
            {
                throw new Exception("Unknown token: " + token);
            }
        }

        while (operators.Count > 0)
        {
            output.Add(operators.Pop());
        }

        return output;
    }

    // Evaluate RPN expression
    private static double EvaluateRPN(List<string> tokens)
    {
        Stack<double> stack = new Stack<double>();

        foreach (string token in tokens)
        {
            double number;
            if (double.TryParse(token, out number))
            {
                stack.Push(number);
            }
            else
            {
                double b = stack.Pop();
                double a = stack.Pop();
                switch (token)
                {
                    case "+": stack.Push(a + b); break;
                    case "-": stack.Push(a - b); break;
                    case "*": stack.Push(a * b); break;
                    case "/":
                        if (b == 0) throw new DivideByZeroException();
                        stack.Push(a / b); break;
                    case "%": stack.Push(a % b); break;
                    default: throw new Exception("Invalid operator: " + token);
                }
            }
        }

        return stack.Pop();
    }
}

}
