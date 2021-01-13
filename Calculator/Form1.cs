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
            txtResult.Text = "0";
            _lastOpe ="";
        }

        String _temp = "";
        String _result = "0";
        decimal? _cache;
        String? _lastOpe = null;
        bool _finish = false;

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            _pressKey(btn.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblLog.Text = "";
            txtResult.Text = "0";
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

            btnPlus.Click += new System.EventHandler(this.btn_Click);
            btnMinus.Click += new System.EventHandler(this.btn_Click);
            btnMultiply.Click += new System.EventHandler(this.btn_Click);
            btnDivisor.Click += new System.EventHandler(this.btn_Click);
            this.btnEqual.Click += new System.EventHandler(this.btn_Click);
            this.btnC.Click += new System.EventHandler(this.btn_Click);
        }



        private void _pressKey(String value)
        {
            switch (value)
            {
                case "C":
                    _clear();
                    break;
                case "+/-":
                    _negate();
                    break;
                case ".":
                    _makeFloat();
                    break;
                case "=":
                    _calculate();
                    break;
                case "%":
                    _makePercent();
                    break;
                case "+":
                case "-":
                case "×":
                case "÷":
                    _operate(value);
                    break;
                default:
                    _pressNumber(value);
                    break;
            }
        }

        private void _pressNumber(String value)
        {
            if (_result == "0" || _finish)
            {
                _result = value;
                if (_cache == null)
                {
                    _temp = "";
                    lblLog.Text = _temp;
                }
            }
            else
            {
                _result += value;
            }
            txtResult.Text = _result;
            _finish = false;
        }

        private void _operate(String ope)
        {
            if (_cache == null)
            {
                _cache = decimal.Parse(_result);
            }
            else
            {
                _cache = _operateWithDigits(_cache??0, decimal.Parse(_result), _lastOpe);
            }
            _lastOpe = ope;
            _temp = string.Format("{0} {1} {2}", _temp, _result, ope).Trim();
            lblLog.Text = _temp;
            txtResult.Text = _result;
            _result = "0";            
        }

        private decimal _operateWithDigits(decimal d1, decimal d2, String ope)
        {
            decimal result = 0;

            switch (ope)
            {
                case "+":
                    result = d1 + d2;
                    break;
                case "-":
                    result = d1 - d2;
                    break;
                case "×":
                    result = d1 * d2;
                    break;
                case "÷":
                    result = d1 / d2;
                    break;
                default:
                    break;
            }

            return result;
        }        

        private void _clear()
        {
            _temp = "";
            lblLog.Text = _temp;
            _result = "0";
            txtResult.Text = "0";
            _lastOpe = "";
            _cache = 0;
        }

        private void _negate()
        {
            if (_result != "0")
            {
                if (_result.StartsWith("-"))
                {
                    _result = _result.Substring(1);
                }
                else
                {
                    _result = "-" + _result;
                }
            }
        }

        private void _makeFloat()
        {
            if (!_result.Contains("."))
            {
                _result = _result + ".";
            }
        }

        private void _calculate()
        {
            _cache = _operateWithDigits(_cache??0, decimal.Parse(_result), _lastOpe);
            _temp = string.Format("{0} {1}", _temp, _result);// "$_temp $_result";
            lblLog.Text = _temp.ToString();
            _result = _noZeroFlotString(_cache??0);
            txtResult.Text = _result;
            _cache = null;
            _lastOpe = null;
            _finish = true;
        }

        private string _noZeroFlotString(decimal d)
        {
            String str = d.ToString();
            if (str.Length < 11)
            {
                return str;
            }
            return str.Substring(0, 11);
        }

        private void _makePercent()
        {
            _cache = (null == _cache)
                   ? decimal.Parse(_result)
                   : _operateWithDigits(_cache??0, decimal.Parse(_result), _lastOpe);
            _result = _noZeroFlotString(_cache??0 / 100);
            txtResult.Text = _result;
            _temp = "";
            lblLog.Text = _temp;
            _cache = null;
            _lastOpe = null;
            _finish = true;
        }

    }
}
