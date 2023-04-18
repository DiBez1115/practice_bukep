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
        public bool CleaningUpTheResult = true;
        public Form1()
        {
            
            InitializeComponent();
        }

        public void ReturnKoretkaToEnd() 
        {           
            textBox1.SelectionStart = textBox1.Text.Length;
        }
        private void DeleteAll_Click(object sender, EventArgs e)
        {           
            textBox1.Text = "0";
        }
        private void Backspace_Click(object sender, EventArgs e)
        {
            if (CleaningUpTheResult == false) { textBox1.Text = "0"; CleaningUpTheResult = true; }

            if (CleaningUpTheResult == true)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                if (textBox1.Text == "")
                    textBox1.Text = "0";
                textBox1.SelectionStart = textBox1.Text.Length;
                ReturnKoretkaToEnd();
            }
        }
        private void Num_Click(object sender, EventArgs e)
        {
            if (CleaningUpTheResult == false) { textBox1.Text = "0"; CleaningUpTheResult = true; }
            
            if (CleaningUpTheResult == true)
            {
                Button Butt = (Button)sender;
                if (textBox1.Text == "0")
                    textBox1.Text = Butt.Text;
                else if (textBox1.Text != "0")
                    textBox1.Text = textBox1.Text + Butt.Text;
                ReturnKoretkaToEnd();
            }
        }
        private void NonRepeatingElements_Click(object sender, EventArgs e)
        {
            Button Butt = (Button)sender;

            string Input = Butt.Text;       
            string Operac = textBox1.Text[textBox1.Text.Length - 1].ToString();
            if (CleaningUpTheResult == false) {CleaningUpTheResult = true;}

            if (CleaningUpTheResult == true)
            {
                if (textBox1.Text == "0")
                {
                    if (textBox1.Text == "0" && (Input == ","||Input == "+"|| Input == "-" || Input == "^"||Input == "÷" || Input == "×"))
                        textBox1.Text += Input;
                    else
                        textBox1.Text = "0";
                }

                else
                {
                    if (Operac == "+" || Operac == "-" || Operac == "^" || Operac == "×" || Operac == "÷" || Operac == ",")
                    {
                        textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                    }
                    textBox1.Text += Input;
                }
                ReturnKoretkaToEnd();
            }
        }
        private void ElmRavno_Click(object sender, EventArgs e)
        {           
            CleaningUpTheResult = false;
            Button Butt = (Button)sender;
            string input = textBox1.Text;
            string ResultInput = "";
            foreach (char c in input) 
            {
                if (c >= '0' && c <= '9')
                    ResultInput += c;
                if (c == '×')
                    ResultInput += '*';
                if (c == '÷')
                    ResultInput += '/';
                if (c == '-')
                    ResultInput += '-';
                if (c == '+')
                    ResultInput += '+';
                if (c == ',')
                    ResultInput += ',';
                if (c == '^')
                    ResultInput += '^';
                if (c == '(')
                    ResultInput += '(';
                if (c == ')')
                    ResultInput += ')';
            }
            textBox1.Clear();
            if (Calculator.CheckingExpression(ResultInput) == false)
            {
                textBox1.Text = Calculator.Calcul(ResultInput);
            }
            else
            {
                CleaningUpTheResult = true;
                textBox1.Text = ResultInput;
            }    
            ReturnKoretkaToEnd();
        }
    }    
}