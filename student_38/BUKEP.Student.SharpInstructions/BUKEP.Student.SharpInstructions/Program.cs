using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUKEP.Student.SharpInstructions
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
            Console.WriteLine("Для вызова выполняемой подпрограммы укажите ее номер и нажните Enter:\n1 - IF ELSE\n2 - WHILE\n3 - DO WHILE\n4 - FOR\n5 - FOREACH\n6 - SWITCH");
            string SelectionData = Console.ReadLine();
            switch (SelectionData)
            {
                case "1":
                    Console.WriteLine("Введите диапозон значений через ENTER для конструкции IF ELSE");
                    int inputs1 = int.Parse(Console.ReadLine());
                    int inputs2 = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine($"Данные введенные пользователем: {inputs1}, {inputs2}");
                    if (inputs1 <= inputs2)
                    {
                        for (int i = inputs1; i <= inputs2; i++)
                        {
                            Console.WriteLine(i);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Введен недопустимый диапазон значений!");
                    }
                    Console.WriteLine("Для продолжения нажмите ENTER для выхода нажмите ESC");
                    Key = Console.ReadKey().Key;
                    break;
                case "2":
                    Console.WriteLine("Введите диапозон значений через ENTER для цикла WHILE");
                    int inputs3 = int.Parse(Console.ReadLine());
                    int inputs4 = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine($"Данные введенные пользователем: {inputs3}, {inputs4}");
                    if (inputs3 <= inputs4)
                    {
                        while (inputs3 <= inputs4)
                        {
                            Console.WriteLine(inputs3);
                            inputs3++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введен недопустимый диапазон значений!");
                    }
                    Console.WriteLine("Для продолжения нажмите ENTER для выхода нажмите ESC");
                    Key = Console.ReadKey().Key;
                    break;
                case "3":
                    Console.WriteLine("Введите диапозон значений через ENTER для цикла DO WHILE");
                    int inputs5 = int.Parse(Console.ReadLine());
                    int inputs6 = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine($"Данные введенные пользователем: {inputs5}, {inputs6}");
                    if (inputs5 <= inputs6)
                    {
                        do
                        {
                            Console.WriteLine(inputs5);
                            inputs5++;
                        }
                        while (inputs5 <= inputs6);
                    }
                    else
                    {
                        Console.WriteLine("Введен недопустимый диапазон значений!");
                    }
                    Console.WriteLine("Для продолжения нажмите ENTER для выхода нажмите ESC");
                    Key = Console.ReadKey().Key;
                    break;
                case "4":
                    Console.WriteLine("Введите диапозон значений через ENTER для цикла FOR");
                    int inputs7 = int.Parse(Console.ReadLine());
                    int inputs8 = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine($"Данные введенные пользователем: {inputs7}, {inputs8}");
                    if (inputs7 <= inputs8)
                    {
                        for (int i = inputs7; i <= inputs8; i++)
                        {
                            Console.WriteLine(i);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введен недопустимый диапазон значений!");
                    }
                    Console.WriteLine("Для продолжения нажмите ENTER для выхода нажмите ESC");
                    Key = Console.ReadKey().Key;
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("Введите предложение которое хотите разбить на символы для оператора FOREACH");
                    var inputs9 = Console.ReadLine();
                    var num = new List<object>();
                    foreach (var numbers in inputs9)
                    {
                        num.Add(numbers);
                    }
                    for (int i = 0; i < num.Count; i++)
                    {
                        Console.WriteLine(num[i]);

                    }
                    Console.WriteLine("Для продолжения нажмите ENTER для выхода нажмите ESC");
                    Key = Console.ReadKey().Key;
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine("Укажите номер месяца для конструкции SWITCH");
                    string inputs11 = Console.ReadLine();
                    switch (inputs11)
                    {
                        case "1":
                            Console.WriteLine("Январь");
                            break;
                        case "2":
                            Console.WriteLine("Февраль");
                            break;
                        case "3":
                            Console.WriteLine("Март");
                            break;
                        case "4":
                            Console.WriteLine("Апрель");
                            break;
                        case "5":
                            Console.WriteLine("Май");
                            break;
                        case "6":
                            Console.WriteLine("Июнь");
                            break;
                        case "7":
                            Console.WriteLine("Июль");
                            break;
                        case "8":
                            Console.WriteLine("Август");
                            break;
                        case "9":
                            Console.WriteLine("Сентябрь");
                            break;
                        case "10":
                            Console.WriteLine("Октябрь");
                            break;
                        case "11":
                            Console.WriteLine("Ноябрь");
                            break;
                        case "12":
                            Console.WriteLine("Декабрь");
                            break;
                        default:
                            Console.WriteLine("Такого месяца не существует.");
                            break;
                    }
                    Console.WriteLine("Для продолжения нажмите ENTER для выхода нажмите ESC");
                    Key = Console.ReadKey().Key;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Введена неверная команда.");
                    Key = Console.ReadKey().Key;
                    break;



            }

        }
    }
}
