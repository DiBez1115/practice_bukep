using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUKEP.Student.Calculator
{

    /// <summary>
    /// Калькулятор вычисляющий математические выражения.
    /// </summary>
    public static class Calculator
    {

        /// <summary>
        /// Вычислить математическое выражение.
        /// </summary>
        /// <param name="expression">Строка полученная от пользователя.</param>
        /// <returns>
        /// Метод возвращает строку с результатом вычисления.
        /// </returns>
        public static string CalculateMathematicalExpression(string expression)
        {
            string line = expression.Replace('÷', '/').Replace('×', '*');

            string outputResult;

            List<char> elements = new List<char>();

            Stack<string> operations = new Stack<string>();

            Stack<double> numbers = new Stack<double>();

            if (VerifyExpression(line) == true)
            {
                foreach (char symbol in line)
                {
                    if (symbol != ' ')
                    {
                        elements.Add(symbol);
                    }

                }

                AllocateElementsToStacks(elements, operations, numbers);

                PerformOperation(operations, numbers);

                outputResult = numbers.Pop().ToString();
            }

            else
            {
                outputResult = line.Replace('/', '÷').Replace('*', '×');
            }

            return outputResult;
        }

        /// <summary>
        /// Вычислить операцию. 
        /// </summary>
        /// <param name="operations">Стек содержащий элементы операций и скобок.</param>
        /// <param name="numbers">Стек содержащий элементы чисел.</param>
        public static void PerformOperation(Stack<string> operations, Stack<double> numbers)
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

                        if (firstNumbers == 0)
                        {
                            throw new DivideByZeroException();
                        }

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
        /// Распределить элементы по стекам.
        /// </summary>
        /// <param name="elements">Лист, который содержит выражение разбитое на символы.</param>
        /// <param name="operations">Стек в который будут передаваться элементы операций и скобок.</param>
        /// <param name="numbers">Стек в который будут передаваться элементы чисел.</param>
        public static void AllocateElementsToStacks(List<char> elements, Stack<string> operations, Stack<double> numbers)
        {
            string result = "";

            for (int iteration = 0; iteration < elements.Count; iteration++)
            {
                if (elements[iteration] == '(')
                {
                    operations.Push("(");

                    continue;
                }

                if (elements[iteration] == ')')
                {
                    PerformOperation(operations, numbers);

                    if (operations.Peek() == "(")
                    {
                        operations.Pop();

                        continue;
                    }

                }

                if (iteration == 0 && elements[iteration] == '-')
                {
                    result += "-";

                    continue;
                }

                if (elements[iteration] == '-' && elements[iteration - 1] == '(')
                {
                    result += elements[iteration];
                }

                if (operations.Count == 1 && numbers.Count == 2 && elements[iteration] != '^' && (operations.Contains("*") || operations.Contains("/") || operations.Contains("^")))
                {
                    PerformOperation(operations, numbers);
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

                            if (operations.Count != 0)
                            {
                                if (operations.Peek() == "^")
                                {
                                    PerformOperation(operations, numbers);
                                }

                            }
                            result = "";
                        }

                    }

                }

                if ((elements[iteration] == '*' || elements[iteration] == '/' || elements[iteration] == '-' || elements[iteration] == '+' || elements[iteration] == '^') && elements[iteration - 1] != '(')
                {
                    if (result != "")
                    {
                        numbers.Push(Convert.ToDouble(result));

                        result = "";

                        if (operations.Count >= 1 && elements[iteration] != '^')
                        {
                            string topOperation = operations.Peek();

                            if ((operations.Contains("*") && numbers.Count >= 2) || operations.Contains("/") && numbers.Count >= 2 && topOperation != "(")
                            {
                                PerformOperation(operations, numbers);
                            }

                            result = "";
                        }

                    }

                    result += elements[iteration];

                    if ((result == "-" || result == "+" || result == ")") && numbers.Count >= 2)
                    {
                        PerformOperation(operations, numbers);
                    }

                    operations.Push(result);

                    result = "";
                }

            }

            if (result != "")
            {
                numbers.Push(Convert.ToDouble(result));
            }

            PerformOperation(operations, numbers);
        }

        /// <summary>
        /// Проверить выражение на корректность.
        /// Пример: Пользователь ввёл "8 + 3 -" и нажимает кнопку "=", то программа не будет вычислять введенное выражение.
        /// </summary>
        /// <param name="expression">Строка полученная от пользователя.</param>
        /// <returns>
        /// Tpue, если в выражение написано корректно.
        /// Если выражение написано не корректно, то false.
        /// </returns>
        public static bool VerifyExpression(string expression)
        {
            bool verificationResult = true;
            
            if (expression.Length > 0)
            {
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

            }
            return verificationResult;
        }

        /// <summary>
        /// Проверить выражение на буквы и лишние символы.
        /// </summary>
        /// <param name="elements">Получаемая от пользователя строка.</param>
        public static bool CheckIfLettersInExpression(string expression)
        {
            bool lettersInLine = false;

            foreach (var symbol in expression)
            {
                if (symbol == '^' || symbol == '-' || symbol == '+' || symbol == '/' || symbol == '*' || symbol == '(' || symbol == ')' || symbol == '.' || symbol == ',')
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
