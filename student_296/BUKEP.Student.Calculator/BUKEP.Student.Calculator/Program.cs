using System;
using System.Collections.Generic;

namespace BUKEP.Student.CalculationOfDegeneracyulator
{

    /// <summary>
    /// Взаимодействие с пользователем 
    /// </summary>
    class Program
    {

        /// <summary>
        /// Ввод выражение, подсчёт и вывод
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите выражение: ");
                Console.WriteLine(ReversePolishNotation.Calculate(Console.ReadLine()));
            }
        }
    }

    /// <summary>
    /// Калькулятор, вычисляющий выражения
    /// </summary>
    class ReversePolishNotation
    {
        /// <summary>
        /// Проверка на разделитель 
        /// </summary>
        /// <param name="delimiter">Переменная, включающая символ "=" или пробел</param>
        /// <returns>
        /// Возвращает true, если проверяемый символ - разделитель ("пробел" или "равно")
        /// Если разделитель отсутствует, False
        /// </returns>
        static private bool IsDelimeter(char delimiter)
        {
            if ((" =".IndexOf(delimiter) != -1))
                return true;
            return false;
        }

        /// <summary>
        /// Проверка на оператор
        /// </summary>
        /// <param name="operations">Переменная, включающая символ-оператор</param>
        /// <returns>
        /// Возвращает true, если проверяемый символ - оператор
        /// Если проверяемый символ не оператор - False
        /// </returns> 
        static private bool IsOperator(char operations)
        {
            if (("+-/*^()".IndexOf(operations) != -1))
                return true;
            return false;
        }

        /// <summary>
        /// Проверка на приоритет
        /// </summary>
        /// <param name="priority">Переменная, включающая значение приоритета</param>
        /// <returns>
        /// Возвращает значение приоритета оператора</returns>
        static private byte GetPriority(char priority)
        {
            switch (priority)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                default: return 6;
            }
        }

        /// <summary>
        /// Принимает выражение в виде строки и возвращает результат
        /// Использует другие методы класса
        /// </summary>
        /// <param name="input">Переменная, включающая введённую пользователем строку</param>
        /// <param name="output">Строка, включающая решённое выражение</param>
        /// <param name="result">Число - решённое выражение</param>
        /// <returns>
        /// Возвращает результат решения
        /// </returns>
        static public double Calculate(string input)
        {
            string output = GetExpression(input); 
            double result = Counting(output); 
            return result; 
        }

        /// <summary>
        /// Преобразует входную строку с выражением в постфиксную запись
        /// </summary>
        /// <param name="input">Переменная, включающая введённую пользователем строку</param>
        /// <param name="output">Строка для хранения выражения</param>
        /// <param name="operStack">Стэк для хранения операторов</param>
        /// <param name="bracket">Строка, включающая выражение до открывающей скобки или закрывающей</param>
        /// <returns>
        /// Возвращает выражение в постфиксной записи
        /// </returns>
        static private string GetExpression(string input)
        {
            string output = string.Empty; 
            Stack<char> operStack = new Stack<char>(); 
            for (int iteration = 0; iteration < input.Length; iteration++) 
            {
                if (IsDelimeter(input[iteration]))
                    continue; 

                if (Char.IsDigit(input[iteration])) 
                {
                    while (!IsDelimeter(input[iteration]) && !IsOperator(input[iteration]))
                    {
                        output += input[iteration]; 
                        iteration++; 

                        if (iteration == input.Length) break; 
                    }
                    output += " "; 
                    iteration--; 
                }
                if (IsOperator(input[iteration])) 
                {
                    if (input[iteration] == '(') 
                        operStack.Push(input[iteration]); 
                    else if (input[iteration] == ')') 
                    {
                        char bracket = operStack.Pop();
                        while (bracket != '(')
                        {
                            output += bracket.ToString() + ' ';
                            bracket = operStack.Pop();
                        }
                    }
                    else 
                    {
                        if (operStack.Count > 0) 
                            if (GetPriority(input[iteration]) <= GetPriority(operStack.Peek())) 
                                output += operStack.Pop().ToString() + " "; 
                        operStack.Push(char.Parse(input[iteration].ToString())); 
                    }
                }
            }
            while (operStack.Count > 0)
                output += operStack.Pop() + " ";

            return output; 
        }

        /// <summary>
        /// Вычисляет значение выражения, преобразованного в постфиксную запись
        /// </summary>
        /// <param name="input">Строка с выражением</param> 
        /// <param name="result">Число - результат вычисления</param> 
        /// <param name="temp">Стэк для временного решения</param> 
        /// <param name="valueOne">Переменная - первое число</param> 
        /// <param name="valueTwo">Переменная - второе число</param> 
        /// <returns>
        /// Возвращает результат вычисления из стека
        /// </returns>
        static private double Counting(string input)
        {
            double result = 0; 
            Stack<double> temp = new Stack<double>(); 

            for (int iteration = 0; iteration < input.Length; iteration++) 
            {
                if (Char.IsDigit(input[iteration]))
                {
                    string valueOne = string.Empty;

                    while (!IsDelimeter(input[iteration]) && !IsOperator(input[iteration])) 
                    {
                        valueOne += input[iteration]; 
                        iteration++;
                        if (iteration == input.Length) break;
                    }
                    temp.Push(double.Parse(valueOne)); 
                    iteration--;
                }
                else if (IsOperator(input[iteration])) 
                {
                    double valueOne = temp.Pop();
                    double valueTwo = temp.Pop();

                    switch (input[iteration]) 
                    {
                        case '+': result = valueTwo + valueOne; break;
                        case '-': result = valueTwo - valueOne; break;
                        case '*': result = valueTwo * valueOne; break;
                        case '/': result = valueTwo / valueOne; break;
                        case '^': result = double.Parse(Math.Pow(double.Parse(valueTwo.ToString()), double.Parse(valueOne.ToString())).ToString()); break;
                    }
                    temp.Push(result); 
                }
            }
            return temp.Peek(); 
        }
    }
}
