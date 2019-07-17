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
            DirectoryInfo d = new DirectoryInfo(@"C:\New folder");
            List<string> lst = new List<string>();
            Stack<string> stck = new Stack<string>();
            foreach (FileInfo f in d.GetFiles("*", SearchOption.AllDirectories))
            {
                lst.Add(f.FullName);
                stck.Push(f.FullName);
            }

        }

        private double claculate(string data)
        {
           List<string> str = MyCalc.AnalysString(data);
           Stack<string> result = MyCalc.MakeReversePolishNotation(str);
           double dd = MyCalc.PostfixNotation(result);

            return (2.0/3);
        }

        #region Buttons

        private void btn1_Click(object sender, EventArgs e)
        {
            tbMain.AppendText("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            tbMain.AppendText("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            tbMain.AppendText("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            tbMain.AppendText("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            tbMain.AppendText("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            tbMain.AppendText("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            tbMain.AppendText("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            tbMain.AppendText("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            tbMain.AppendText("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            tbMain.AppendText("0");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tbMain.AppendText("+");
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            tbMain.AppendText("-");
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            tbMain.AppendText("*");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            tbMain.AppendText("/");
        }

        private void bntOpenBracket_Click(object sender, EventArgs e)
        {
            tbMain.AppendText("(");
        }

        private void bntCloseBracket_Click(object sender, EventArgs e)
        {
            tbMain.AppendText(")");
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            
            tbMain.Text = claculate(tbMain.Text).ToString();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            tbMain.Clear();

        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            tbMain.AppendText("sin");

        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            tbMain.AppendText("cos");
        }

        private void btnTg_Click(object sender, EventArgs e)
        {
            tbMain.AppendText("tg");
        }

        private void btnCtg_Click(object sender, EventArgs e)
        {
            tbMain.AppendText("ctg");
        }

        #endregion


    }
}
