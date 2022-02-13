using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mylastCalculator
{
    public partial class Form1 : Form
    {
        double x, y, z;
        string operatorname = "";
        bool iscleartxt = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnEcule_Click(object sender, EventArgs e)
        {
            y = double.Parse(txtShow.Text);
            switch (operatorname)
            {
                case "+":
                    z = x + y;
                    break;
                case "-":
                    z = x - y;
                    break;
                case "/":
                    z = x / y;
                    break;
                case "*":
                    z = x * y;
                    break;
            }
            txtShow.Text = z.ToString();
            operatorname = "";
            z = 0;
            y = 0;
            x = 0;

        }


        private void number(object sender, MouseEventArgs e)
        {
            if (iscleartxt)
            {
                txtShow.Text = "";
                iscleartxt = false;
            }
            txtShow.Text += ((Button)sender).Text;
        }
        private void btnBackSpace_Click(object sender, EventArgs e)
        {

            txtShow.Text = txtShow.Text.Remove(txtShow.Text.Length - 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtShow_TextChanged(null, null);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtShow.Text = "";
            y = 0;
            x = 0;
            y = 0;



        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Button test = new Button();
            test.Text = e.KeyChar.ToString();

            if (e.KeyChar >= '0' & e.KeyChar <= '9')
            {
                number(test, null);
            }
            else if (e.KeyChar == '.' && !txtShow.Text.Contains('.'))
            {
                number(test, null);
            }
            else if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/')
            {
                operands(test, null);
            }
            else if (e.KeyChar == '\b' && txtShow.Text.Length > 0)
            {
                btnBackSpace_Click(null, null);
            }
            else if (e.KeyChar == '=')
            {
                btnEcule_Click(null, null);
            }


            foreach (Button name in groupBox1.Controls)
            {
                if (e.KeyChar.ToString() == name.Text)
                {
                    name.Focus();
                    name.ForeColor = Color.Red;
                }
                else
                {
                    name.ForeColor = Color.Black;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = !groupBox1.Enabled;
            this.KeyPreview = !this.KeyPreview;
            
            if(button1.Text == "on")
            {
                button1.Text = "off";
                
            }
            else
            {
                button1.Text = "on";
                btnClear_Click(null, null);
            }
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string a = e.KeyChar.ToString();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEcule_Click(null, null);
                foreach (Button name in groupBox1.Controls)
                {
                    if (name.Text == "=")
                    {
                        name.Focus();
                        name.ForeColor = Color.Red;
                    }
                    else
                    {
                        name.ForeColor = Color.Black;
                    }
                }
            }

        }

        private void txtShow_TextChanged(object sender, EventArgs e)
        {
            btnPoint.Enabled = !(txtShow.Text.Contains("."));
            btnBackSpace.Enabled = Convert.ToBoolean(txtShow.Text.Length);
            btnEcule.Enabled = Convert.ToBoolean(txtShow.Text.Length);

        }

        private void operands(object sender, MouseEventArgs e)
        {

            if (operatorname != "")
            {
                btnEcule_Click(null, null);

            }

            x = double.Parse(txtShow.Text);
            iscleartxt = true;
            operatorname = ((Control)sender).Text;



        }
    }
}
