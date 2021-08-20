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


//ERRORS
//adding numbers after enter


namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Calc";

            String o = "5 * ( 9 + 2 )";

            List<String> e = o.Split().ToList();

            

        }

        public List<String> range(List<String> t, int start, int end)
        {
            List<String> temp = new List<String>();
            for (int i = start; i < end; i++)
            {
                temp.Add(t[i]);
            }
            return temp;
        }

        public List<String> pemdas(List<String> a)
        {
            int bread = 0;
            while (a.Contains("(") && bread == 0)
            {
                int f = a.IndexOf("(");
                int g = -1;
                for (int i = a.Count - 1; i > 0; i--)
                {
                    if (a[i] == ")")
                    {
                        g = i;
                        bread = 1;
                    }
                }
                List<String> temp = range(a, f + 1, g);
                
                List<String> k = range(a, 0, f);
                k.Add(pemdas(temp)[0]);
                for (int y = g + 1; y < a.Count; y++)
                {
                    k.Add(a[y]);
                }
                a = k;

            }
            exponents(a).ForEach(Console.WriteLine);
            return exponents(a);
        }

        public List<String> exponents(List<String> a)
        {
           
            while (a.Contains("**")) 
            {
                int f = a.IndexOf("**");

                List<String> temp = new List<String>(range(a, 0, f - 1));

                temp.Add(Math.Pow(Double.Parse(a[f - 1]), Double.Parse(a[f + 1])).ToString());

                for (int i = f + 2; i < a.Count; i++)
                {
                    temp.Add(a[i]);
                }
                a = temp;
                
            }
            return multDiv(a);
        }

        public List<String> multDiv(List<String> a)
        {
            
            while (a.Contains("*") || a.Contains("÷"))
            {
                
                int f = 0;
                int t = 0;
                int v = 0;

                if (a.Contains("*") && a.Contains("÷"))
                {
                    f = a.IndexOf("*");
                    t = a.IndexOf("÷");
                    if (f < t)
                    {
                        v = f;
                    }
                    else
                    {
                        v = t;
                    }

                }

                else if (a.Contains("*"))
                {
                    f = a.IndexOf("*");
                    t = 99999;
                    v = f;
                }

                else if (a.Contains("÷"))
                {
                    f = 99999;
                    t = a.IndexOf("÷");
                    v = t;
                }

                List<String> temp = range(a, 0, v - 1);
                //Console.WriteLine(a[v - 1]);
                //Console.WriteLine(a[v + 1]);
                if (f < t)
                {
                    temp.Add((Double.Parse(a[v - 1]) * Double.Parse(a[v + 1])).ToString());
                    for (int i = v + 2; i < a.Count; i++)
                    {
                        temp.Add(a[i]);
                    }
                }
                else if (t < f)
                {
                    temp.Add((Double.Parse(a[v - 1]) / Double.Parse(a[v + 1])).ToString());
                    for (int i = v + 2; i < a.Count; i++)
                    {
                        temp.Add(a[i]);
                    }
                }
                a = temp;
            }

            return addSub(a);
        }


        public List<String> addSub(List<String> a)
        {

            while (a.Contains("+") || a.Contains("-"))
            {
                int f = 0;
                int t = 0;
                int v = 0;

                if (a.Contains("+") && a.Contains("-"))
                {
                    f = a.IndexOf("+");
                    t = a.IndexOf("-");
                    if (f < t)
                    {
                        v = f;
                    }
                    else
                    {
                        v = t;
                    }

                }

                else if (a.Contains("+"))
                {
                    f = a.IndexOf("+");
                    t = 99999;
                    v = f;
                }

                else if (a.Contains("-"))
                {
                    f = 99999;
                    t = a.IndexOf("-");
                    v = t;
                }

                List<String> temp = range(a, 0, v - 1);

                if (f < t)
                {
                    temp.Add((Double.Parse(a[v - 1]) + Double.Parse(a[v + 1])).ToString());
                    for (int i = v + 2; i < a.Count; i++)
                    {
                        temp.Add(a[i]);
                    }
                }
                else
                {
                    temp.Add((Double.Parse(a[v - 1]) - Double.Parse(a[v + 1])).ToString());
                    for (int i = v + 2; i < a.Count; i++)
                    {
                        temp.Add(a[i]);
                    }
                }

                a = temp;
            }
            
            return a;
        }

        public static class globals
        {
            public static String num = "";
            public static List<String> terms = new List<String>();
            public static List<Double> totals = new List<Double>();
        }

        public void printTerms()
        {
            String a = "";

            for (int i = 0; i < globals.terms.Count; i++)
            {
                a += globals.terms[i];
                a += " ";
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

            if ((op != "(" && op != ")") && (new List<String> { "+", "-", "*", "÷" }).Contains(globals.terms[globals.terms.Count - 1]))
            {
                txtScreen.Text = "ERROR: Two operators in a row";
                return;
            }

            //add operator to terms then print to textbox
            globals.terms.Add(op);
            printTerms();
        }

        private void expBtn_Click(object sender, EventArgs e)
        {
            operate("**");
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

            String j = pemdas(globals.terms)[0];

            globals.totals.Add(Double.Parse(j));

            txtScreen.Text = j;
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

                    String j = pemdas(globals.terms)[0];

                    globals.totals.Add(Double.Parse(j));

                    txtScreen.Text = j;
                    break;
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {

        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            operate("(");
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            operate(")");
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            if (globals.totals.Count != 0)
            {
                Clipboard.SetText(globals.totals[globals.totals.Count - 1].ToString());
            }
        }
    }
}
