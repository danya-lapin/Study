using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace CalculatorWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Button Click Events

        private void calculatingBar_TextChanged(object sender, EventArgs e)
        {
            if (_calculatingBar.Text.Length == 0)
            {
                return;
            }
            
            var symbol = _calculatingBar.Text[_calculatingBar.Text.Length - 1].ToString();
            if (symbol.Equals("+") || symbol.Equals("-") ||
                symbol.Equals("*") || symbol.Equals("/") ||
                symbol.Equals("(") || symbol.Equals(")"))
            {
                return;
            }

            try
            {
                if (Convert.ToInt32(symbol) >= 0 && Convert.ToInt32(symbol) <= 9)
                {
                    return;
                }
            }
            catch (Exception)
            {
                // ignore
            }
            
            if (_calculatingBar.Text.Length == 1)
            {
                _calculatingBar.Text = "";
                return;
            }
            
            _calculatingBar.Text = _calculatingBar.Text.Remove(_calculatingBar.Text.Length - 1, 1);
            _calculatingBar.SelectionStart = _calculatingBar.Text.Length;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                control.Refresh();
            }
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            var substrings = _calculatingBar.Text.Split('\n');
            _calculatingBar.Text = substrings[substrings.Length - 1];
            var calculator = new Calculator(_calculatingBar.Text);
            _calculatingBar.Text = _calculatingBar.Text + @" =" + '\n' + calculator.Calculate();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            var senderButton = sender as Button;
            if (senderButton != null && 
                IsOperation(Convert.ToChar(senderButton.Text)) &&
                IsOperation(_calculatingBar.Text[_calculatingBar.Text.Length - 1]))
            {
                _calculatingBar.Text = _calculatingBar.Text.Remove(_calculatingBar.TextLength - 1);
            }
            _calculatingBar.Text += 
                senderButton?.Text ?? throw new ArgumentException("Sender is not button.");
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            _calculatingBar.Text = string.Empty;
        }

        private void clearCurrentButton_Click(object sender, EventArgs e)
        {
            _calculatingBar.Text = string.Empty;
        }

        private void divideOneByButton_Click(object sender, EventArgs e)
        {
            var calculator = new Calculator(_calculatingBar.Text);
            var x = calculator.Calculate();
            _calculatingBar.Text = (1 / x).ToString(CultureInfo.InvariantCulture);
        }

        private void squareButton_Click(object sender, EventArgs e)
        {
            var calculator = new Calculator(_calculatingBar.Text);
            var x = calculator.Calculate();
            _calculatingBar.Text = (x * x).ToString(CultureInfo.InvariantCulture);
        }

        private void squareRootButton_Click(object sender, EventArgs e)
        {
            var calculator = new Calculator(_calculatingBar.Text);
            var x = calculator.Calculate();
            _calculatingBar.Text = (Math.Sqrt(x)).ToString(CultureInfo.InvariantCulture);
        }

        private void percentButton_Click(object sender, EventArgs e)
        {
            var calculator = new Calculator(_calculatingBar.Text);
            var x = calculator.Calculate();
            _calculatingBar.Text = (x / 100).ToString(CultureInfo.InvariantCulture);
        }

        private void backspaceButton_Click(object sender, EventArgs e)
        {
            if (_calculatingBar.Text.Length >= 1)
            {
                _calculatingBar.Text = _calculatingBar.Text.Remove(_calculatingBar.Text.Length - 1);
            }
        }

        #endregion

        private static bool IsOperation(char input) => input.Equals('+') || input.Equals('-') || 
                                                       input.Equals('*') || input.Equals('/');
    }
}
