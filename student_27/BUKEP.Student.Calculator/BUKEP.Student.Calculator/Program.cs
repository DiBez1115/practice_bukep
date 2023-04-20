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

                string inputData = Console.ReadLine();

                List<char> Elements = new List<char>();

                foreach (char s in inputData)
                {
                    if (s != ' ')
                    {
                        Elements.Add(s);
                    }

                }

                CheckingForSpacrs(Elements, args);

                Stack<string> Operation = new Stack<string>();
                Stack<double> Numbers = new Stack<double>();

                Run(Elements, Operation, Numbers, args);

                CalculationOfDegeneracy(Operation, Numbers, args);

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

        static double CalculationOfDegeneracy(Stack<string> Operation, Stack<double> Numbers, string[] args)
        {
            double CalculationResult = 0;

            for (int i = 0; i < Operation.Count; i++)
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

        static void Run(List<char> Elements, Stack<string> Operation, Stack<double> Numbers, string[] args)
        {
            var result = "";

            for (int i = 0; i < Elements.Count; i++)
            {
                if (!(Operation.Contains("(")))
                {
                    if (Operation.Count == 1 && Numbers.Count == 2 && (Operation.Contains("*") || Operation.Contains("/")))
                    {
                        CalculationOfDegeneracy(Operation, Numbers, args);
                    }


                    if (Elements[i] == '+' || Elements[i] == '-' || Elements[i] == '*' || Elements[i] == '/')
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
                                    CalculationOfDegeneracy(Operation, Numbers, args);
                                }

                                result = "";

                            }

                        }

                        result += Elements[i];

                        if ((result == "-" || result == "+" || result == ")") && Numbers.Count >= 2)
                        {
                            CalculationOfDegeneracy(Operation, Numbers, args);
                        }

                        Operation.Push(result);

                        result = "";

                    }

                    if ((Elements[i] >= '0' && Elements[i] <= '9') || Elements[i] == '.' || Elements[i] == ',')
                    {
                        if (Elements[i] == '.' || Elements[i] == ',')
                        {
                            result += ",";
                        }

                        else
                        {
                            result += Elements[i];
                        }

                        if (i + 1 != Elements.Count)
                        {
                            if (Elements[i + 1] == '+' || Elements[i + 1] == '-' || Elements[i + 1] == '*' || Elements[i + 1] == '/')
                            {
                                Numbers.Push(Convert.ToDouble(result));

                                result = "";
                            }

                        }

                    }

                }

                if (Elements[i] == '(')
                {
                    Operation.Push("(");
                }

                if (Elements[i] == ')')
                {
                    CalculationOfDegeneracy(Operation, Numbers, args);

                    if (Operation.Peek() == "(")
                    {
                        Operation.Pop();
                    }

                }

                if (Operation.Contains("("))
                {
                    if (Elements[i] == '-' && Elements[i - 1] == '(')
                    {
                        result += Elements[i];
                    }

                    if ((Elements[i] >= '0' && Elements[i] <= '9') || Elements[i] == '.' || Elements[i] == ',')
                    {
                        if (Elements[i] == '.' || Elements[i] == ',')
                        {
                            result += ",";
                        }

                        else
                        {
                            result += Elements[i];
                        }

                        if (i + 1 != Elements.Count)
                        {
                            if (Elements[i + 1] == '+' || Elements[i + 1] == '-' || Elements[i + 1] == '*' || Elements[i + 1] == '/' || Elements[i + 1] == '(' || Elements[i + 1] == ')')
                            {
                                Numbers.Push(Convert.ToDouble(result));

                                result = "";
                            }

                        }

                    }

                    if ((Elements[i] == '*' || Elements[i] == '/' || Elements[i] == '-' || Elements[i] == '+') && Elements[i - 1] != '(')
                    {
                        Operation.Push(Elements[i].ToString());
                    }

                }

            }

            if (result != "")
            {
                Numbers.Push(Convert.ToDouble(result));
            }

            CalculationOfDegeneracy(Operation, Numbers, args);
        }

        static void CheckingForSpacrs(List<char> Elements, string[] args)
        {
            for (int i = 0; i < Elements.Count; i++)
            {

                if (Elements[i] == '-' || Elements[i] == '+' || Elements[i] == '/' || Elements[i] == '*' || Elements[i] == '(' || Elements[i] == ')' || Elements[i] == '.' || Elements[i] == ',')
                {
                    continue;
                }

                if (!double.TryParse(Elements[i].ToString(), out _))
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