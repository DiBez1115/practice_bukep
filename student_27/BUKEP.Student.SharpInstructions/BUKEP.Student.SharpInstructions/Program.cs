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
                ConsoleKeyInfo key;
                Console.Clear();
                Console.Write($"Для вызова выполняемой подпрограммы укажите ее номер и нажните Enter:\n1 - IF ELSE\n2 - WHILE\n3 - DO WHILE\n4 - FOR\n5 - FOREACH\n6 - SWITCH\n-> ");
                var operation = Console.ReadLine().Trim();
                switch (operation)
                {
                    case "1":
                        while (true)
                        {
                            Console.Clear();                          
                            Console.WriteLine("Давайте сыграем в игру?\nПравила очень просты :)\nИгрок и компьютер кидают два кубика\nПобеждает тот кто наберет больше очков\nНажмите Enter, чтобы продолжить играть или Esc чтобы вернутся к списку программ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                            IfElsePlayerVsComp();
                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc:");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case "2":                       
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Для выполнения подпрограммы WHILE введите начальное число и количество повторений последовательно через Enter, для возврата к списку подпрограмм нажмите Esc: ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                            int a = 0;
                            Console.Write("-> ");
                            var input1 = Console.ReadLine().Trim(); // Начальное число. 
                            Console.Write("-> ");
                            var input2 = Console.ReadLine().Trim(); //Кол-во повторений.
                            try 
                            {
                                int x1 = int.Parse(input1);
                                int x2 = int.Parse(input2);

                            }
                            catch(FormatException) 
                            {
                                Console.WriteLine("Это НЕ число!!!\n");
                                Console.ReadKey();
                                goto case "2";
                            }
                            int elems = int.Parse(input1);
                            int elems1 = int.Parse(input2);
                            Console.Clear();
                            Console.WriteLine("Результат:");
                            while (a < elems1)
                            {
                                a++;
                                Console.WriteLine(elems);
                                elems++;
                            }
                            Console.ReadKey();
                            Console.Clear();
                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc:");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case "3":
                        while (true) 
                        {
                            Console.Clear();
                            Console.WriteLine("Для выполнения подпрограммы DO WHILE введите начальное число и количество повторений последовательно через Enter, для возврата к списку подпрограмм нажмите Esc: ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                            int a1 = 0;
                            Console.Write("-> ");
                            var input3 = Console.ReadLine().Trim(); // Начальное число. 
                            Console.Write("-> ");
                            var input4 = Console.ReadLine().Trim(); //Кол-во повторений.
                            try
                            {
                                int x1 = int.Parse(input3);
                                int x2 = int.Parse(input4);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Это НЕ число!!!\n");
                                Console.ReadKey();
                                goto case "3";
                            }
                            int elems2 = int.Parse(input3);
                            int elems3 = int.Parse(input4);
                            Console.Clear();
                            Console.WriteLine("Результат:");
                            do
                            {
                                a1++;
                                Console.WriteLine(elems2);
                                elems2++;
                            }
                            while (a1 < elems3);
                            Console.ReadKey();
                            Console.Clear();
                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc:");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case "4":
                        while (true) 
                        {
                            Console.Clear();
                            Console.WriteLine($"Для вычисления факториала введите число через Enter или нажмите Esc, чтобы вернутся к списку программ");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                            Console.Clear();
                            Console.Write("Введите число -> ");
                            var input5 = Console.ReadLine().Trim();
                            try {int x3 = int.Parse(input5); }
                            catch(FormatException) 
                            {
                                Console.WriteLine("Это НЕ число!!!\n");
                                Console.ReadKey();
                                goto case "4";
                            }
                            int input6 = int.Parse(input5);
                            Console.WriteLine ($"Факториал числа {input6} = {Fibonachi2(input6)}");
                            Console.ReadKey();
                            Console.Clear();
                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc:");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case "5":
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Нажмите Enter, чтобы ввести данные в лист или нажмите Esс, чтобы выйти");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                            Console.Clear();
                            Console.Write("Введите строку -> ");
                            var input7 = Console.ReadLine().Split(' ');
                            var elems2 = new List<object>();
                            foreach (var elem in input7)
                            {
                                var result = elem.Trim();
                                if (result != "") elems2.Add(result);
                            }
                            foreach (var elem in elems2)
                                Console.WriteLine($"<< {elem} >>");
                            Console.ReadKey();
                            Console.Clear();
                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc:");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    case "6":
                        while (true)
                        {
                            Console.Clear();
                            Console.Write($"Введите предложение которе нужно перевести в азбуку морзе или нажмите Esc, для возврата к списку подпрограмм\n");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;

                            var elements = Console.ReadLine().Split(' ');
                            var el = new List<string>();
                            var finish = "";
                            for (int i = 0; i < elements.Length; i++)
                            {
                                var result = elements[i].Trim();
                                var result1 = result.ToLower();
                                if (result1 != "") el.Add(result1);
                            }
                            for (int a = 0; a < el.Count; a++)
                            {
                                string res = el[a];
                                string resultat = "";
                                foreach (char c in res)
                                    resultat += SWMorseCode(c);
                                finish += resultat+"/";
                            }
                            Console.WriteLine(finish);
                            Console.ReadKey();
                            Console.Clear();
                            Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc:");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape) break;
                        }
                        break;
                    default:
                        Main(args);
                        break;
                }
            }
        }
        static void IfElsePlayerVsComp()
        {
            Random rand = new Random();         
            int player1 = rand.Next(1,7);
            int player2 = rand.Next(1,7);
            int comp1 = rand.Next(1,7);
            int comp2 = rand.Next(1,7);
            Console.Clear();
            Console.WriteLine($"Вы бросили кубик и вам выпало {player1} и {player2}");
            Console.ReadKey();
            int player = player1 + player2;
            int comp = comp1 + comp2;           
            if (player > comp) { Console.WriteLine($"Вы выиграли!!!\nВы набрали: {player} очков\nКомпьютер набрал: {comp} очков"); Console.ReadKey(); Console.Clear(); }
            else if (comp > player) { Console.WriteLine($"Вы проиграли!!!\nВы набрали: {player} очков\nКомпьютер набрал: {comp} очков"); Console.ReadKey(); Console.Clear(); }
        }
        static object SWMorseCode(char c )
        {
            object result = "";
            switch (c) 
            {
                case 'а':
                    result += "-*";
                    break;
                case 'б':
                    result += "-***";
                    break;
                case 'в':
                    result += "*--";
                    break;
                case 'г':
                    result += "--*";
                    break;
                case 'д':
                    result += "-**";
                    break;
                case 'е':
                    result += "*";
                    break;
                case 'ж':
                    result += "***-";
                    break;
                case 'з':
                    result += "--**";
                    break;
                case 'и':
                    result += "**";
                    break;
                case 'й':
                    result += "*---";
                    break;
                case 'к':
                    result += "-*-";
                    break;
                case 'л':
                    result += "*-**";
                    break;
                case 'м':
                    result += "--";
                    break;
                case 'н':
                    result += "-*";
                    break;
                case 'о':
                    result += "---";
                    break;
                case 'п':
                    result += "*--*";
                    break;
                case 'р':
                    result += "*-*";
                    break;
                case 'с':
                    result += "***";
                    break;
                case 'т':
                    result += "-";
                    break;
                case 'у':
                    result += "**-";
                    break;
                case 'ф':
                    result += "**-*";
                    break;
                case 'х':
                    result += "****";
                    break;
                case 'ц':
                    result += "-*-*";
                    break;
                case 'ч':
                    result += "---*";
                    break;
                case 'ш':
                    result += "----";
                    break;
                case 'щ':
                    result += "--*-";
                    break;
                case 'ъ':
                    result += "*--*-*";
                    break;
                case 'ы':
                    result += "-*--";
                    break;
                case 'ь':
                    result += "-**-";
                    break;
                case 'э':
                    result += "***-***";
                    break;
                case 'ю':
                    result += "**--";
                    break;
                case 'я':
                    result += "*-*-";
                    break;
                case '1':
                    result += "*----";
                    break;
                case '2':
                    result += "**---";
                    break;
                case '3':
                    result += "***--";
                    break;
                case '4':
                    result += "****-";
                    break;
                case '5':
                    result += "*****";
                    break;
                case '6':
                    result += "-****";
                    break;
                case '7':
                    result += "--***";
                    break;
                case '8':
                    result += "---**";
                    break;
                case '9':
                    result += "----*";
                    break;
                case '0':
                    result += "-----";
                    break;
                case '.':
                    result += "******";
                    break;
                case ',':
                    result += "*-*-*-";
                    break;
                case '?':
                    result += "**--**";
                    break;
                case '!':
                    result += "--**--";
                    break;
                default:
                    result += "?";
                    break;
            }
            return result;
        }
        static int Fibonachi2(int x)
        {
            int f = 1;

            for (int i = 1; i <= x; i++)
            {
                f *= i;
            }

            return f;
        }
    }
}