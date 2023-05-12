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

                int answer = int.Parse(Console.ReadLine());
                switch (answer)
                {
                    case 1:
                        while (true)
                        {
                            Mortgage();
                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc: ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case 2:
                        while (true)
                        {
                            GetWiki();
                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc: ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case 3:
                        while (true)
                        {
                            Console.Clear();
                            Console.Write("Для того чтобы использовать цикл DO WHILE, который выведет последовательно числа введите стартовое число: ");
                            int Start = int.Parse(Console.ReadLine());
                            Console.Write("Введите конечное число: ");
                            int End = int.Parse(Console.ReadLine());
                            Console.WriteLine($"Последовательность чисел от {Start} до {End+1}");
                            do
                            {
                                Console.WriteLine(Start);
                            } while (Start++ <= End);
                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc: ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case 4:
                        while (true)
                        {
                            MultiplyTable();
                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc: ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case 5:
                        while (true)
                        {
                            TaskList();
                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc: ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case 6:
                        Console.WriteLine("Case");
                        break;
                }
            }
        }
        static void Mortgage()
        {
            Console.Clear();
            Console.Write("Для того, чтобы посчитать вашу новую ежемесячную плату по кредиту, введите сколько денег вы внесли за этот месяц: ");
            float DepositMoney = float.Parse(Console.ReadLine());

            Console.Write("Укажите ваш текущую ежемесячную плату по кредиту: ");
            float MountMoney = float.Parse(Console.ReadLine());

            if ((MountMoney - DepositMoney) >= 10000)
            {
                MountMoney -= 1500;
            }
            else if(MountMoney < DepositMoney && (MountMoney - DepositMoney) <= 5000)
            {
                MountMoney -= 500;
            }
            else if (DepositMoney < MountMoney)
            {
                MountMoney += 500;
            }
            Console.WriteLine($"Новая ставка по вашему кредиту - {MountMoney}");
        }
 
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

        static void MultiplyTable()
        {
            Console.Clear();
            Console.WriteLine("Таблица умножения от 0 до 9: ");
            for(int i = 0; i <= 10; i++)
            {
                for(int j = 1; j <= 10; j++)
                {
                    Console.WriteLine($"{i} * {j} = {i * j}");
                }
                Console.WriteLine();
            }
        }

        static void TaskList()
        {
            Console.Clear();
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
    }
}
