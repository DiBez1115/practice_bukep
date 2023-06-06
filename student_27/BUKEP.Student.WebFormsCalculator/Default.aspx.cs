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
        readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public string line;

        protected void btnAddElement_Click(Object sender, EventArgs e)
        {
            var button = (Button)sender;

            line = expression.Value;

            int length = expression.Value.Length - 1;

            bool addingOperation = button.Text == "+" || button.Text == "-"
                || button.Text == "÷" || button.Text == "×" || button.Text == "^";

            if (length > 1 && addingOperation)
            {
                bool lastExpressionIsOperation = line[length] == '+' || line[length] == '-'
                    || line[length] == '÷' || line[length] == '×' || line[length] == '^';

                if (lastExpressionIsOperation)
                {
                    btnDeleteItem_Click(sender, e);

                    expression.Value += button.Text;

                    return;
                }

            }

            if (line != "0")
            {
                if (line == "Деление на 0!" || line == "Ошибка!!!")
                {
                    expression.Value = button.Text;
                }

                else
                {
                    expression.Value += button.Text;
                }

            }

            else
            {
                if (button.Text == ",")
                {
                    expression.Value += button.Text;
                }

                else
                {
                    expression.Value = button.Text;
                }
                
            }

        }

        protected void btnDeleteItem_Click(Object sender, EventArgs e)
        {
            int length = expression.Value.Length;

            line = expression.Value;

            expression.Value = null;

            for (int item = 0; item < length - 1; item++)
            {
                expression.Value += line[item];
            }

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

        }

        protected void btnDeleteExpression_Click(Object sender, EventArgs e)
        {
            expression.Value = "0";
        }

        protected void btnSavingResult_Click (Object sender, EventArgs e)
        {
            decimal result = Convert.ToDecimal(expression.Value);

            CalculationResultRepository repository = new CalculationResultRepository(connectionString);

            CalculationResult calculationResult = new CalculationResult
            {
                Result = result
            };

            repository.SaveCalculationResult(calculationResult);
        }

        protected void btnOutputOfPreviousResult_Click (Object sender, EventArgs e)
        {
            CalculationResultRepository repository = new CalculationResultRepository(connectionString);

            List<CalculationResult> calculationResults = repository.GetCalculationResult();

            int numberOfExpressions = calculationResults.Count - 1;

            decimal result = Convert.ToDecimal(expression.Value);

            for (int i = 0; i <= numberOfExpressions; i++)
            {
                if (calculationResults[i].Result == result)
                {
                    try
                    {
                        expression.Value = Convert.ToString(calculationResults[i - 1].Result);
                    }

                    catch (Exception)
                    {
                        expression.Value = Convert.ToString(calculationResults[i].Result);
                    }

                    break;
                }

                else if (calculationResults[i].Result != result && i == numberOfExpressions)
                {
                    expression.Value = Convert.ToString(calculationResults[i].Result);
                }

            }

        }

        protected void btnOutputOfFollowingResult_Click(Object sender, EventArgs e)
        {
            CalculationResultRepository repository = new CalculationResultRepository(connectionString);

            List<CalculationResult> calculationResults = repository.GetCalculationResult();

            int numberOfExpressions = calculationResults.Count - 1;

            decimal result = Convert.ToDecimal(expression.Value);

            for (int i = 0; i <= numberOfExpressions; i++)
            {
                if (calculationResults[i].Result == result)
                {
                    try
                    {
                        expression.Value = Convert.ToString(calculationResults[i + 1].Result);
                    }

                    catch (Exception)
                    {
                        expression.Value = Convert.ToString(calculationResults[i].Result);
                    }

                    break;
                }

                else if (calculationResults[i].Result != result && i == numberOfExpressions)
                {
                    expression.Value = Convert.ToString(calculationResults[i].Result);
                }

            }

        }

        protected void btnCleanUpHistory_Click (Object sender, EventArgs e)
        {
            CalculationResultRepository repository = new CalculationResultRepository(connectionString);

            expression.Value = "0";

            repository.ClearCalculationResults();
        }

    }

}