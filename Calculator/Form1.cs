using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool tfPMDM = false;
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //lblLog.Text = btn.Text;

            if (tfPMDM)
            {
                txtResult.Text = btn.Text;
                tfPMDM = false;
            }
            else
            {
                txtResult.Text += btn.Text;
            }
        }

        private void btnPlusMinusMultiDivi_Click(object sender, EventArgs e)
        {
            tfPMDM = true;
            Button btn = (Button)sender;

            lblLog.Text = txtResult.Text + " " + btn.Text;

            //txtResult.Text += btn.Text;
            

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            btn0.Click += new System.EventHandler(this.btn_Click);
            btn1.Click += new System.EventHandler(this.btn_Click);
            btn2.Click += new System.EventHandler(this.btn_Click);
            btn3.Click += new System.EventHandler(this.btn_Click);
            btn4.Click += new System.EventHandler(this.btn_Click);
            btn5.Click += new System.EventHandler(this.btn_Click);
            btn6.Click += new System.EventHandler(this.btn_Click);
            btn7.Click += new System.EventHandler(this.btn_Click);
            btn8.Click += new System.EventHandler(this.btn_Click);
            btn9.Click += new System.EventHandler(this.btn_Click);

            btnPlus.Click += new System.EventHandler(this.btnPlusMinusMultiDivi_Click);
            btnMinus.Click += new System.EventHandler(this.btnPlusMinusMultiDivi_Click);
            btnMultiply.Click += new System.EventHandler(this.btnPlusMinusMultiDivi_Click);
            btnDivisor.Click += new System.EventHandler(this.btnPlusMinusMultiDivi_Click);

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            //lblLog.Text = lblLog.Text + " " + txtResult.Text + " = ";
            if (lblLog.Text.Trim().Length > 1)
            {
                string formula = lblLog.Text + txtResult.Text;
                
                string result = new DataTable().Compute((formula), null).ToString();
                lblLog.Text = formula;
                txtResult.Text = result;
            }
            
        }

        
    }
}
