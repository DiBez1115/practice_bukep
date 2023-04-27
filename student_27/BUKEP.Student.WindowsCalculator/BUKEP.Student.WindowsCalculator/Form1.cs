using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUKEP.Student.WindowsCalculator
{

    public partial class Form1 : Form
    {
        /// <summary>
        /// Переменная необходимая для отчистки результата, используется в методах: 
        /// PressingTheButtonEquals; 
        /// ButtonForEnteringOperations; 
        /// ButtonsForEnteringNumbers;
        /// BackspaceButton.
        /// </summary>
        public bool CleanUpTheResult = false;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод возвращает каретку в самый конец.
        /// </summary>
        public void ReturnCorriageToEnd()
        {
            DisplayedText.SelectionStart = DisplayedText.Text.Length;
        }

        /// <summary>
        /// Метод отчищает текстовую строку, привязан к кнопке "С"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CleaningButton(object sender, EventArgs e)
        {
            DisplayedText.Text = "0";
        }

        /// <summary>
        /// Метод удаляющий последний добавленный пользователем символ, привязан к кнопке "⌫"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackspaceButton(object sender, EventArgs e)
        {
            if (CleanUpTheResult == true)
            {
                DisplayedText.Text = "0";

                CleanUpTheResult = true;
            }

            if (CleanUpTheResult == false)
            {
                DisplayedText.Text = DisplayedText.Text.Substring(0, DisplayedText.Text.Length - 1);

                if (DisplayedText.Text == "")
                {
                    DisplayedText.Text = "0";
                }

                DisplayedText.SelectionStart = DisplayedText.Text.Length;

                ReturnCorriageToEnd();
            }
        }

        /// <summary>
        /// Метод добавляющий в текстовую строку число, запятую или скобки. Привязан к кнопкам чисел, запятой и скобк.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonsForEnteringNumbers(object sender, EventArgs e)
        {
            Button buttonPressed = (Button)sender;

            string operation = DisplayedText.Text[DisplayedText.Text.Length - 1].ToString();

            if (operation == "," && buttonPressed.Text == ",")
            {
                DisplayedText.Text = DisplayedText.Text.Substring(0, DisplayedText.Text.Length - 1);

                DisplayedText.Text += buttonPressed.Text;
            }

            else
            {
                if (CleanUpTheResult == true)
                {
                    DisplayedText.Text = "0";

                    CleanUpTheResult = false;
                }

                if (CleanUpTheResult == false)
                {
                    if (DisplayedText.Text == "0")
                    {
                        if (buttonPressed.Text == ",")
                        {
                            DisplayedText.Text += ",";
                        }

                        else
                        {
                            DisplayedText.Text = buttonPressed.Text;
                        }

                    }

                    else if (DisplayedText.Text != "0")
                    {
                        DisplayedText.Text += buttonPressed.Text;
                    }

                    ReturnCorriageToEnd();
                }

            }

        }

        /// <summary>
        /// Метод добавляющий в текстовую строку операцию. Привязан к кнопкам с операциями.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonForEnteringOperations(object sender, EventArgs e)
        {
            Button buttonPressed = (Button)sender;

            string selectedOperation = buttonPressed.Text;

            string operation = DisplayedText.Text[DisplayedText.Text.Length - 1].ToString();

            if (CleanUpTheResult == true)
            {
                CleanUpTheResult = false;
            }

            if (CleanUpTheResult == false)
            {
                if (DisplayedText.Text == "0")
                {
                    DisplayedText.Text += selectedOperation;
                }

                else
                {
                    if (operation == "+" || operation == "-" || operation == "^" || operation == "×" || operation == "÷" || operation == ",")
                    {
                        DisplayedText.Text = DisplayedText.Text.Substring(0, DisplayedText.Text.Length - 1);
                    }

                    DisplayedText.Text += selectedOperation;
                }

                ReturnCorriageToEnd();
            }

        }

        /// <summary>
        /// Метод выполнят вычисления выражения, полученное от пользователя. Привязан к кнопке "=".
        /// В данном методе текстовая строка передается методу (CheckingCorrectnessTheExpression), в котором происходит проверка выражения на корректность записи.
        /// А так же, в данном методе текстовая строка передается методу (PassTheExpressionToCalculatingExpressions), в котором происходит вычисление выражения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PressingTheButtonEquals(object sender, EventArgs e)
        {
            CleanUpTheResult = true;

            string selectedNumbers = DisplayedText.Text.Replace('÷', '/').Replace('×','*');

            DisplayedText.Clear();

            if (CalculatingExpressions.CheckingCorrectnessTheExpression(selectedNumbers) == true)
            {
                DisplayedText.Text = CalculatingExpressions.PassTheExpressionToCalculatingExpressions(selectedNumbers);
            }

            else
            {
                CleanUpTheResult = false;

                DisplayedText.Text = selectedNumbers.Replace('/', '÷').Replace('*', '×');
            }

            ReturnCorriageToEnd();
        }

    }
    
}