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
            Console.WriteLine("Введите простое математическое выражение для вычисления операции (+ или - или * или /) над двумя числами. По завершению ввода операции нажмите Enter:");
            var InputData = Console.ReadLine();
            var SplitData = InputData.Split(new char[] {'+', '-', '*', '/' }).ToList();
            var elem = new List<object>();
            foreach (var split in SplitData) 
            {
                elem.Add(split);
            }
            bool operatorFound = false;
            for (int i = 0; i < InputData.Length; i++)
            {
                switch (InputData[i])
                {
                    case '+':
                        var number1 = Convert.ToDouble(elem[0]);
                        var number2 = Convert.ToDouble(elem[1]);
                        double Sum = number1 + number2;
                        Console.WriteLine($"{number1} + {number2} = {Sum}");
                        Console.WriteLine("Для продолжения нажмите Enter для выхода нажмите любую клавишу на клавиатуре");
                        Key = Console.ReadKey().Key;
                        return;
                    case '-':
                        var number3 = Convert.ToDouble(elem[0]);
                        var number4 = Convert.ToDouble(elem[1]);
                        double Addition = number3 - number4;
                        Console.WriteLine($"{number3} - {number4} = {Addition}");
                        Console.WriteLine("Для продолжения нажмите Enter для выхода нажмите любую клавишу на клавиатуре");
                        Key = Console.ReadKey().Key;
                        return;
                    case '*':
                        var number5 = Convert.ToDouble(elem[0]);
                        var number6 = Convert.ToDouble(elem[1]);
                        double Multiplication = number5 * number6;
                        Console.WriteLine($"{number5} * {number6} = {Multiplication}");
                        Console.WriteLine("Для продолжения нажмите Enter для выхода нажмите любую клавишу на клавиатуре");
                        Key = Console.ReadKey().Key;
                        return;
                    case '/':
                        var number7 = Convert.ToDouble(elem[0]);
                        var number8 = Convert.ToDouble(elem[1]);
                        if (number8 != 0)
                        {
                            double Division = number7 / number8;
                            Console.WriteLine($"{number7} / {number8} = {Division}");
                            Console.WriteLine("Для продолжения нажмите Enter для выхода нажмите любую клавишу на клавиатуре");
                            Key = Console.ReadKey().Key;
                        }
                        else
                        {
                            Console.WriteLine("На ноль делить нельзя!");
                            Console.WriteLine("Для продолжения нажмите Enter для выхода нажмите любую клавишу на клавиатуре");
                            Key = Console.ReadKey().Key;
                            return;
                        }
                        return;
                }
                
            }
            if(!operatorFound)
            {
                Console.WriteLine("Невернная форма ввода!");
                Console.WriteLine("Для продолжения нажмите Enter для выхода нажмите любую клавишу на клавиатуре");
                Key = Console.ReadKey().Key;
            }
            
            
        
       }
    }
}
