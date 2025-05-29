using System;
using console_calc.Advanced;
using console_calc.basic;

namespace console_calc.app
{
    // Main class to Integrate all our components.
    public class main_simple_math_Calc
    {
        //I have Integrated my Code base from other files under this function
        public static void simple_function()
        {
            Console.WriteLine("Choose an option");
            Console.WriteLine("1.Sequential with no [Bodmas]");
            Console.WriteLine("2.Sequential with  [Bodmas]");
            Console.Write("Enter option Number : ");
            string? choice = Console.ReadLine();
            if (!string.IsNullOrEmpty(choice))
            {
                switch (choice)
                {
                    case "1":
                        {
                            string operation =basic.simple_sequential.Calc.sequentialGetOperation();
                            basic.simple_sequential.Calc.Calculate(operation);  //Does Not COntain Precedence logic
                            break;
                        }

                    case "2":
                        {
                            string operation = basic.simple_sequential.Calc.sequentialGetOperation();
                            basic.operator_precedence.MathEvaluator.Calculate(operation); // Has Precedence Logic
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid Input");
                            break;
                        }
                }
            }

        }

        public static void Main(string[] args)
        {
            Console.WriteLine("========Welcome to Simple-math-Calc========");
            Console.WriteLine("Choose Method");
            Console.WriteLine("1.Simple e.g [1 * 5 + 8 + % 7]");
            Console.WriteLine("2.Advanced [Includes both (sequential and bulk)]");
            Console.Write("Enter option number : ");
            string? choice = Console.ReadLine();
            if (!string.IsNullOrEmpty(choice))
            {
                switch (choice)
                {
                    case "1":
                        simple_function();
                        break;
                    case "2":
                        // For advanced Function
                        advancedCalculator.advancedExecution();
                        break;
                }
            }
        }
    }

}

