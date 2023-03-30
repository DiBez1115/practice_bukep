using System;
using System.Collections.Generic;

namespace BUKEP.Student.Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
        Console.WriteLine("Введите выражение состоящие из двух значений, между значениями должен быть пробел");
        var InpuеData = Console.ReadLine().Split(' ');
        var elements = new List<object>();
        foreach (var list in InpuеData) elements.Add(list);
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
                    break;

                case "-":
                    var n3 = Convert.ToDouble(elements[elements.IndexOf("-") - 1]);
                    var n4 = Convert.ToDouble(elements[elements.IndexOf("-") + 1]);
                    AddNum = n3 - n4;
                    elements.Add("= " + AddNum);
                    Print(elements);
                    break;

                case "*":
                    var n5 = Convert.ToDouble(elements[elements.IndexOf("*") - 1]);
                    var n6 = Convert.ToDouble(elements[elements.IndexOf("*") + 1]);
                    AddNum = n5 * n6;
                    elements.Add("= " + AddNum);
                    Print(elements);
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
                    break;
                    }
            }

        }
        static void Print(List<object> elems)
        {
             for (int a = 0; a < elems.Count; a++)
                Console.Write(elems[a] + " ");
        }
    }
}