using System;
using System.Collections.Generic;

namespace BUKEP.Student.CalculationOfDegeneracyulator
{

    internal class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Введите математическое выражение: ");

                string line = Console.ReadLine();

                List<char> Elements = new List<char>();

                foreach (char item in line)
                {
                    if (item != ' ')
                    {
                        Elements.Add(item);
                    }

                }

                ChecksExpressionsForLetters(Elements, args);

                Stack<string> Operation = new Stack<string>();
                Stack<double> Numbers = new Stack<double>();

                TranslationOfExpressionToReversePolish(Elements, Operation, Numbers, args);

                ApplyOperation(Operation, Numbers, args);

                Console.Write("Результат: ");

                foreach (char sumbol in Elements)
                {
                    Console.Write(sumbol);
                }

                foreach (double ResultNumbers in Numbers)
                {
                    Console.Write("=" + ResultNumbers);
                }

                Console.ReadKey();
                Console.Clear();
                Console.Write("Для повторного ввода операции нажмите Enter, для завершения приложения Esc.");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }

            }

        }

        static double ApplyOperation(Stack<string> Operation, Stack<double> Numbers, string[] args)
        {
            double CalculationResult = 0;

            for (int iteration = 0; iteration < Operation.Count; iteration++)
            {
                string CheckingTheOperation = Operation.Peek();

                if (CheckingTheOperation == "(")
                {
                    break;
                }

                string UpperOperation = Operation.Pop();

                double FirstNumbers = Numbers.Pop();

                double SecondNumbers = Numbers.Pop();

                switch (UpperOperation)
                {
                    case "+":

                        CalculationResult = FirstNumbers + SecondNumbers;

                        Numbers.Push(CalculationResult);
                        break;

                    case "-":

                        CalculationResult = SecondNumbers - FirstNumbers;

                        Numbers.Push(CalculationResult);
                        break;

                    case "*":

                        CalculationResult = FirstNumbers * SecondNumbers;

                        Numbers.Push(CalculationResult);
                        break;

                    case "/":

                        if (FirstNumbers == 0)
                        {
                            Console.WriteLine("Деление на 0!!!\n");
                            Console.ReadKey();
                            Console.Clear();

                            Main(args);
                        }

                        CalculationResult = SecondNumbers / FirstNumbers;

                        Numbers.Push(CalculationResult);
                        break;
                }

            }

            return CalculationResult;
        }

        static void TranslationOfExpressionToReversePolish(List<char> Elements, Stack<string> Operation, Stack<double> Numbers, string[] args)
        {
            var result = "";

            for (int iteration = 0; iteration < Elements.Count; iteration++)
            {
                if (!(Operation.Contains("(")))
                {
                    if (Operation.Count == 1 && Numbers.Count == 2 && (Operation.Contains("*") || Operation.Contains("/")))
                    {
                        ApplyOperation(Operation, Numbers, args);
                    }

                    if (Elements[iteration] == '+' || Elements[iteration] == '-' || Elements[iteration] == '*' || Elements[iteration] == '/')
                    {
                        if (result != "")
                        {
                            Numbers.Push(Convert.ToDouble(result));

                            result = "";

                            if (Operation.Count >= 1)
                            {
                                string UpperOperation = Operation.Peek();

                                if (Operation.Contains("*") && Numbers.Count >= 2 || Operation.Contains("/") && Numbers.Count >= 2 && UpperOperation != "(")
                                {
                                    ApplyOperation(Operation, Numbers, args);
                                }

                                result = "";
                            }

                        }

                        result += Elements[iteration];

                        if ((result == "-" || result == "+" || result == ")") && Numbers.Count >= 2)
                        {
                            ApplyOperation(Operation, Numbers, args);
                        }

                        Operation.Push(result);

                        result = "";
                    }

                    if ((Elements[iteration] >= '0' && Elements[iteration] <= '9') || Elements[iteration] == '.' || Elements[iteration] == ',')
                    {
                        if (Elements[iteration] == '.' || Elements[iteration] == ',')
                        {
                            result += ",";
                        }

                        else
                        {
                            result += Elements[iteration];
                        }

                        if (iteration + 1 != Elements.Count)
                        {
                            if (Elements[iteration + 1] == '+' || Elements[iteration + 1] == '-' || Elements[iteration + 1] == '*' || Elements[iteration + 1] == '/')
                            {
                                Numbers.Push(Convert.ToDouble(result));

                                result = "";
                            }

                        }

                    }

                }

                if (Elements[iteration] == '(')
                {
                    Operation.Push("(");
                }

                if (Elements[iteration] == ')')
                {
                    ApplyOperation(Operation, Numbers, args);

                    if (Operation.Peek() == "(")
                    {
                        Operation.Pop();
                    }

                }

                if (Operation.Contains("("))
                {
                    if (Elements[iteration] == '-' && Elements[iteration - 1] == '(')
                    {
                        result += Elements[iteration];
                    }

                    if ((Elements[iteration] >= '0' && Elements[iteration] <= '9') || Elements[iteration] == '.' || Elements[iteration] == ',')
                    {
                        if (Elements[iteration] == '.' || Elements[iteration] == ',')
                        {
                            result += ",";
                        }

                        else
                        {
                            result += Elements[iteration];
                        }

                        if (iteration + 1 != Elements.Count)
                        {
                            if (Elements[iteration + 1] == '+' || Elements[iteration + 1] == '-' || Elements[iteration + 1] == '*' || Elements[iteration + 1] == '/' || Elements[iteration + 1] == '(' || Elements[iteration + 1] == ')')
                            {
                                Numbers.Push(Convert.ToDouble(result));

                                result = "";
                            }

                        }

                    }

                    if ((Elements[iteration] == '*' || Elements[iteration] == '/' || Elements[iteration] == '-' || Elements[iteration] == '+') && Elements[iteration - 1] != '(')
                    {
                        Operation.Push(Elements[iteration].ToString());
                    }

                }

            }

            if (result != "")
            {
                Numbers.Push(Convert.ToDouble(result));
            }

            ApplyOperation(Operation, Numbers, args);
        }

        static void ChecksExpressionsForLetters(List<char> Elements, string[] args)
        {
            for (int iteration = 0; iteration < Elements.Count; iteration++)
            {
                if (Elements[iteration] == '-' || Elements[iteration] == '+' || Elements[iteration] == '/' || Elements[iteration] == '*' || Elements[iteration] == '(' || Elements[iteration] == ')' || Elements[iteration] == '.' || Elements[iteration] == ',')
                {
                    continue;
                }

                if (!double.TryParse(Elements[iteration].ToString(), out _))
                {
                    Console.WriteLine("Пиши цифирки!");
                    Console.ReadKey();

                    Main(args);
                    continue;
                }

            }

        }

    }

}