using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUKEP.Student.Calculator
{
    public static class CalculatingExpressions
    {

        /// <summary>
        /// Данный метод получает строку, где в дальнейшем разбивает её на символы и записывает в лист, а далее передает данный лист методам для вычисления выражения.
        /// </summary>
        /// <param name="expression">Строка получаемая от пользователя.</param>
        /// <returns>
        /// Метод возвращает строку с результатом вычисления.
        /// </returns>
        public static string PassTheExpressionToCalculatingExpressions(string expression)
        {
            string line = expression.Replace('÷', '/').Replace('×', '*');

            string outputResult;

            List<char> Elements = new List<char>();

            Stack<string> Operations = new Stack<string>();

            Stack<double> Numbers = new Stack<double>();

            if (CheckingCorrectnessTheExpression(line) == true)
            {
                foreach (char symbol in line)
                {
                    if (symbol != ' ')
                    {
                        Elements.Add(symbol);
                    }

                }

                TranslationOfExpressionToReversePolish(Elements, Operations, Numbers);

                CalculateTheExpression(Operations, Numbers);

                outputResult = Numbers.Pop().ToString();
            }

            else
            {
                outputResult = line.Replace('/', '÷').Replace('*', '×');
            }

            return outputResult;
        }

        /// <summary>
        /// В данном методе реализован алгоритм необходимый для вычисления выражения. 
        /// </summary>
        /// <param name="operations">Стек содержащий элементы операций и скобок.</param>
        /// <param name="numbers">Стек содержащий элементы чисел.</param>
        /// <returns></returns>
        public static void CalculateTheExpression(Stack<string> operations, Stack<double> numbers)
        {
            double outputResult = 0;

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
        /// Данный метод проходит по листу и распределяет числа в стек к числам, а элементы операций и скобки в стек к операциям. 
        /// Так же в методе имеется вызываемый в определенных случаях метод (CalculateTheExpression).
        /// </summary>
        /// <param name="elements">Лист, который содержит выражение разбитое на символы.</param>
        /// <param name="operations">Стек в который будут передаваться элементы операций и скобок.</param>
        /// <param name="numbers">Стек в который будут передаваться элементы чисел.</param>
        public static void TranslationOfExpressionToReversePolish(List<char> elements, Stack<string> operations, Stack<double> numbers)
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
                        CalculateTheExpression(operations, numbers);
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
                                    CalculateTheExpression(operations, numbers);
                                }

                                result = "";
                            }

                        }

                        result += elements[iteration];

                        if ((result == "-" || result == "+" || result == ")") && numbers.Count >= 2)
                        {
                            CalculateTheExpression(operations, numbers);
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
                                    CalculateTheExpression(operations, numbers);
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
                    CalculateTheExpression(operations, numbers);

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
                                    CalculateTheExpression(operations, numbers);
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

            CalculateTheExpression(operations, numbers);
        }

        /// <summary>
        /// В данном методе получаемая строка проверяется на корректность записи.
        /// Пример: Если пользователь введёт (8+3-) и нажмет кнопку "=", то программа продолжит работать и не будет вычислять введенное выражение.
        /// </summary>
        /// <param name="expression">Получаемая от пользователя строка.</param>
        /// <returns>
        /// Программа возвращает значение tpue, если в выражении все написано корректно.
        /// А если выражение будет написано не корректно, то программа вернёт false.
        /// </returns>
        public static bool CheckingCorrectnessTheExpression(string expression)
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
        /// Метод проверяет выражение на наличие слов и посторонних символов (не использующееся в математических выражениях).
        /// </summary>
        /// <param name="elements">Лист хранящий каждый символ.</param>
        /// <param name="args">При нахождении посторонних символов выведет ошибку и возвращается в Main(agrs).</param>
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
