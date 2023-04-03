using System;
using System.Collections.Generic;

namespace BUKEP.Student.Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите простое математическое выражение для вычисления операции (+ или - или * или /) над двумя числами. По завершению ввода операции нажмите Enter:");
                var InpuеData = Console.ReadLine();
                var result = InpuеData.Split(new char[] { '+', '-', '/', '*' });
                var elements = new List<object>();
                for (int a1 = 0; a1 < result.Length; a1++)
                {
                    var result1 = result[a1].Trim();
                    elements.Add(result1);
                }

                if (InpuеData.Contains("+")) elements.Insert(1, "+");
                if (InpuеData.Contains("-")) elements.Insert(1, "-");
                if (InpuеData.Contains("/")) elements.Insert(1, "/");
                if (InpuеData.Contains("*")) elements.Insert(1, "*");

                for (int i = 0; i < elements.Count; i++)
                {
                    switch (elements[i])
                    {
                        case "+":
                            var n1 = Convert.ToDouble(elements[elements.IndexOf("+") - 1]);
                            var n2 = Convert.ToDouble(elements[elements.IndexOf("+") + 1]);
                            double AddNum = n1 + n2;
                            elements.Add("= " + AddNum);
                            Print(elements);
                            Console.Clear();
                            break;

                        case "-":
                            var n3 = Convert.ToDouble(elements[elements.IndexOf("-") - 1]);
                            var n4 = Convert.ToDouble(elements[elements.IndexOf("-") + 1]);
                            AddNum = n3 - n4;
                            elements.Add("= " + AddNum);
                            Print(elements);
                            Console.Clear();
                            break;

                        case "*":
                            var n5 = Convert.ToDouble(elements[elements.IndexOf("*") - 1]);
                            var n6 = Convert.ToDouble(elements[elements.IndexOf("*") + 1]);
                            AddNum = n5 * n6;
                            elements.Add("= " + AddNum);
                            Print(elements);
                            Console.Clear();
                            break;

                        case "/":
                            var n7 = Convert.ToDouble(elements[elements.IndexOf("/") - 1]);
                            var n8 = Convert.ToDouble(elements[elements.IndexOf("/") + 1]);
                            if (n8 != 0)
                            {
                                AddNum = n7 / n8;
                                elements.Add("= " + AddNum);
                                Print(elements);
                            }
                            else
                                Console.WriteLine("На ноль делить нельзя");
                            Console.ReadKey();
                            Console.Clear();                            
                            break;
                    }
                }                
                Console.Write("Для повторного ввода операции нажмите Enter, для завершения приложения Esc.");
                
                    if (Console.ReadKey().Key == ConsoleKey.Escape) { break; }                                              
            }
        }
        static void Print(List<object> elems)
        {
            for (int a = 0; a < elems.Count; a++)
                Console.Write(elems[a] + " ");               
            Console.ReadKey();
            Console.Clear();
        }
    }
}