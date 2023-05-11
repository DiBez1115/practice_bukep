using System;
using System.Collections.Generic;
using BUKEP.Student.Calculator;

namespace BUKEP.Student.ConsoleCalculator
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
                
                if (Calculator.Calculator.CheckIfLettersInExpression(line) == false)
                {
                    string expression = "";

                    foreach (char symbol in line)
                    {
                        if (symbol != ' ')
                        {
                            expression += symbol;
                        }

                    }

                    Console.Write("Результат: "+ expression + "=" + Calculator.Calculator.CalculateMathematicalExpression(expression));

                    Console.ReadKey();

                    Console.Clear();
                }

                else
                {
                    Console.WriteLine("Ошибка!!! Не удалось распознать выражение!");

                    Console.ReadKey();

                    Console.Clear();
                }

                Console.Write("Для повторного ввода операции нажмите Enter, для завершения приложения Esc.");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }

            }

        }

    }

}