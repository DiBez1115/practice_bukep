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
        /// <summary>
        /// Проверяет достоверность операции.
        /// </summary>
        /// <param name="operation">Операция переданная для проверки.</param>
        /// <returns>Возвращает true если переданный элемент операция, в противном случае false.</returns>
        private bool CheckOperationValidity(string operation)
        {
            return operation == "+" || operation == "-" || operation == "×" || operation == "÷" || operation == "^";
        }

        private readonly static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        private CalculationResultRepository repository = new CalculationResultRepository(connectionString);

        protected void btnAddElement_Click(Object sender, EventArgs e)
        {
            var button = (Button)sender;

            string line = expression.Value;

            int length = expression.Value.Length - 1;

            if (CheckOperationValidity(button.Text))
            {
                if (CheckOperationValidity(line[length].ToString()))
                {
                    expression.Value = expression.Value.Replace(expression.Value[length], Convert.ToChar(button.Text));
                }

                else if (IsErrorInExpressionLine(expression.Value))
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
                if (IsErrorInExpressionLine(expression.Value))
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
                if (length >= 0 && IsErrorInExpressionLine(expression.Value) == false)
                {                   
                    if (line[length] == '0' && length == 0)
                    {
                        expression.Value = button.Text;
                    }

                    else if (length !=0 && line[length] == '0')
                    {                        
                        if (CheckOperationValidity(line[length - 1].ToString()))
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
                if (IsErrorInExpressionLine(expression.Value) || expression.Value == "0")
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
            if (IsErrorInExpressionLine(expression.Value))
            {
                expression.Value = "0";

                return;
            }

            int length = expression.Value.Length;

            string line = expression.Value;

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
            string line = expression.Value;

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
            if (IsErrorInExpressionLine(expression.Value))
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
            List<CalculationResult> results = repository.GetCalculationResult();

            Dictionary<int, string> calculationResults = results.ToDictionary(item => item.Id, item => Convert.ToString(item.Result));

            if (calculationResults.Count == 0)
            {
                expression.Value = "0";
            }

            else
            {
                int lastId = calculationResults.Last().Key;

                if (idResult.Value == "null")
                {
                    expression.Value = calculationResults[lastId];

                    idResult.Value = Convert.ToString(lastId);
                }

                else if (idResult.Value != "null")
                {
                    int id = Convert.ToInt32(idResult.Value);

                    if (calculationResults.ContainsKey(id - 1))
                    {
                        expression.Value = calculationResults[id - 1];

                        idResult.Value = Convert.ToString(id - 1);
                    }

                    else
                    {
                        expression.Value = calculationResults[id];

                        idResult.Value = Convert.ToString(id);
                    }

                }

            }

        }

        protected void btnOutputOfFollowingResult_Click(Object sender, EventArgs e)
        {
            List<CalculationResult> results = repository.GetCalculationResult();

            Dictionary<int, string> calculationResults = results.ToDictionary(item => item.Id, item => Convert.ToString(item.Result));

            if (calculationResults.Count == 0)
            {
                expression.Value = "0";
            }

            else
            {
                int lastId = calculationResults.Last().Key;

                if (idResult.Value == "null")
                {
                    expression.Value = calculationResults[lastId];

                    idResult.Value = Convert.ToString(lastId);
                }

                else if (idResult.Value != "null")
                {
                    int id = Convert.ToInt32(idResult.Value);

                    if (calculationResults.ContainsKey(id + 1))
                    {
                        expression.Value = calculationResults[id + 1];

                        idResult.Value = Convert.ToString(id + 1);
                    }

                    else
                    {
                        expression.Value = calculationResults[id];

                        idResult.Value = Convert.ToString(id);
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
        private bool IsErrorInExpressionLine(string expression)
        {
            bool error = false;

            if (expression == "Деление на 0!" || expression == "Ошибка!!!")
            {
                error = true;
            }

            return error;
        }

    }

}