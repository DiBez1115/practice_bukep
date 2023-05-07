using System;
using System.Diagnostics;
using System.Linq;

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

            //variables for main expression and find operators(a+b) and find type of operation(+, -, ...)
            string expression = Console.ReadLine();
            string[] operators = expression.Split(new char[] { '+', '-', '*', '/' });
            char operation = '/';


            foreach(string item in operators) //find type of operation
            {
                expression = expression.Replace(item, String.Empty);
            }

            operation = expression[0];

            //variables for calculate
            int number_1 = 0;
            int number_2 = 0;
            int result = 0;
            
            //variable for control errors
            bool find_errors = false;

            foreach(string item in operators) //check for numbers in input
            {
                if (item.All(char.IsDigit))
                {
                    number_1 = Int32.Parse(operators[0].ToString());
                    number_2 = Int32.Parse(operators[1].ToString());
                    break;
                }
                else
                {
                    Console.WriteLine("Введены некорректные значения.");
                    find_errors = true;
                    break;
                }
            }

            switch (operation)
            {
                case '+':
                    result = number_1 + number_2;
                    break;

                case '-':
                    result = number_1 - number_2; ;
                    break;

                case '*':
                    result = number_1 * number_2; ;
                    break;

                case '/':
                    if (number_2 == 0)
                    {
                        find_errors = true;
                        Console.WriteLine("На ноль делить нельзя.");
                        break;
                    }
                    else
                    {
                        result = number_1 / number_2; ;
                        break;
                    }
                default:
                    Console.WriteLine("Такая операция отсутствует.");
                    break;
            }

            if (!find_errors)
            {
                Console.WriteLine($"{number_1}{operation}{number_2}={result}");
            }
            Console.Write("Для продолжения нажмите Enter для выхода нажмите любую клавишу на клавиатуре.");
            push_key = Console.ReadKey().Key;
        }
    }
}
