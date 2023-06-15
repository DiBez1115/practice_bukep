using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUKEP.Student.Calculator.Data;

namespace BUKEP.Student.WebFormsCalculator
{
    public partial class _Default : Page
    {
        readonly static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public CalculationResultRepository repository = new CalculationResultRepository(connectionString);

        public string line;

        protected void btnAddElement_Click(Object sender, EventArgs e)
        {
            var button = (Button)sender;

            line = expression.Value;

            int length = expression.Value.Length - 1;

            bool isPressedButtonOperation = button.Text == "+" || button.Text == "-" || button.Text == "÷" || button.Text == "×" || button.Text == "^";

            bool isLastElementOperator = line[length] == '+' || line[length] == '-' || line[length] == '÷' || line[length] == '×' || line[length] == '^';

            if (isPressedButtonOperation)
            {
                if (isLastElementOperator)
                {
                    expression.Value = expression.Value.Replace(expression.Value[length], Convert.ToChar(button.Text));
                }

                else if (IsErrorInExpressionLine())
                {
                    return;
                }

                else
                {
                    expression.Value += button.Text;
                }

            }

            else if(button.Text == ",")
            {
                if (IsErrorInExpressionLine())
                {
                    expression.Value = "0";

                    return;
                }

                if (line[length] == ',')
                {
                    expression.Value = expression.Value.Replace(expression.Value[length], Convert.ToChar(button.Text));
                }

                else
                {
                    expression.Value += button.Text;
                }

            }

            else if (button.Text == "0")
            {
                if (length >= 0 && IsErrorInExpressionLine() == false)
                {                   
                    if (line[length] == '0' && length == 0)
                    {
                        expression.Value = button.Text;
                    }

                    else if (length !=0 && line[length] == '0')
                    {
                        bool isPenultimateElementOperator = line[length - 1] == '+' || line[length - 1] == '-' || line[length - 1] == '÷' || line[length - 1] == '×' || line[length - 1] == '^';

                        if (isPenultimateElementOperator)
                        {
                            expression.Value = expression.Value.Replace(expression.Value[length], Convert.ToChar(button.Text));
                        }

                        else
                        {
                            expression.Value += button.Text;
                        }

                    }

                    else
                    {
                        expression.Value += button.Text;
                    }

                }

                else 
                {
                    expression.Value = button.Text;
                }

            }

            else if (button.Text != "0")
            {
                if (IsErrorInExpressionLine() || expression.Value == "0")
                {
                    expression.Value = button.Text;
                }

                else
                {
                    expression.Value += button.Text;
                }

            }

            idResult.Value = Convert.ToString("null");
        }

        protected void btnDeleteItem_Click(Object sender, EventArgs e)
        {
            if (IsErrorInExpressionLine())
            {
                expression.Value = "0";

                return;
            }

            int length = expression.Value.Length;

            line = expression.Value;

            expression.Value = null;

            if (length > 1)
            {
                for (int item = 0; item < length - 1; item++)
                {
                    expression.Value += line[item];
                }

            }

            else
            {
                expression.Value = "0";
            }

            idResult.Value = Convert.ToString("null");
        }

        protected void btnCalculateExpression_Click(Object sender, EventArgs e)
        {
            line = expression.Value;

            try
            {
                expression.Value = Calculator.Calculator.CalculateMathematicalExpression(line);
            }

            catch (DivideByZeroException)
            {
                expression.Value = "Деление на 0!";
            }

            catch (Exception)
            {
                expression.Value = "Ошибка!!!";
            }

            idResult.Value = Convert.ToString("null");
        }

        protected void btnDeleteExpression_Click(Object sender, EventArgs e)
        {
            expression.Value = "0";

            idResult.Value = Convert.ToString("null");
        }

        protected void btnSavingResult_Click (Object sender, EventArgs e)
        {
            if (IsErrorInExpressionLine())
            {
                return;
            }

            decimal result = Convert.ToDecimal(expression.Value);

            CalculationResult calculationResult = new CalculationResult
            {
                Result = result
            };

            repository.SaveCalculationResult(calculationResult);

            idResult.Value = Convert.ToString("null");
        }

        protected void btnOutputOfPreviousResult_Click (Object sender, EventArgs e)
        {
            List<CalculationResult> calculationResults = repository.GetCalculationResult();

            int numberOfElements = calculationResults.Count - 1;

            if (IsErrorInExpressionLine())
            {
                expression.Value = Convert.ToString(calculationResults[numberOfElements].Result);

                return;
            }

            else if (idResult.Value == "null")
            {
                try
                {
                    expression.Value = Convert.ToString(calculationResults[numberOfElements].Result);

                    idResult.Value = Convert.ToString(numberOfElements);
                }

                catch (Exception)
                {
                    expression.Value = "0";
                }

            }

            else if (idResult.Value != "null")
            {
                try
                {
                    int id = Convert.ToInt32(idResult.Value) - 1;

                    expression.Value = Convert.ToString(calculationResults[id].Result);

                    idResult.Value = Convert.ToString(id);
                }

                catch (Exception)
                {
                    int id = Convert.ToInt32(idResult.Value);

                    try
                    {
                        expression.Value = Convert.ToString(calculationResults[id].Result);
                    }

                    catch
                    {
                        expression.Value = "0";
                    }

                }

            }

        }

        protected void btnOutputOfFollowingResult_Click(Object sender, EventArgs e)
        {
            List<CalculationResult> calculationResults = repository.GetCalculationResult();

            int numberOfElements = calculationResults.Count - 1;

            if (IsErrorInExpressionLine())
            {
                expression.Value = Convert.ToString(calculationResults[numberOfElements].Result);

                return;
            }

            if (idResult.Value == "null")
            {
                try
                {
                    expression.Value = Convert.ToString(calculationResults[numberOfElements].Result);

                    idResult.Value = Convert.ToString(numberOfElements);
                }

                catch (Exception)
                {
                    expression.Value = "0";
                }

            }

            else if (idResult.Value != "null")
            {
                try
                {
                    int id = Convert.ToInt32(idResult.Value) + 1;

                    expression.Value = Convert.ToString(calculationResults[id].Result);

                    idResult.Value = Convert.ToString(id);
                }

                catch (Exception)
                {
                    int id = Convert.ToInt32(idResult.Value);

                    try
                    {
                        expression.Value = Convert.ToString(calculationResults[id].Result);
                    }

                    catch
                    {
                        expression.Value = "0";
                    }

                }

            }

        }

        protected void btnCleanUpHistory_Click (Object sender, EventArgs e)
        {
            repository.ClearCalculationResults();

            idResult.Value = Convert.ToString("null");
        }

        /// <summary>
        /// Проверяет есть ли в строке текст ошибки.
        /// </summary>
        /// <returns>Значение true, если в строке есть текст ошибки, в противном случае значение false.</returns>
        private bool IsErrorInExpressionLine()
        {
            bool error = false;

            if (expression.Value == "Деление на 0!" || expression.Value == "Ошибка!!!")
            {
                error = true;
            }

            return error;
        }

    }

}