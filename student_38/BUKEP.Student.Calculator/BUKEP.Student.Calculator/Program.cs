using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUKEP.Student.Calculator
{
    class Program
    {
        public static ConsoleKey Key = ConsoleKey.Enter;
        static void Main(string[] args)
        {
            while (Key == ConsoleKey.Enter)
            {
                Run();
                Console.Clear();
            }
            while (Key != ConsoleKey.Enter)
            {
                Environment.Exit(0);
            }
        }
        static void Run()
        {
            Console.Write("Введите математическое выражение для вычисления операции с приоритетами в виде <<(>> <<)>> или знаками (+ или - или * или /).\nПо завершению ввода операции нажмите Enter:");
            string dataStack = Console.ReadLine();
            string splitData = dataStack.Replace(" ", "");
            var stackOp = new Stack<char>();
            var stackNum = new Stack<double>();
            int i = 0;
            string str = "";
            bool lastCharIsOperator = true;
            while (i < dataStack.Length)
            {
                if (Char.IsDigit(dataStack[i]) || dataStack[i] == '-')
                {
                    if (dataStack[i] == '-')
                    {
                        str += '-';
                        i++;
                    }
                    while (i < dataStack.Length && (Char.IsDigit(dataStack[i]) || dataStack[i] == ','))
                    {
                        str += dataStack[i];
                        i++;
                    }
                    double num = double.Parse(str);
                    stackNum.Push(num);
                    lastCharIsOperator = false;
                    str = "";
                }
                else if (dataStack[i] == '(')
                {
                    stackOp.Push(dataStack[i]);
                    i++;
                }
                else if (dataStack[i] == ')')
                {
                    while (stackOp.Peek() != '(')
                    {
                        char op = stackOp.Pop();
                        double num2 = stackNum.Pop();
                        double num1 = stackNum.Pop();
                        double result = PerformOperation(num1, num2, op);
                        stackNum.Push(result);
                    }
                    stackOp.Pop();
                    i++;
                    lastCharIsOperator = false;
                }
                else if (dataStack[i] == '+' || dataStack[i] == '-' || dataStack[i] == '*' || dataStack[i] == '/')
                {
                    while (stackOp.Count > 0 && HasPrecedence(dataStack[i], stackOp.Peek()))
                    {
                        char op = stackOp.Pop();
                        double num2 = stackNum.Pop();
                        double num1 = stackNum.Pop();
                        double result = PerformOperation(num1, num2, op);
                        stackNum.Push(result);
                    }
                    stackOp.Push(dataStack[i]);
                    i++;
                    lastCharIsOperator = true;
                }
                else if (dataStack[i] == ' ')
                {
                    i++;
                }
                else
                {
                    Console.WriteLine("Введено неверное выражение!");
                    Console.WriteLine("Для продолжения нажмите Enter для выхода нажмите любую клавишу на клавиатуре");
                    Console.ReadKey();
                    return;
                }
            }
            while (stackOp.Count > 0)
            {
                char op = stackOp.Pop();
                double num2 = stackNum.Pop();
                double num1 = stackNum.Pop();
                double result = PerformOperation(num1, num2, op);
                stackNum.Push(result);
            }
            Console.WriteLine($"{splitData}={stackNum.Peek()}");
            Console.WriteLine("Для продолжения нажмите Enter для выхода нажмите любую клавишу на клавиатуре");
            Key = Console.ReadKey().Key;
        }
        static bool HasPrecedence(char op1, char op2)
        {
            if (op2 == '(' || op2 == ')')
            {
                return false;
            }
            if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
            {
                return false;
            }
            return true;
        }
        static double PerformOperation(double num1, double num2, char op)
        {
            switch (op)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    if (num2 == 0)
                    {
                        Console.WriteLine("Нельзя делить на ноль!");
                        Console.WriteLine("Для продолжения нажмити любую клавишу.");
                        Console.ReadKey();
                        Console.Clear();
                        Run();
                    }
                    return num1 / num2;
                default:
                    return 0;
            }
        }
    }
}