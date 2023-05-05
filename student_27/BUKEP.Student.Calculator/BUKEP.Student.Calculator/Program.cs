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

                foreach (double resultNumbers in Numbers)
                {
                    Console.Write("=" + resultNumbers);
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

        /// <summary>
        /// Метод вычисляющий выражение.
        /// </summary>
        /// <param name="operation">Стек хранящий операции.</param>
        /// <param name="numbers">Стек хранящий числа.</param>
        /// <param name="args">При делении на ноль метод выведет ошибку и возвращается в Main(agrs).</param>
        /// <returns></returns>
        static double ApplyOperation(Stack<string> operation, Stack<double> numbers, string[] args)
        {
            double calculationResult = 0;

            for (int iteration = 0; iteration < operation.Count; iteration++)
            {
                string checkingTheOperation = operation.Peek();

                if (checkingTheOperation == "(")
                {
                    break;
                }

                string upperOperation = operation.Pop();

                double firstNumbers = numbers.Pop();

                double secondNumbers = numbers.Pop();

                switch (upperOperation)
                {
                    case "+":

                        calculationResult = firstNumbers + secondNumbers;

                        numbers.Push(calculationResult);

                        break;

                    case "-":

                        calculationResult = secondNumbers - firstNumbers;

                        numbers.Push(calculationResult);

                        break;

                    case "*":

                        calculationResult = firstNumbers * secondNumbers;

                        numbers.Push(calculationResult);

                        break;

                    case "/":

                        if (firstNumbers == 0)
                        {
                            Console.WriteLine("Деление на 0!!!\n");

                            Console.ReadKey();

                            Console.Clear();

                            Main(args);
                        }

                        calculationResult = secondNumbers / firstNumbers;

                        numbers.Push(calculationResult);

                        break;
                }

            }

            return calculationResult;
        }

        /// <summary>
        /// Метод проходит по листу и распределяет числа в стек к числам, а элементы операций и скобки в стек к операциям. 
        /// Так же в методе имеется вызываемый в определенных случаях метод (ApplyOperation).
        /// </summary>
        /// <param name="elements">Лист хранящий каждый символ.</param>
        /// <param name="operation">Стек необходимый для добавления в него всех нужных операций и скобок.</param>
        /// <param name="numbers">Стек необходимый для добавления в него всех нужных чисел и запятых.</param>
        /// <param name="args">При делении на ноль метод выведет ошибку и возвращается в Main(agrs).</param>
        static void TranslationOfExpressionToReversePolish(List<char> elements, Stack<string> operation, Stack<double> numbers, string[] args)
        {
            var result = "";

            for (int iteration = 0; iteration < elements.Count; iteration++)
            {
                if (!(operation.Contains("(")))
                {
                    if (iteration == 0 && elements[iteration] == '-')
                    {
                        result += "-";

                        continue;
                    }

                    if (operation.Count == 1 && numbers.Count == 2 && (operation.Contains("*") || operation.Contains("/")))
                    {
                        ApplyOperation(operation, numbers, args);
                    }

                    if (elements[iteration] == '+' || elements[iteration] == '-' || elements[iteration] == '*' || elements[iteration] == '/')
                    {
                        if (result != "")
                        {
                            numbers.Push(Convert.ToDouble(result));

                            result = "";

                            if (operation.Count >= 1)
                            {
                                string UpperOperation = operation.Peek();

                                if (operation.Contains("*") && numbers.Count >= 2 || operation.Contains("/") && numbers.Count >= 2 && UpperOperation != "(")
                                {
                                    ApplyOperation(operation, numbers, args);
                                }

                                result = "";
                            }

                        }

                        result += elements[iteration];

                        if ((result == "-" || result == "+" || result == ")") && numbers.Count >= 2)
                        {
                            ApplyOperation(operation, numbers, args);
                        }

                        operation.Push(result);

                        result = "";
                    }

                    if ((elements[iteration] >= '0' && elements[iteration] <= '9') || elements[iteration] == '.' || elements[iteration] == ',')
                    {
                        if (elements[iteration] == '.' || elements[iteration] == ',')
                        {
                            result += ",";
                        }

                        else
                        {
                            result += elements[iteration];
                        }

                        if (iteration + 1 != elements.Count)
                        {
                            if (elements[iteration + 1] == '+' || elements[iteration + 1] == '-' || elements[iteration + 1] == '*' || elements[iteration + 1] == '/')
                            {
                                numbers.Push(Convert.ToDouble(result));

                                result = "";
                            }

                        }

                    }

                }

                if (elements[iteration] == '(')
                {
                    operation.Push("(");
                }

                if (elements[iteration] == ')')
                {
                    ApplyOperation(operation, numbers, args);

                    if (operation.Peek() == "(")
                    {
                        operation.Pop();
                    }

                }

                if (operation.Contains("("))
                {
                    if (elements[iteration] == '-' && elements[iteration - 1] == '(')
                    {
                        result += elements[iteration];
                    }

                    if ((elements[iteration] >= '0' && elements[iteration] <= '9') || elements[iteration] == '.' || elements[iteration] == ',')
                    {
                        if (elements[iteration] == '.' || elements[iteration] == ',')
                        {
                            result += ",";
                        }

                        else
                        {
                            result += elements[iteration];
                        }

                        if (iteration + 1 != elements.Count)
                        {
                            if (elements[iteration + 1] == '+' || elements[iteration + 1] == '-' || elements[iteration + 1] == '*' || elements[iteration + 1] == '/' || elements[iteration + 1] == '(' || elements[iteration + 1] == ')')
                            {
                                numbers.Push(Convert.ToDouble(result));

                                result = "";
                            }

                        }

                    }

                    if ((elements[iteration] == '*' || elements[iteration] == '/' || elements[iteration] == '-' || elements[iteration] == '+') && elements[iteration - 1] != '(')
                    {
                        operation.Push(elements[iteration].ToString());
                    }

                }

            }

            if (result != "")
            {
                numbers.Push(Convert.ToDouble(result));
            }

            ApplyOperation(operation, numbers, args);
        }

        /// <summary>
        /// Метод проверяет выражение на наличие слов и посторонних символов (не использующееся в математических выражениях).
        /// </summary>
        /// <param name="elements">Лист хранящий каждый символ.</param>
        /// <param name="args">При нахождении посторонних символов выведет ошибку и возвращается в Main(agrs).</param>
        static void ChecksExpressionsForLetters(List<char> elements, string[] args)
        {
            for (int iteration = 0; iteration < elements.Count; iteration++)
            {
                if (elements[iteration] == '-' || elements[iteration] == '+' || elements[iteration] == '/' || elements[iteration] == '*' || elements[iteration] == '(' || elements[iteration] == ')' || elements[iteration] == '.' || elements[iteration] == ',')
                {
                    continue;
                }

                if (!double.TryParse(elements[iteration].ToString(), out _))
                {
                    Console.WriteLine("Ошибка!!! Не удалось распознать выражение!");

                    Console.ReadKey();

                    Main(args);

                    continue;
                }

            }

        }

    }

}