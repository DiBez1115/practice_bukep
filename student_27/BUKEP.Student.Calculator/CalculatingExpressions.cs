﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUKEP.Student.Calculator
{

    /// <summary>
    /// Класс для вычисления математических выражений.
    /// </summary>
    public static class CalculatingExpressions
    {

        /// <summary>
        /// Интерпретатор математических выражений.
        /// </summary>
        /// <param name="expression">Строка получаемая от пользователя.</param>
        /// <returns>
        /// Метод возвращает строку с результатом вычисления.
        /// </returns>
        public static string PasstheExpressionToCalculatingExpressions(string expression)
        {
            string line = expression.Replace('÷', '/').Replace('×', '*');

            string outputResult;

            List<char> elements = new List<char>();

            Stack<string> operations = new Stack<string>();

            Stack<double> numbers = new Stack<double>();

            if (CheckingCorrectnesstheExpression(line) == true)
            {
                foreach (char symbol in line)
                {
                    if (symbol != ' ')
                    {
                        elements.Add(symbol);
                    }

                }

                ReversePolishRecording(elements, operations, numbers);

                CalculatetheExpression(operations, numbers);

                outputResult = numbers.Pop().ToString();
            }

            else
            {
                outputResult = line.Replace('/', '÷').Replace('*', '×');
            }

            return outputResult;
        }

        /// <summary>
        /// Вычислить выражение. 
        /// </summary>
        /// <param name="operations">Стек содержащий элементы операций и скобок.</param>
        /// <param name="numbers">Стек содержащий элементы чисел.</param>
        public static void CalculatetheExpression(Stack<string> operations, Stack<double> numbers)
        {
            for (int iteration = 0; iteration < operations.Count; iteration++)
            {
                string checkingOperation = operations.Peek();

                if (checkingOperation == "(")
                {
                    break;
                }

                string upperOperation = operations.Pop();

                double firstNumbers = numbers.Pop();

                double secondNumbers = numbers.Pop();

                double outputResult;

                switch (upperOperation)
                {

                    case "+":

                        outputResult = firstNumbers + secondNumbers;

                        numbers.Push(outputResult);

                        break;

                    case "-":

                        outputResult = secondNumbers - firstNumbers;

                        numbers.Push(outputResult);

                        break;

                    case "*":

                        outputResult = firstNumbers * secondNumbers;

                        numbers.Push(outputResult);

                        break;

                    case "/":

                        outputResult = secondNumbers / firstNumbers;

                        numbers.Push(outputResult);

                        break;

                    case "^":

                        outputResult = Math.Pow(secondNumbers, firstNumbers);

                        numbers.Push(outputResult);

                        break;
                }

            }

        }

        /// <summary>
        /// Алгоритм обратной польской записи распределяющая элементы по стекам.
        /// </summary>
        /// <param name="elements">Лист, который содержит выражение разбитое на символы.</param>
        /// <param name="operations">Стек в который будут передаваться элементы операций и скобок.</param>
        /// <param name="numbers">Стек в который будут передаваться элементы чисел.</param>
        public static void ReversePolishRecording(List<char> elements, Stack<string> operations, Stack<double> numbers)
        {
            var result = "";

            for (int iteration = 0; iteration < elements.Count; iteration++)
            {
                if (!operations.Contains("("))
                {
                    if (iteration == 0 && elements[iteration] == '-')
                    {
                        result += "-";

                        continue;
                    }

                    if (elements[iteration] == '^')
                    {
                        operations.Push("^");
                    }

                    if (operations.Count == 1 && numbers.Count == 2 && (operations.Contains("*") || operations.Contains("/") || operations.Contains("^")))
                    {
                        CalculatetheExpression(operations, numbers);
                    }

                    if (elements[iteration] == '+' || elements[iteration] == '-' || elements[iteration] == '*' || elements[iteration] == '/')
                    {
                        if (result != "")
                        {
                            numbers.Push(Convert.ToDouble(result));

                            result = "";

                            if (operations.Count >= 1)
                            {
                                string topOperation = operations.Peek();

                                if ((operations.Contains("*") && numbers.Count >= 2) || operations.Contains("/") && numbers.Count >= 2 && topOperation != "(")
                                {
                                    CalculatetheExpression(operations, numbers);
                                }

                                result = "";
                            }

                        }

                        result += elements[iteration];

                        if ((result == "-" || result == "+" || result == ")") && numbers.Count >= 2)
                        {
                            CalculatetheExpression(operations, numbers);
                        }

                        operations.Push(result);

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
                            if (elements[iteration + 1] == '+' || elements[iteration + 1] == '-' || elements[iteration + 1] == '*' || elements[iteration + 1] == '/' || elements[iteration + 1] == '^')
                            {
                                numbers.Push(Convert.ToDouble(result));

                                if (operations.Count != 0 && operations.Peek() == "^")
                                {
                                    CalculatetheExpression(operations, numbers);
                                }

                                result = "";
                            }

                        }

                    }

                }

                if (elements[iteration] == '(')
                {
                    operations.Push("(");
                }

                if (elements[iteration] == ')')
                {
                    CalculatetheExpression(operations, numbers);

                    if (operations.Peek() == "(")
                    {
                        operations.Pop();
                    }

                }

                if (operations.Contains("("))
                {
                    if (elements[iteration] == '^')
                    {
                        operations.Push("^");
                    }

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
                            if (elements[iteration + 1] == '+' || elements[iteration + 1] == '-' || elements[iteration + 1] == '*' || elements[iteration + 1] == '/' || elements[iteration + 1] == '(' || elements[iteration + 1] == ')' || elements[iteration + 1] == '^')
                            {
                                numbers.Push(Convert.ToDouble(result));

                                if (operations.Peek() == "^")
                                {
                                    CalculatetheExpression(operations, numbers);
                                }

                                result = "";
                            }

                        }

                    }

                    if ((elements[iteration] == '*' || elements[iteration] == '/' || elements[iteration] == '-' || elements[iteration] == '+') && elements[iteration - 1] != '(')
                    {
                        operations.Push(elements[iteration].ToString());
                    }

                }

            }

            if (result != "")
            {
                numbers.Push(Convert.ToDouble(result));
            }

            CalculatetheExpression(operations, numbers);
        }

        /// <summary>
        /// Проверка на корректность записи.
        /// Пример: Пользователь ввёл "8 + 3 -" и нажмет кнопку "=", то программа не будет вычислять введенное выражение.
        /// </summary>
        /// <param name="expression">Получаемая от пользователя строка.</param>
        /// <returns>
        /// Программа возвращает значение tpue, если в выражении все написано корректно.
        /// Если выражение будет написано не корректно, то программа вернёт false.
        /// </returns>
        public static bool CheckingCorrectnesstheExpression(string expression)
        {
            bool verificationResult = true;

            char lastElement = expression[expression.Length - 1];

            if (lastElement == ')')
            {
                char elementDeforeBracket = expression[expression.Length - 2];

                if (elementDeforeBracket == '-' || elementDeforeBracket == '+' || elementDeforeBracket == '/' || elementDeforeBracket == '*')
                {
                    verificationResult = false;
                }

            }

            if (lastElement == '-' || lastElement == '+' || lastElement == '/' || lastElement == '*' || lastElement == '^' || lastElement == ',')
            {
                verificationResult = false;
            }

            return verificationResult;
        }

        /// <summary>
        /// Метод проверяет выражение на наличие букв и посторонних символов.
        /// </summary>
        /// <param name="elements">Получаемая от пользователя строка.</param>
        public static bool ChecksExpressionsForLetters(string expression)
        {
            bool lettersInLine = false;

            foreach (var symbol in expression)
            {
                if (symbol == '-' || symbol == '+' || symbol == '/' || symbol == '*' || symbol == '(' || symbol == ')' || symbol == '.' || symbol == ',')
                {
                    continue;
                }

                if (!double.TryParse(symbol.ToString(), out _))
                {
                    lettersInLine = true;

                    continue;
                }

            }

            return lettersInLine;
        }

    }

}
