using System;
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
        

        private void equalButton_Click(object sender, EventArgs e)
        {
            var calculator = new Calculator(_calculatingBar.Text);
            _calculatingBar.Text = _calculatingBar.Text + " =" + '\n' + calculator.Calculate();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            var senderButton = sender as Button;

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
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            _calculatingBar.Text = (1 / x).ToString();
        }

        private void squareButton_Click(object sender, EventArgs e)
        {
            var calculator = new Calculator(_calculatingBar.Text);
            var x = calculator.Calculate();
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            _calculatingBar.Text = (x * x).ToString();
        }

        private void squareRootButton_Click(object sender, EventArgs e)
        {
            var calculator = new Calculator(_calculatingBar.Text);
            var x = calculator.Calculate();
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            _calculatingBar.Text = (Math.Sqrt(x)).ToString();
        }

        private void percentButton_Click(object sender, EventArgs e)
        {
            var calculator = new Calculator(_calculatingBar.Text);
            var x = calculator.Calculate();
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            _calculatingBar.Text = (x / 100).ToString();
        }

        private void backspaceButton_Click(object sender, EventArgs e)
        {
            _calculatingBar.Text.Remove(_calculatingBar.Text.Length - 1);
        }
        #endregion
    }
}
