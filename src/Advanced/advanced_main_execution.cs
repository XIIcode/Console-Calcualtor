using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using console_calc.Advanced.Scientific;


namespace console_calc.Advanced
{
    // Calculator class encapsulates bulk and sequential operations.
    public class advancedCalculator
    {
        public double[]? Numbers { get; set; }
        public string? Operator { get; set; }
        public double Result { get; private set; }

        // Bulk method: applies the operator across all entries in Numbers[].
        // E.g. if Operator = "+", it sums them; if "-", it does a left‐fold subtraction.
        public void Bulk(double[] numbers, string op)
        {
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException("At least one number is required for a bulk calculation.");

            Numbers = numbers;
            Operator = op;
            Result = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                switch (op)
                {
                    case "+":
                        Result += numbers[i];
                        break;
                    case "-":
                        Result -= numbers[i];
                        break;
                    case "*":
                        Result *= numbers[i];
                        break;
                    case "/":
                        if (numbers[i] == 0)
                            throw new DivideByZeroException("Cannot divide by zero in bulk operation.");
                        Result /= numbers[i];
                        break;
                    default:
                        throw new InvalidOperationException($"Invalid operator '{op}' for bulk calculation.");
                }
            }
        }

        // Seq method: simply applies the operator to two numbers: a and b.
        public void Seq(double a, double b, string op)
        {
            Numbers = new[] { a, b };
            Operator = op;

            switch (op)
            {
                case "+":
                    Result = a + b;
                    break;
                case "-":
                    Result = a - b;
                    break;
                case "*":
                    Result = a * b;
                    break;
                case "/":
                    if (b == 0)
                        throw new DivideByZeroException("Cannot divide by zero in sequential operation.");
                    Result = a / b;
                    break;
                default:
                    throw new InvalidOperationException($"Invalid operator '{op}' for sequential calculation.");
            }
        }



        public static void advancedExecution()
        {
            var calculator = new advancedCalculator();

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("\n Welcome to the Simple Calculator App.");
                Console.Write("Enter 1 (Bulk) or 2 (Sequential) or 3 (Scientific): ");

                if (!int.TryParse(Console.ReadLine(), out int choice) || (choice != 1 && choice != 2 && choice != 3))
                {
                    Console.WriteLine("Invalid choice. Please enter 1 for Bulk, 2 for Sequential or 2 for Scientific calculations.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        // Bulk
                        Console.WriteLine("\nYou have chosen the Bulk method for calculations.");
                        Console.Write("Please enter the numbers separated by space: ");
                        string? numbersLine = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(numbersLine))
                        {
                            Console.WriteLine("No numbers entered. Exiting.");
                            continue;
                        }

                        // Split, parse to double[], ignoring any empty tokens
                        string[] parts = numbersLine
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        double[] parsedNumbers = new double[parts.Length];
                        for (int i = 0; i < parts.Length; i++)
                        {
                            if (!double.TryParse(parts[i], out parsedNumbers[i]))
                            {
                                Console.WriteLine($"Invalid number: '{parts[i]}'. Exiting.");
                                goto EndLoop;
                            }
                        }

                        Console.Write("Please enter the operator (+, -, *, /): ");
                        string? bulkOp = Console.ReadLine()?.Trim();
                        if (bulkOp != "+" && bulkOp != "-" && bulkOp != "*" && bulkOp != "/")
                        {
                            Console.WriteLine($"Invalid operator '{bulkOp}'. Exiting.");
                            continue;
                        }

                        try
                        {
                            calculator.Bulk(parsedNumbers, bulkOp);
                            Console.WriteLine($"\nBulk Calculation Result: {calculator.Result}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error during bulk calculation: {ex.Message}");
                        }

                        break;

                    case 2:
                        // Sequential
                        Console.WriteLine("\nYou have chosen the Sequential method for calculations.");
                        Console.Write("Please enter the first number: ");
                        string? firstInput = Console.ReadLine();
                        if (!double.TryParse(firstInput, out double num1))
                        {
                            Console.WriteLine($"Invalid number: '{firstInput}'. Exiting.");
                            continue;
                        }

                        Console.Write("Please enter the operator (+, -, *, /): ");
                        string? seqOp = Console.ReadLine()?.Trim();
                        if (seqOp != "+" && seqOp != "-" && seqOp != "*" && seqOp != "/")
                        {
                            Console.WriteLine($"Invalid operator '{seqOp}'. Exiting.");
                            continue;
                        }

                        Console.Write("Please enter the second number: ");
                        string? secondInput = Console.ReadLine();
                        if (!double.TryParse(secondInput, out double num2))
                        {
                            Console.WriteLine($"Invalid number: '{secondInput}'. Exiting.");
                            continue;
                        }

                        try
                        {
                            calculator.Seq(num1, num2, seqOp);
                            Console.WriteLine($"\nSequential Calculation Result: {calculator.Result}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error during sequential calculation: {ex.Message}");
                        }

                        break;
                    //scientific
                    case 3:
                        Console.WriteLine("\nYou have chosen the Scientific method for calculations.");
                        Console.Write("Enter 1 (Factorial) or 2 (Roots and Powers) or 3 (Logarithms): ");

                        if (!int.TryParse(Console.ReadLine(), out int choice3) || (choice3 != 1 && choice3 != 2 && choice3 != 3))
                        {
                            Console.WriteLine("Invalid choice. Please enter 1 for Factorial, 2 for Roots and Powers or 3 for Logarithm calculations.");
                            continue;
                        }

                        switch (choice3)
                        {
                            case 1:
                                Console.WriteLine("Enter a non-negative number:");
                                string? inputF = Console.ReadLine();
                                var scientificF = new console_calc.Advanced.Scientific.Scientific();
                                if (int.TryParse(inputF, out int numF))
                                {
                                    try
                                    {
                                        scientificF.Factorials(numF);
                                        Console.WriteLine($"Factorial of {numF} is: {scientificF.Result}");
                                        continue;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                        continue;

                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input!Please enter a valid non-negative");

                                }
                                break;

                            case 2:
                                Console.WriteLine("Enter a positive number for the root:");
                                string? inputR = Console.ReadLine();
                                Console.WriteLine("Enter a positive number for the root power:");
                                string? R = Console.ReadLine();
                                var scientificR = new console_calc.Advanced.Scientific.Scientific();
                                if (int.TryParse(inputR, out int numR) && double.TryParse(R, out double r))
                                {
                                    try
                                    {
                                        scientificR.Roots(numR, r);
                                        Console.WriteLine($"Root of {numR} is: {scientificR.Result}");
                                        continue;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                        continue;

                                    }
                                }
                                break;

                            case 3:
                                Console.WriteLine("Logarithm functionality. Enter a positive number for the log: ");
                                string? inputL = Console.ReadLine();
                                Console.WriteLine("For the Base, enter 'log' for base 10, 'ln' for natural log or 'log2' for base2:");
                                string? L = Console.ReadLine();
                                var scientificL = new console_calc.Advanced.Scientific.Scientific();
                                if (int.TryParse(inputL, out int numL))
                                {
                                    try
                                    {
                                        scientificL.Logarithm(numL, L);
                                        Console.WriteLine($"Log of {numL} to base {L} is: {scientificL.Result}");
                                        continue;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                        continue;

                                    }
                                }
                                continue;
                        }
                        break;
                }

            }
            EndLoop:
            Console.WriteLine("\n Would you like to perform another operation? (y/n)");
            string? again = Console.ReadLine();
            if (again?.Trim().ToLower() != "y")
            {
                keepRunning = false;
                Console.WriteLine("\n Exiting Simple Calculator!");
            }
        }
    }
}



