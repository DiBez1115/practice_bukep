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

        public bool CleanUpTheResult = false;

        public Form1()
        {
            InitializeComponent();
        }

        public void ReturnKoretkaToEnd()
        {
            DisplayedText.SelectionStart = DisplayedText.Text.Length;
        }

        private void CleaningButton(object sender, EventArgs e)
        {
            DisplayedText.Text = "0";
        }

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

                ReturnKoretkaToEnd();
            }
        }


        private void ButtonsForEnteringNumbers(object sender, EventArgs e)
        {
            Button clicking = (Button)sender;

            string Operation = DisplayedText.Text[DisplayedText.Text.Length - 1].ToString();

            if (Operation == "," && clicking.Text == ",")
            {
                DisplayedText.Text = DisplayedText.Text.Substring(0, DisplayedText.Text.Length - 1);

                DisplayedText.Text += clicking.Text;
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
                        if (clicking.Text == ",")
                        {
                            DisplayedText.Text += ",";
                        }

                        else
                        {
                            DisplayedText.Text = clicking.Text;
                        }

                    }

                    else if (DisplayedText.Text != "0")
                    {
                        DisplayedText.Text += clicking.Text;
                    }

                    ReturnKoretkaToEnd();
                }

            }

        }

        private void ButtonForEnteringOperations(object sender, EventArgs e)
        {
            Button clicking = (Button)sender;

            string SelectedOperation = clicking.Text;

            string Operation = DisplayedText.Text[DisplayedText.Text.Length - 1].ToString();

            if (CleanUpTheResult == true)
            {
                CleanUpTheResult = false;
            }

            if (CleanUpTheResult == false)
            {
                if (DisplayedText.Text == "0")
                {
                    DisplayedText.Text += SelectedOperation;
                }

                else
                {
                    if (Operation == "+" || Operation == "-" || Operation == "^" || Operation == "×" || Operation == "÷" || Operation == ",")
                    {
                        DisplayedText.Text = DisplayedText.Text.Substring(0, DisplayedText.Text.Length - 1);
                    }

                    DisplayedText.Text += SelectedOperation;
                }

                ReturnKoretkaToEnd();
            }

        }

        private void PressingTheButtonEquals(object sender, EventArgs e)
        {
            CleanUpTheResult = true;

            string selectedNumbers = DisplayedText.Text;

            string ResultInput = "";

            foreach (char Symbol in selectedNumbers)
            {
                if (Symbol >= '0' && Symbol <= '9')
                {
                    ResultInput += Symbol;
                }

                if (Symbol == '×' || Symbol == '*')
                {
                    ResultInput += '*';
                }

                if (Symbol == '÷' || Symbol == '/')
                {
                    ResultInput += '/';
                }

                if (Symbol == '-')
                {
                    ResultInput += '-';
                }

                if (Symbol == '+')
                {
                    ResultInput += '+';
                }

                if (Symbol == ',')
                {
                    ResultInput += ',';
                }

                if (Symbol == '^')
                {
                    ResultInput += '^';
                }

                if (Symbol == '(')
                {
                    ResultInput += '(';
                }

                if (Symbol == ')')
                {
                    ResultInput += ')';
                }

            }

            DisplayedText.Clear();

            if (Calculator.CheckingExpression(ResultInput) == false)
            {
                DisplayedText.Text = Calculator.CalculatorOperation(ResultInput);
            }

            else
            {
                CleanUpTheResult = false;

                DisplayedText.Text = ResultInput;
            }

            ReturnKoretkaToEnd();
        }

    }
    
}