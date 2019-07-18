using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
 

namespace WindowsFormsApp1
{
    public partial class Calc : Form
    {

        CalcClass MyCalc = new CalcClass();

        public Calc()
        {
            InitializeComponent();
        }

        private double claculate(string data)
        {
           List<string> str = MyCalc.AnalysString(data);
           Stack<string> notation = MyCalc.MakeReversePolishNotation(str);
           double result = MyCalc.PostfixNotation(notation);
           return (result);
        }

        #region Buttons

        private void btn1_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, "1");
            }
            else
            {
                tbMain.AppendText("1");
                tbMain.Focus();
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, "2");
            }
            else
            {
                tbMain.AppendText("2");
                tbMain.Focus();
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, "3");
            }
            else
            {
                tbMain.AppendText("3");
                tbMain.Focus();
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, "4");
            }
            else
            {
                tbMain.AppendText("4");
                tbMain.Focus();
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, "5");
            }
            else
            {
                tbMain.AppendText("5");
                tbMain.Focus();
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, "6");
            }
            else
            {
                tbMain.AppendText("6");
                tbMain.Focus();
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, "7");
            }
            else
            {
                tbMain.AppendText("7");
                tbMain.Focus();
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, "8");
            }
            else
            {
                tbMain.AppendText("8");
                tbMain.Focus();
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, "9");
            }
            else
            {
                tbMain.AppendText("9");
                tbMain.Focus();
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, "0");
            }
            else
            {
                tbMain.AppendText("0");
                tbMain.Focus();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, "+");
            }
            else
            {
                tbMain.AppendText("+");
                tbMain.Focus();
            }
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, "-");
            }
            else
            {
                tbMain.AppendText("-");
                tbMain.Focus();
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, "*");
            }
            else
            {
                tbMain.AppendText("*");
                tbMain.Focus();
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, "/");
            }
            else
            {
                tbMain.AppendText("/");
                tbMain.Focus();
            }
        }

        private void bntOpenBracket_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, "(");
            }
            else
            {
                tbMain.AppendText("(");
                tbMain.Focus();
            }
        }

        private void bntCloseBracket_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, ")");
            }
            else
            {
                tbMain.AppendText(")");
                tbMain.Focus();
            }
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, "sin");
            }
            else
            {
                tbMain.AppendText("sin");
                tbMain.Focus();
            }
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, "cos");
            }
            else
            {
                tbMain.AppendText("cos");
                tbMain.Focus();
            }
        }

        private void btnTg_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, "tg");
            }
            else
            {
                tbMain.AppendText("tg");
                tbMain.Focus();
            }
        }

        private void btnCtg_Click(object sender, EventArgs e)
        {
            if(tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, "ctg");
            }
            else
            {
                tbMain.AppendText("ctg");
                tbMain.Focus();
            }
        }
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (tbMain.SelectionStart != 0)
            {
                tbMain.Text = tbMain.Text.Insert(tbMain.SelectionStart, ".");
            }
            else
            {
                tbMain.AppendText(".");
                tbMain.Focus();
            }
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            tbMain.Text = claculate(tbMain.Text).ToString();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            tbMain.Clear();
        }


        private void Calc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { 
            tbMain.Text = claculate(tbMain.Text).ToString();
            }
        }


        #endregion




    }
}
