using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BUKEP.Student.WebFormsCalculator
{

    public partial class _Default : Page
    {

        protected void AddElement(Object sender, EventArgs e)
        {
            var button = (Button)sender;

            var line = expression.Value;

            int length = expression.Value.Length - 1;

            bool addingOperation = button.Text == "+" || button.Text == "-"
                || button.Text == "÷" || button.Text == "×" || button.Text == "^";

            if (length > 1 && addingOperation == true)
            {
                bool lastExpressionIsOperation = line[length] == '+' || line[length] == '-'
                    || line[length] == '÷' || line[length] == '×' || line[length] == '^';

                if (addingOperation == lastExpressionIsOperation)
                {
                    DelitItem(sender, e);

                    expression.Value += button.Text;

                    return;
                }

            }

            if (expression.Value != "0")
            {
                expression.Value += button.Text;
            }

            else
            {
                expression.Value = button.Text;
            }

        }

        protected void DelitItem(Object sender, EventArgs e)
        {
            var line = expression.Value;

            int lenght = expression.Value.Length;

            expression.Value = null;

            for (int item = 0; item < lenght - 1; item++)
            {
                expression.Value += line[item];
            }

        }

        protected void CalculateExpression(Object sender, EventArgs e)
        {
            var line = expression.Value;

            expression.Value = Calculator.Calculator.CalculateMathematicalExpression(line);
        }

        protected void DeleteExpression(Object sender, EventArgs e)
        {
            expression.Value = "0";
        }

    }

}