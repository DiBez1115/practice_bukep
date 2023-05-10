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
using BUKEP.Student.Calculator;

namespace BUKEP.Student.WindowsCalculator
{

    public partial class CalculatorForm : Form
    {

        public bool CleanUpTheResult = false;

        public CalculatorForm()
        {
            InitializeComponent();
        }

        public void ReturnCorriageToEnd()
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

                ReturnCorriageToEnd();
            }
        }

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

        private void PressingTheButtonEquals(object sender, EventArgs e)
        {
            CleanUpTheResult = true;

            string selectedNumbers = DisplayedText.Text;

            DisplayedText.Clear();

            DisplayedText.Text = CalculatingExpressions.PasstheExpressionToCalculatingExpressions(selectedNumbers);

            if (DisplayedText.Text == selectedNumbers)
            {
                CleanUpTheResult = false;
            }

            ReturnCorriageToEnd();
        }

    }
    
}