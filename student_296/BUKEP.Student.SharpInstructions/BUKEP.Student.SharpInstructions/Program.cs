using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUKEP.Student.SharpInstructions
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Для вызова выполняемой подпрограммы укажите ее номер и нажните Enter:\n1 - IF ELSE\n2 - WHILE\n3 - DO WHILE\n4 - FOR\n5 - FOREACH\n6 - SWITCH\nНажмите 0, если хотите прекратить работу программы");
                string Number = Console.ReadLine();
                if (Number == "0")
                {
                    break;
                }
                ConsoleKeyInfo key;
                switch (Number)
                {
                    case "1":
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Сравнение чисел через IF Else");
                            Console.WriteLine("Введите первое число: ");
                            int IfElseNum1 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите второе число: ");
                            int IfElseNum2 = int.Parse(Console.ReadLine());
                            if (IfElseNum1 > IfElseNum2) Console.WriteLine($"Число {IfElseNum1} больше числа {IfElseNum2}");
                            else if (IfElseNum1 < IfElseNum2) Console.WriteLine($"Число {IfElseNum1} менше числа {IfElseNum2}");
                            else if (IfElseNum1 == IfElseNum2) Console.WriteLine($"Числа {IfElseNum1} и {IfElseNum2} равны");

                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc: ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case "2":
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Простой счётчик через while");
                            Console.WriteLine("Введите переменную для счёта: ");
                            int WhileNum = int.Parse(Console.ReadLine());
                            int counter = 1;
                            while (counter <= WhileNum)
                            {
                                Console.WriteLine($"Текущее состояние счётчика: {counter}");
                                counter++;
                            }

                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc: ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case "3":
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Сумма чисел последовательности через do while");
                            int DoWihleNum;
                            int summ = 0;
                            do
                            {
                                Console.Write("Введённое число (0 - закончить запись чисел): ");
                                DoWihleNum = int.Parse(Console.ReadLine());
                                summ += DoWihleNum;
                            }
                            while (DoWihleNum != 0);
                            Console.WriteLine("sum = {0}", summ);

                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc: ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case "4":
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Таблица умножения через for");
                            for (int i = 1; i < 10; i++)
                            {
                                for (int j = 1; j < 10; j++)
                                {
                                    Console.Write($"{i * j} \t");
                                }
                                Console.WriteLine();
                            }

                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc: ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case "5":
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Разложить слово по буквам foreach");
                            Console.WriteLine("Введите слово для разложения: ");
                            string WordForeach = Console.ReadLine();
                            foreach (char letter in WordForeach)
                            {
                                Console.WriteLine($"\t {letter}");
                            }

                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc: ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case "6":
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Определение гласной через case");
                            char ch;
                            Console.WriteLine("Введите русскую букву");
                            ch = Convert.ToChar(Console.ReadLine());
                            switch (Char.ToLower(ch))
                            {
                                case 'а':
                                    Console.WriteLine("Гласная");
                                    break;
                                case 'у':
                                    Console.WriteLine("Гласная");
                                    break;
                                case 'о':
                                    Console.WriteLine("Гласная");
                                    break;
                                case 'ы':
                                    Console.WriteLine("Гласная");
                                    break;
                                case 'и':
                                    Console.WriteLine("Гласная");
                                    break;
                                case 'э':
                                    Console.WriteLine("Гласная");
                                    break;
                                case 'я':
                                    Console.WriteLine("Гласная");
                                    break;
                                case 'ю':
                                    Console.WriteLine("Гласная");
                                    break;
                                case 'е':
                                    Console.WriteLine("Гласная");
                                    break;
                                case 'ё':
                                    Console.WriteLine("Гласная");
                                    break;
                                default:
                                    Console.WriteLine("Согласная");
                                    break;
                            }
                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc: ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                }
            }
        }
    }
}