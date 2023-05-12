using System;
using System.Diagnostics;
using System.Windows.Forms;
namespace BUKEP.Student.SharpInstructions
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Clear();
                ConsoleKeyInfo key;

                Console.WriteLine("Для вызова выполняемой подпрограммы укажите ее номер и нажните Enter:\n1 - IF ELSE\n2 - WHILE\n3 - DO WHILE\n4 - FOR\n5 - FOREACH\n6 - SWITCH");

                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        while (true)
                        {
                            Mortgage();

                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc: ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case "2":
                        while (true)
                        {
                            GetWiki();

                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc: ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case "3":
                        while (true)
                        {
                            DoWhileLoop();
                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc: ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case "4":
                        while (true)
                        {
                            MultiplyTable();

                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc: ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case "5":
                        while (true)
                        {
                            TaskList();

                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc: ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case "6":
                        while (true)
                        {
                            PCOffOn();

                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc: ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    default:
                        Console.WriteLine("Неизвестная операция!");
                        break;
                }
            }
        }

        /// <summary>
        /// Сравнение двух чисел
        /// <summary>
        static void Mortgage()
        {
            Console.Clear();
            Console.WriteLine("Программа для сравнивания двух чисел.");
            Console.Write("Введите число 1: ");
            int number_1 = int.Parse(Console.ReadLine());
            Console.Write("Введите число 2: ");
            int number_2 = int.Parse(Console.ReadLine());

            if (number_1 < number_2) Console.WriteLine($"Число {number_1} меньше числа {number_2}");
            else if (number_1 == number_2) Console.WriteLine($"Число {number_1} равно числу {number_2}");
            else
            {
                Console.WriteLine($"Число {number_2} больше числа {number_1}");
            }
        }

        /// <summary>
        /// Получение и копирование ссылки в буфер обмена и открытие браузера
        /// <summary>
        static void GetWiki()
        {
            Console.Clear();
            Console.WriteLine("Введите любое слово, а я найду статью в Wiki по этому слову и отдам вам ссылку на нее: ");
            while (true)
            {
                Console.WriteLine("Для завершения работы программы введите 'quit': ");
                string Data = Console.ReadLine();
                if (Data == "quit") break;

                else
                {
                    Clipboard.Clear();
                    string Link = $"https://ru.wikipedia.org/wiki/{Data}";
                    Console.WriteLine("Ваша ссылка находится в буфере обмена, вставьте ее! :)");
                    Process.Start("http://google.com");
                    Clipboard.SetText(Link);
                }
            }
        }

        /// <summary>
        /// Вывод таблицы умножения
        /// <summary>
        static void MultiplyTable()
        {
            Console.Clear();
            Console.WriteLine("Проргамма для вывода списка умножения вашего числа на цифры.");
            Console.WriteLine("Введите любое число, для создания списка умножения на цифры.");
            int user_number = int.Parse(Console.ReadLine());
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{user_number} * {i} = {user_number * i}");
            }
        }

        /// <summary>
        /// Ввод и вывод списка заданий пользователя
        /// <summary>
        static void TaskList()
        {
            Console.Clear();
            Console.WriteLine("Программа для записи и вывода ваших заданий на день.");
            Console.Write("Сколько заданий вам требуется ввести: ");
            int CountOfTasks = int.Parse(Console.ReadLine());

            string[] Tasks = new string[CountOfTasks];

            for(int i = 0; i < CountOfTasks; i++)
            {
                Console.WriteLine($"Введите задание {i+1}");
                Tasks[i] = Console.ReadLine();
            }

            Console.Write("Хотите ли сейчас вывести все ваши задания?(да/нет) ");
            string answer = Console.ReadLine();
            if(answer.ToLower() == "да")
            {
                Console.WriteLine($"Ваши задания на {DateTime.Today}: ");
                foreach (string task in Tasks)
                {
                    Console.WriteLine(task);
                }
            }
            else if(answer.ToLower() != "нет")
            {
                Console.WriteLine("Введено неизвестное значение!");
            }
        }

        /// <summary>
        /// Включение и отключение таймера завершения работы ПК
        /// <summary>
        static void PCOffOn()
        {
            Console.Clear();

            Console.WriteLine("Данная программа позволяет добавить таймер выключения компьютера. Для выхода введите 'q'");
            Console.WriteLine("Через сколько выключить компьютер? (1. 30 мин, 2. 1 час, 3. 2 часа) ");
            Console.WriteLine("Для того чтобы отменить таймер выключения, введите off");
            string action = Console.ReadLine();
            if (action == "off")
            {
                Process.Start("cmd", "/c shutdown -a");
            }
            else
            {
                switch (action.ToLower())
                {
                    case "1":
                        Process.Start("cmd", "/c shutdown -s -f -t 1800");
                        break;
                    case "2":
                        Process.Start("cmd", "/c shutdown -s -f -t 3600");
                        break;
                    case "3":
                        Process.Start("cmd", "/c shutdown -s -f -t 7200");
                        break;

                    default:
                        Console.WriteLine("Неизвестная операция.");
                        break;
                }
            }
        }

        /// <summary>
        /// Вывод последовательности циклом Do While
        /// <summary>
        static void DoWhileLoop()
        {
            Console.Clear();

            Console.Write("Для того чтобы использовать цикл DO WHILE, который выведет последовательно числа введите стартовое число: ");
            int Start = int.Parse(Console.ReadLine());

            Console.Write("Введите конечное число: ");
            int End = int.Parse(Console.ReadLine());

            Console.WriteLine($"Последовательность чисел от {Start} до {End + 1}");
            do
            {
                Console.WriteLine(Start);
            } while (Start++ <= End);
        }
    }
}
