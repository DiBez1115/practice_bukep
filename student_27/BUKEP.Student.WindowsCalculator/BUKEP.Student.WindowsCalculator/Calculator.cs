using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUKEP.Student.WindowsCalculator
{
    internal class Calculator
    {
        public static string Calcul(string args)
        {

            string inputData = args;

            string result;

            List<char> elms = new List<char>();

            foreach (char s in inputData)
                if (s != ' ') elms.Add(s);

            Stack<string> Operac = new Stack<string>();
            Stack<double> Numm = new Stack<double>();

            Stack<double> SkobkaNewNumm = new Stack<double>();
            Stack<string> SkobkanewOperac = new Stack<string>();

            Run(elms, Operac, Numm, args, SkobkaNewNumm, SkobkanewOperac);

            Calc(Operac, Numm, args);

            double NummResult = Numm.Pop();       

            return result = NummResult.ToString();
        }
        public static double Calc(Stack<string> op, Stack<double> num, string args)
        {
            double output = 0;
            for (int i = 0; i < op.Count; i++)
            {
                string prov = op.Peek();
                if (prov == "(")
                    break;
                string a1 = op.Pop();
                double b1 = num.Pop();
                double b2 = num.Pop();
                switch (a1)
                {
                    case "+":
                        output = b1 + b2;
                        num.Push(output);
                        break;

                    case "-":
                        output = b2 - b1;
                        num.Push(output);
                        break;

                    case "*":
                        output = b1 * b2;
                        num.Push(output);
                        break;

                    case "/":
                        output = b2 / b1;
                        num.Push(output);
                        break;
                    case "^":
                        output = Math.Pow(b2, b1);
                        num.Push(output);
                        break;
                }
            }
            return output;
        }
        public static void Run(List<char> elms, Stack<string> Operac, Stack<double> Numm, string args, Stack<double> SkobkaNewNumm, Stack<string> SkobkaNewOperac)
        {
            var result = "";
            for (int i = 0; i < elms.Count; i++)
            {
                if (!(Operac.Contains("(")))
                {
                    if (elms[i] == '^')
                        Operac.Push("^");
                    if ((Operac.Count == 1 && Numm.Count == 2) && ((Operac.Contains("*") || Operac.Contains("/") || Operac.Contains("^")))) { Calc(Operac, Numm, args); }

                    if (elms[i] == '+' || elms[i] == '-' || elms[i] == '*' || elms[i] == '/')
                    {
                        if (result != "")
                        {
                            Numm.Push(Convert.ToDouble(result));
                            result = "";
                            if (Operac.Count >= 1)
                            {
                                string pop = Operac.Peek();
                                if ((Operac.Contains("*") && Numm.Count >= 2) || (Operac.Contains("/") && Numm.Count >= 2) && pop != "(") Calc(Operac, Numm, args);
                                result = "";
                            }
                        }
                        result += elms[i];
                        if ((result == "-" || result == "+" || result == ")") && Numm.Count >= 2) Calc(Operac, Numm, args);
                        Operac.Push(result);
                        result = "";
                    }

                    if ((elms[i] >= '0' && elms[i] <= '9') || elms[i] == '.' || elms[i] == ',')
                    {
                        if (elms[i] == '.' || elms[i] == ',') result += ",";
                        else result += elms[i];

                        if (i + 1 != elms.Count)
                        {
                            if (elms[i + 1] == '+' || elms[i + 1] == '-' || elms[i + 1] == '*' || elms[i + 1] == '/' || elms[i + 1] == '^')
                            {
                                Numm.Push(Convert.ToDouble(result));
                                if (Operac.Count != 0 && Operac.Peek() == "^")
                                    Calc(Operac, Numm, args);

                                result = "";
                            }
                        }
                    }
                }
                if (elms[i] == '(') Operac.Push("(");

                if (elms[i] == ')')
                {
                    Calc(Operac, Numm, args);
                    if (Operac.Peek() == "(")
                        Operac.Pop();
                }
                if (Operac.Contains("("))
                {
                    if (elms[i] == '^')
                        Operac.Push("^");
                    if ((elms[i] == '-') && (elms[i - 1] == '('))
                        result += elms[i];
                    if ((elms[i] >= '0' && elms[i] <= '9') || elms[i] == '.' || elms[i] == ',')
                    {
                        if (elms[i] == '.' || elms[i] == ',') result += ",";
                        else result += elms[i];
                        if (i + 1 != elms.Count)
                        {
                            if (elms[i + 1] == '+' || elms[i + 1] == '-' || elms[i + 1] == '*' || elms[i + 1] == '/' || elms[i + 1] == '(' || elms[i + 1] == ')' || elms[i + 1] == '^')
                            {
                                Numm.Push(Convert.ToDouble(result));
                                if (Operac.Peek() == "^")
                                    Calc(Operac, Numm, args);
                                result = "";
                            }
                        }
                    }
                    if ((elms[i] == '*' || elms[i] == '/' || elms[i] == '-' || elms[i] == '+') && elms[i - 1] != '(')
                    {
                        Operac.Push(elms[i].ToString());
                    }
                }
            }
            if (result != "") Numm.Push(Convert.ToDouble(result));
            Calc(Operac, Numm, args);
        }       
        public static bool CheckingExpression(string Expression)
        {
            bool result = false;
            char LastElement = Expression[Expression.Length - 1];
            if (LastElement == '-'|| LastElement == '+' || LastElement == '/' || LastElement == '*' || LastElement == '^'|| LastElement == ',')
            {
                return result = true;
            }
            return result;
        }
    }
}
