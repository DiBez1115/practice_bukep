using System;
using System.Diagnostics;

namespace BUKEP.Student.ConsoleCalculator
{
    internal class Program
    {
        public static ConsoleKey push_key = ConsoleKey.Enter;
        static void Main(string[] args)
        {
            while(push_key == ConsoleKey.Escape)
            {
                Process.GetCurrentProcess().Kill();
            }
            while (push_key == ConsoleKey.Enter)
            {
                Console.Clear();
                Calculate();
            }

        }

        public static void Calculate()
        {
            Console.WriteLine("Введите простое математическое выражение для вычисления операции (+ или - или * или /) над двумя числами. По завершению ввода операции нажмите Enter:");
            string expression = Console.ReadLine();
            string[] operators = expression.Split(new char[] { '+', '-', '*', '/' });
            int result;
            for (int i = 0; i < expression.Length; i++)
            {
                switch (expression[i])
                {
                    case '+':
                        result = Int32.Parse(operators[0]) + Int32.Parse(operators[1]);
                        Console.WriteLine($"{operators[0]}{expression[i]}{operators[1]}={result}");
                        Console.WriteLine("Для продолжения нажмите Enter для выхода нажмите любую клавишу на клавиатуре.");
                        push_key = Console.ReadKey().Key;
                        break;

                    case '-':
                        result = Int32.Parse(operators[0]) - Int32.Parse(operators[1]);
                        Console.WriteLine($"{operators[0]}{expression[i]}{operators[1]}={result}");
                        Console.WriteLine("Для продолжения нажмите Enter для выхода нажмите любую клавишу на клавиатуре.");
                        push_key = Console.ReadKey().Key;
                        break;

                    case '*':
                        result = Int32.Parse(operators[0]) * Int32.Parse(operators[1]);
                        Console.WriteLine($"{operators[0]}{expression[i]}{operators[1]}={result}");
                        Console.WriteLine("Для продолжения нажмите Enter для выхода нажмите любую клавишу на клавиатуре.");
                        push_key = Console.ReadKey().Key;
                        break;

                    case '/':
                        result = Int32.Parse(operators[0]) / Int32.Parse(operators[1]);
                        Console.WriteLine($"{operators[0]}{expression[i]}{operators[1]}={result}");
                        Console.WriteLine("Для продолжения нажмите Enter для выхода нажмите любую клавишу на клавиатуре.");
                        push_key = Console.ReadKey().Key;
                        break;
                }
            }   
        }
    }
}
