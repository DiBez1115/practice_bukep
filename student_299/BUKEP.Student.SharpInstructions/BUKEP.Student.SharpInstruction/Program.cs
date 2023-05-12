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
                        Console.WriteLine("Case");
                        break;
                    case 4:
                        Console.WriteLine("Case");
                        break;
                    case 5:
                        Console.WriteLine("Case");
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
                string data = Console.ReadLine();
                if (data == "quit") break;

                else
                {
                    Clipboard.Clear();
                    string link = $"https://ru.wikipedia.org/wiki/{data}";
                    Console.WriteLine("Ваша ссылка находится в буфере обмена, зайдите в браузер и вставьте ее! :)");
                    Clipboard.SetText(link);
                }
            }
        }
    }
}
