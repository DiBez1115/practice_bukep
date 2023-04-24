using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUKEP.Student.WindowsCalculator
{

    internal class Calculator
    {

        public static string CalculatorOperation(string expression)
        {
            string line = expression;

            string OutputResult;

            List<char> Elements = new List<char>();

            foreach (char symbol in line)
            {
                if (symbol != ' ')
                {
                    Elements.Add(symbol);
                }

            }

            Stack<string> Operations = new Stack<string>();
            Stack<double> Numbers = new Stack<double>();

            TranslationOfExpressionToReversePolish(Elements, Operations, Numbers);

            ApplyOperation(Operations, Numbers);

            double NummResult = Numbers.Pop();       

            return OutputResult = NummResult.ToString();
        }
        public static double ApplyOperation(Stack<string> Operations, Stack<double> Numbers)
        {
            double OutputResult = 0;

            for (int iteration = 0; iteration < Operations.Count; iteration++)
            {
                string CheckingOperation = Operations.Peek();

                if (CheckingOperation == "(")
                {
                    break;
                }

                string UpperOperation = Operations.Pop();

                double FirstNumbers = Numbers.Pop();

                double SecondNumbers = Numbers.Pop();

                switch (UpperOperation)
                {
                    case "+":

                        OutputResult = FirstNumbers + SecondNumbers;

                        Numbers.Push(OutputResult);

                        break;

                    case "-":

                        OutputResult = SecondNumbers - FirstNumbers;

                        Numbers.Push(OutputResult);

                        break;

                    case "*":

                        OutputResult = FirstNumbers * SecondNumbers;

                        Numbers.Push(OutputResult);

                        break;

                    case "/":

                        OutputResult = SecondNumbers / FirstNumbers;

                        Numbers.Push(OutputResult);

                        break;

                    case "^":

                        OutputResult = Math.Pow(SecondNumbers, FirstNumbers);

                        Numbers.Push(OutputResult);

                        break;
                }

            }

            return OutputResult;
        }

        public static void TranslationOfExpressionToReversePolish(List<char> Elements, Stack<string> Operations, Stack<double> Numbers)
        {
            var result = "";

            for (int iteration = 0; iteration < Elements.Count; iteration++)
            {
                if (!Operations.Contains("("))
                {
                    if (iteration == 0 && Elements[iteration] == '-')
                    {
                        result += "-";

                        continue;
                    }

                    if (Elements[iteration] == '^')
                    {
                        Operations.Push("^");
                    }

                    if (Operations.Count == 1 && Numbers.Count == 2 && (Operations.Contains("*") || Operations.Contains("/") || Operations.Contains("^"))) 
                    { 
                        ApplyOperation(Operations, Numbers);
                    }

                    if (Elements[iteration] == '+' || Elements[iteration] == '-' || Elements[iteration] == '*' || Elements[iteration] == '/')
                    {
                        if (result != "")
                        {
                            Numbers.Push(Convert.ToDouble(result));

                            result = "";

                            if (Operations.Count >= 1)
                            {
                                string topOperation = Operations.Peek();

                                if ((Operations.Contains("*") && Numbers.Count >= 2) || Operations.Contains("/") && Numbers.Count >= 2 && topOperation != "(")
                                {
                                    ApplyOperation(Operations, Numbers);
                                }

                                result = "";
                            }

                        }

                        result += Elements[iteration];

                        if ((result == "-" || result == "+" || result == ")") && Numbers.Count >= 2)
                        {
                            ApplyOperation(Operations, Numbers);
                        }

                        Operations.Push(result);

                        result = "";
                    }

                    if ((Elements[iteration] >= '0' && Elements[iteration] <= '9') || Elements[iteration] == '.' || Elements[iteration] == ',')
                    {
                        if (Elements[iteration] == '.' || Elements[iteration] == ',')
                        {
                            result += ",";
                        }

                        else
                        {
                            result += Elements[iteration];
                        }

                        if (iteration + 1 != Elements.Count)
                        {
                            if (Elements[iteration + 1] == '+' || Elements[iteration + 1] == '-' || Elements[iteration + 1] == '*' || Elements[iteration + 1] == '/' || Elements[iteration + 1] == '^')
                            {
                                Numbers.Push(Convert.ToDouble(result));

                                if (Operations.Count != 0 && Operations.Peek() == "^")
                                {
                                    ApplyOperation(Operations, Numbers);
                                }

                                result = "";
                            }

                        }

                    }

                }

                if (Elements[iteration] == '(')
                {
                    Operations.Push("(");
                }

                if (Elements[iteration] == ')')
                {
                    ApplyOperation(Operations, Numbers);

                    if (Operations.Peek() == "(")
                    {
                        Operations.Pop();
                    }

                }

                if (Operations.Contains("("))
                {
                    if (Elements[iteration] == '^')
                    {
                        Operations.Push("^");
                    }

                    if (Elements[iteration] == '-' && Elements[iteration - 1] == '(')
                    {
                        result += Elements[iteration];
                    }

                    if ((Elements[iteration] >= '0' && Elements[iteration] <= '9') || Elements[iteration] == '.' || Elements[iteration] == ',')
                    {
                        if (Elements[iteration] == '.' || Elements[iteration] == ',')
                        {
                            result += ",";
                        }

                        else
                        {
                            result += Elements[iteration];
                        }

                        if (iteration + 1 != Elements.Count)
                        {
                            if (Elements[iteration + 1] == '+' || Elements[iteration + 1] == '-' || Elements[iteration + 1] == '*' || Elements[iteration + 1] == '/' || Elements[iteration + 1] == '(' || Elements[iteration + 1] == ')' || Elements[iteration + 1] == '^')
                            {
                                Numbers.Push(Convert.ToDouble(result));

                                if (Operations.Peek() == "^")
                                { 
                                    ApplyOperation(Operations, Numbers); 
                                }

                                result = "";
                            }

                        }

                    }

                    if ((Elements[iteration] == '*' || Elements[iteration] == '/' || Elements[iteration] == '-' || Elements[iteration] == '+') && Elements[iteration - 1] != '(')
                    {
                        Operations.Push(Elements[iteration].ToString());
                    }

                }

            }

            if (result != "")
            {
                Numbers.Push(Convert.ToDouble(result));
            }

            ApplyOperation(Operations, Numbers);
        }
        
        public static bool CheckingExpression(string Expression)
        {
            bool VerificationResult = false;

            char LastElement = Expression[Expression.Length - 1];

            if (LastElement == ')')
            {
                char elementDeforeBracket = Expression[Expression.Length - 2];

                if (elementDeforeBracket == '-' || elementDeforeBracket == '+' || elementDeforeBracket == '/' || elementDeforeBracket == '*')
                {
                    VerificationResult = true;
                }

            }

            if (LastElement == '-'|| LastElement == '+' || LastElement == '/' || LastElement == '*' || LastElement == '^'|| LastElement == ',')
            {
                VerificationResult = true;
            }

            return VerificationResult;
        }

    }

}
