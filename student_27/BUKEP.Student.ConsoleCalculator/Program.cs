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

                string lineNoSpase = line.Replace(" ", "");

                if (Calculator.Calculator.CheckIfLettersInExpression(lineNoSpase) == false)
                {
                    string expression = "";

                    foreach (char symbol in lineNoSpase)
                    {
                        if (symbol != ' ')
                        {
                            expression += symbol;
                        }

                    }

                    if (expression != "")
                    {
                        try 
                        {
                            Console.Write("Результат: " + expression + "=" + Calculator.Calculator.CalculateMathematicalExpression(expression));
                        }

                        catch(DivideByZeroException) 
                        {
                            Console.WriteLine("Ошибка!!! На ноль делить нельзя!");
                        }

                        catch (Exception)
                        {
                            Console.WriteLine("Ошибка!!! Не удалось распознать выражение!");
                        }

                        Console.ReadKey();

                        Console.Clear();
                    }

                    else
                    {
                        Console.WriteLine("Ошибка!!! Не удалось распознать выражение!");

                        Console.ReadKey();

                        Console.Clear();
                    }

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