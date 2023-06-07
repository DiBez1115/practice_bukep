using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUKEP.Student.Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите простое математическое выражение без пробелов: ");
                var InputExpression = Console.ReadLine();
                var SplitExpression = InputExpression.Split(new char[] { '+', '-', '*', '/' }).ToList();
                var Elemnets = new List<object>();
                foreach (var split in SplitExpression)
                {
                    Elemnets.Add(split);
                }
                for (int i = 0; i < InputExpression.Length; i++)
                {
                    switch (InputExpression[i])
                    {
                        case '+':
                            var Num1 = Convert.ToDouble(Elemnets[0]);
                            var Num2 = Convert.ToDouble(Elemnets[1]);
                            var Sum = Num1 + Num2;
                            Console.WriteLine($"{Num1} + {Num2} = {Sum}");
                            break;
                        case '-':
                            var Num3 = Convert.ToDouble(Elemnets[0]);
                            var Num4 = Convert.ToDouble(Elemnets[1]);
                            var Subtract = Num3 - Num4;
                            Console.WriteLine($"{Num3} - {Num4} = {Subtract}");
                            break;
                        case '*':
                            var Num5 = Convert.ToDouble(Elemnets[0]);
                            var Num6 = Convert.ToDouble(Elemnets[1]);
                            var Multiplication = Num5 * Num6;
                            Console.WriteLine($"{Num5} * {Num6} = {Multiplication}");
                            break;
                        case '/':
                            var Num7 = Convert.ToDouble(Elemnets[0]);
                            var Num8 = Convert.ToDouble(Elemnets[1]);
                            if (Num8 != 0)
                            {
                                var Division = Num7 / Num8;
                                Console.WriteLine($"{Num7} / {Num8} = {Division}");
                            }
                            else
                            {
                                Console.WriteLine("На ноль делить нельзя!");
                            }
                            break;
                    }
                }
                Console.Write("Для повторного ввода операции нажмите Enter, для завершения приложения Esc.");
                if (Console.ReadKey().Key == ConsoleKey.Escape) { break; }
            }
        }
    }
}

