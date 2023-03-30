using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUKEP.Student.Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите математическое выражение (цифры и знаки указать через пробел)");
            var data = Console.ReadLine().Split(' ');
            var elem = new List<object>();
            for (int v = 0; v < data.Length; v++)
            {
                if (data[v] != "")
                {
                    elem.Add(data[v]);
                }
            }
            for (int i = 0; i < elem.Count; i++)
            {
                switch (elem[i])
                {
                    case "+":
                        var number1 = Convert.ToDouble(elem[elem.IndexOf("+") - 1]);
                        var number2 = Convert.ToDouble(elem[elem.IndexOf("+") + 1]);
                        double Sum = number1 + number2;
                        elem.Add("= " + Sum);
                        for (int b = 0; b < elem.Count; b++)
                            Console.Write(elem[b] + " ");
                        break;
                    case "-":
                        var number3 = Convert.ToDouble(elem[elem.IndexOf("-") - 1]);
                        var number4 = Convert.ToDouble(elem[elem.IndexOf("-") + 1]);
                        double Addition = number3 - number4;
                        elem.Add("= " + Addition);
                        for (int b = 0; b < elem.Count; b++)
                            Console.Write(elem[b] + " ");
                        break;
                    case "*":
                        var number5 = Convert.ToDouble(elem[elem.IndexOf("*") - 1]);
                        var number6 = Convert.ToDouble(elem[elem.IndexOf("*") + 1]);
                        double Multiplication = number5 * number6;
                        elem.Add("= " + Multiplication);
                        for (int b = 0; b < elem.Count; b++)
                            Console.Write(elem[b] + " ");
                        break;
                    case "/":
                        var number7 = Convert.ToDouble(elem[elem.IndexOf("/") - 1]);
                        var number8 = Convert.ToDouble(elem[elem.IndexOf("/") + 1]);
                        if (number8 != 0)
                        {
                            double Division = number7 / number8;
                            elem.Add("= " + Division);
                            for (int b = 0; b < elem.Count; b++)
                                Console.Write(elem[b] + " ");
                        }
                        else
                        {
                            Console.WriteLine("На ноль делить нельзя!");
                        }
                        break;
                }
            }

        }
    }
}
