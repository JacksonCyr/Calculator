using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//TO DO


//errors
//adding numbers after enter


namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Calc";
        }

        public static class globals
        {
            public static String num = "";
            public static List<String> terms = new List<String>();
        }

        public void printTerms()
        {
            String a = "";

            for (int i = 0; i < globals.terms.Count; i++)
            {
                a += globals.terms[i];
            }

            a += globals.num;
            txtScreen.Text = a;
        }

        private void operate(String op)
        {
            //error handling
            if (globals.terms.Count == 0 && globals.num.Length == 0)
            {
                txtScreen.Text = "ERROR: Operator cannot be first";
                return;
            }

            if (globals.num.Length != 0)
            {
                globals.terms.Add(globals.num);
                globals.num = "";
            }

            if ((new List<String> { "+", "-", "*", "÷" }).Contains(globals.terms[globals.terms.Count - 1]))
            {
                txtScreen.Text = "ERROR: Two operators in a row";
                return;
            }

            //add operator to terms then print to textbox
            globals.terms.Add(op);
            printTerms();
        }

        private void plusBtn_Click(object sender, EventArgs e)
        {
            operate("+");
        }

        private void minusBtn_Click(object sender, EventArgs e)
        {
            operate("-");
        }

        private void multBtn_Click(object sender, EventArgs e)
        {
            operate("*");
        }

        private void divBtn_Click(object sender, EventArgs e)
        {
            operate("÷");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            globals.num += "9";
            printTerms();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            globals.num += "8";
            printTerms();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            globals.num += "7";
            printTerms();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            globals.num += "6";
            printTerms();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            globals.num += "5";
            printTerms();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            globals.num += "4";
            printTerms();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            globals.num += "3";
            printTerms();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            globals.num += "2";
            printTerms();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            globals.num += "1";
            printTerms();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            globals.num += "0";
            printTerms();
        }

        private void equalsBtn_Click(object sender, EventArgs e)
        {
            //error handling
            if (globals.terms.Count == 0)
            {
                txtScreen.Text = "ERROR: = cannot be first";
                 
                return;
            }

            globals.terms.Add(globals.num);
            globals.num = "";

            if (globals.terms[globals.terms.Count - 2] == "÷" && globals.terms[globals.terms.Count -1] == "0")
            {
                txtScreen.Text = "ERROR: Division by 0";
                 
                return;
            }

            if ((new List<String> { "+", "-", "*", "÷" }).Contains(globals.terms[globals.terms.Count - 1]))
            {
                txtScreen.Text = "ERROR: Two operators in a row";
                 
                return;
            }

            //calculating total
            globals.terms.Add(globals.num);
            globals.num = "";
            Double total = Double.Parse(globals.terms[0]);

            for (int i = 1; i < globals.terms.Count; i++)
            {
                if (globals.terms[i] == "+") { total += Double.Parse(globals.terms[i + 1]); }
                else if (globals.terms[i] == "-") { total -= Double.Parse(globals.terms[i + 1]); }
                else if (globals.terms[i] == "*") { total *= Double.Parse(globals.terms[i + 1]); }
                else if (globals.terms[i] == "÷") { total /= Double.Parse(globals.terms[i + 1]); }
            }

            //printing result to text box
            String a = "";
            for (int i = 0; i < globals.terms.Count; i++)
            {
                a += globals.terms[i];
            }

            a += "=";
            a += total.ToString();
            txtScreen.Text = a;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            globals.num = "";
            globals.terms = new List<string>();
            txtScreen.Text = "";
        }

        private void decimalBtn_Click(object sender, EventArgs e)
        {
            if (globals.num.Contains(".")) {
                txtScreen.Text = "ERROR: two operators in a row";
                return;
            }

            globals.num += ".";
            printTerms();
        }

        private void negateBtn_Click(object sender, EventArgs e)
        {
            if (globals.num.Contains("-"))
            {
                txtScreen.Text = "ERROR: two operators in a row";
                return;
            }

            if (globals.terms.Contains("="))
            {
                txtScreen.Text = "ERROR";
                return;
            }

            globals.num = "-" + globals.num;
            printTerms();
        }

        private void seanBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Users\\jackson.cyr\\source\\repos\\Calculator\\Calculator\\bin\\Release\\Best Seller.jpg");
        }

        private void screen_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                    globals.num += "f";
                    printTerms();
                    break;
                case Keys.NumPad1:
                    globals.num += "1";
                    printTerms();
                    break;
                case Keys.NumPad2:
                    globals.num += "2";
                    printTerms();
                    break;
                case Keys.NumPad3:
                    globals.num += "3";
                    printTerms();
                    break;
                case Keys.NumPad4:
                    globals.num += "4";
                    printTerms();
                    break;
                case Keys.NumPad5:
                    globals.num += "5";
                    printTerms();
                    break;
                case Keys.NumPad6:
                    globals.num += "6";
                    printTerms();
                    break;
                case Keys.NumPad7:
                    globals.num += "7";
                    printTerms();
                    break;
                case Keys.NumPad8:
                    globals.num += "8";
                    printTerms();
                    break;
                case Keys.NumPad9:
                    globals.num += "9";
                    printTerms();
                    break;
                case Keys.Add:
                    operate("+");
                    break;
                case Keys.Subtract:
                    operate("-");
                    break;
                case Keys.Multiply:
                    operate("*");
                    break;
                case Keys.Divide:
                    operate("÷");
                    break;
                case Keys.Delete:
                    globals.num = "";
                    globals.terms = new List<String>();
                    txtScreen.Text = "";
                    break;
                case Keys.Decimal:
                    if (globals.num.Contains("."))
                    {
                        txtScreen.Text = "ERROR: two operators in a row";
                        return;
                    }

                    globals.num += ".";
                    printTerms();
                    break;
                case Keys.Enter:
                    if (globals.terms.Count == 0)
                    {
                        txtScreen.Text = "ERROR: = cannot be first";

                        return;
                    }

                    globals.terms.Add(globals.num);
                    globals.num = "";

                    if (globals.terms[globals.terms.Count - 2] == "÷" && globals.terms[globals.terms.Count - 1] == "0")
                    {
                        txtScreen.Text = "ERROR: Division by 0";

                        return;
                    }

                    if ((new List<String> { "+", "-", "*", "÷" }).Contains(globals.terms[globals.terms.Count - 1]))
                    {
                        txtScreen.Text = "ERROR: Two operators in a row";

                        return;
                    }

                    //calculating total
                    globals.terms.Add(globals.num);
                    globals.num = "";
                    Double total = Double.Parse(globals.terms[0]);

                    for (int i = 1; i < globals.terms.Count; i++)
                    {
                        if (globals.terms[i] == "+") { total += Double.Parse(globals.terms[i + 1]); }
                        else if (globals.terms[i] == "-") { total -= Double.Parse(globals.terms[i + 1]); }
                        else if (globals.terms[i] == "*") { total *= Double.Parse(globals.terms[i + 1]); }
                        else if (globals.terms[i] == "÷") { total /= Double.Parse(globals.terms[i + 1]); }
                    }

                    //printing result to text box
                    String a = "";
                    for (int i = 0; i < globals.terms.Count; i++)
                    {
                        a += globals.terms[i];
                    }

                    a += "=";
                    a += total.ToString();
                    txtScreen.Text = a;
                    break;
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
