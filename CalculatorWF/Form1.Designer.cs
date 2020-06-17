using System;
using System.Drawing;
using System.Windows.Forms;

namespace CalculatorWF
{
  partial class Form1
  {
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }

      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(432, 504);
      this.Text = "Calculator";

      this.SizeChanged += new EventHandler(Form1_SizeChanged);
      
      #region Button Customize
      // Equal Button
      var equalButton = new Button();
      equalButton.Width = this.Size.Width / 4; 
      equalButton.Height = this.Size.Height / 9;
      equalButton.Location = new Point(this.Width - equalButton.Width, this.Height - equalButton.Height * 3 / 2 - 10); 
      equalButton.Text = @"=";
      equalButton.Click += new EventHandler(equalButton_Click);
            
            // Comma Button
            var commaButton = new Button();
            commaButton.Width = this.Size.Width / 4;
            commaButton.Height = this.Size.Height / 9;
            commaButton.Location = new Point(this.Width - commaButton.Width * 2, this.Height - commaButton.Height * 3 / 2 - 10);
            commaButton.Text = @",";
            commaButton.Click += new EventHandler(Button_Click);
            
            // Zero Button
            var zeroButton = new Button();
            zeroButton.Width = this.Size.Width / 4;
            zeroButton.Height = this.Size.Height / 9;
            zeroButton.Location = new Point(this.Width - zeroButton.Width * 3, this.Height - zeroButton.Height * 3 / 2 - 10);
            zeroButton.Text = @"0";
            zeroButton.Click += new EventHandler(Button_Click);

            // Negative Button
            var negativeButton = new Button();
            negativeButton.Width = this.Size.Width / 4;
            negativeButton.Height = this.Size.Height / 9;
            negativeButton.Location = new Point(this.Width - negativeButton.Width * 4, this.Height - negativeButton.Height * 3 / 2 - 10);
            negativeButton.Text = @"-/+";
            negativeButton.Click += new EventHandler(Button_Click);
            
            // Add Operation Button
            var addOperationButton = new Button();
            addOperationButton.Width = this.Size.Width / 4;
            addOperationButton.Height = this.Size.Height / 9;
            addOperationButton.Location = new Point(this.Width - addOperationButton.Width, this.Height - addOperationButton.Height * 5/2 - 10);
            addOperationButton.Text = @"+";
            addOperationButton.Click += new EventHandler(Button_Click);
            
            // Subtract Operation Button
            var subtractOperationButton = new Button();
            subtractOperationButton.Width = this.Size.Width / 4;
            subtractOperationButton.Height = this.Size.Height / 9;
            subtractOperationButton.Location = new Point(this.Width - subtractOperationButton.Width, this.Height - subtractOperationButton.Height * 7/2 - 10);
            subtractOperationButton.Text = @"-";
            subtractOperationButton.Click += new EventHandler(Button_Click);
            
            // Multiply Operation Button
            var multiplyOperationButton = new Button();
            multiplyOperationButton.Width = this.Size.Width / 4;
            multiplyOperationButton.Height = this.Size.Height / 9;
            multiplyOperationButton.Location = new Point(this.Width - multiplyOperationButton.Width, this.Height - multiplyOperationButton.Height * 9/2 - 10);
            multiplyOperationButton.Text = @"*";
            multiplyOperationButton.Click += new EventHandler(Button_Click);
            
            // Division Operation Button
            var divisionOperationButton = new Button();
            divisionOperationButton.Width = this.Size.Width / 4;
            divisionOperationButton.Height = this.Size.Height / 9;
            divisionOperationButton.Location = new Point(this.Width - divisionOperationButton.Width, this.Height - divisionOperationButton.Height * 11/2 - 10);
            divisionOperationButton.Text = @"/";
            divisionOperationButton.Click += new EventHandler(Button_Click);
            
            // one Button
            var oneButton = new Button();
            oneButton.Width = this.Size.Width / 4;
            oneButton.Height = this.Size.Height / 9;
            oneButton.Location = new Point(this.Width - oneButton.Width * 4, this.Height - oneButton.Height * 5 / 2 - 10);
            oneButton.Text = @"1";
            oneButton.Click += new EventHandler(Button_Click);
            
            // Two Button
            var twoButton = new Button();
            twoButton.Width = this.Size.Width / 4;
            twoButton.Height = this.Size.Height / 9;
            twoButton.Location = new Point(this.Width - twoButton.Width * 3, this.Height - twoButton.Height * 5 / 2 - 10);
            twoButton.Text = @"2";
            twoButton.Click += new EventHandler(Button_Click);
            
            // Three Button
            var threeButton = new Button();
            threeButton.Width = this.Size.Width / 4;
            threeButton.Height = this.Size.Height / 9;
            threeButton.Location = new Point(this.Width - threeButton.Width * 2, this.Height - threeButton.Height * 5 / 2 - 10);
            threeButton.Text = @"3";
            threeButton.Click += new EventHandler(Button_Click);
            
            // Four Button
            var fourButton = new Button();
            fourButton.Width = this.Size.Width / 4;
            fourButton.Height = this.Size.Height / 9;
            fourButton.Location = new Point(this.Width - fourButton.Width * 4, this.Height - fourButton.Height * 7 / 2 - 10);
            fourButton.Text = @"4";
            fourButton.Click += new EventHandler(Button_Click);
            
            // Five Button
            var fiveButton = new Button();
            fiveButton.Width = this.Size.Width / 4;
            fiveButton.Height = this.Size.Height / 9;
            fiveButton.Location = new Point(this.Width - fiveButton.Width * 3, this.Height - fiveButton.Height * 7 / 2 - 10);
            fiveButton.Text = @"5";
            fiveButton.Click += new EventHandler(Button_Click);
            
            // Six Button
            var sixButton = new Button();
            sixButton.Width = this.Size.Width / 4;
            sixButton.Height = this.Size.Height / 9;
            sixButton.Location = new Point(this.Width - sixButton.Width * 2, this.Height - sixButton.Height * 7/ 2 - 10);
            sixButton.Text = @"6";
            sixButton.Click += new EventHandler(Button_Click);
            
            // Seven Button
            var sevenButton = new Button();
            sevenButton.Width = this.Size.Width / 4;
            sevenButton.Height = this.Size.Height / 9;
            sevenButton.Location = new Point(this.Width - sevenButton.Width * 4, this.Height - sevenButton.Height * 9 / 2 - 10);
            sevenButton.Text = @"7";
            sevenButton.Click += new EventHandler(Button_Click);
            
            // Eight Button
            var eightButton = new Button();
            eightButton.Width = this.Size.Width / 4;
            eightButton.Height = this.Size.Height / 9;
            eightButton.Location = new Point(this.Width - eightButton.Width * 3, this.Height - eightButton.Height * 9 / 2 - 10);
            eightButton.Text = @"8";
            eightButton.Click += new EventHandler(Button_Click);
            
            // Nine Button
            var nineButton = new Button();
            nineButton.Width = this.Size.Width / 4;
            nineButton.Height = this.Size.Height / 9;
            nineButton.Location = new Point(this.Width - nineButton.Width * 2, this.Height - nineButton.Height * 9 / 2 - 10);
            nineButton.Text = @"9";
            nineButton.Click += new EventHandler(Button_Click);
            
            // Backspace Button
            var backspaceButton = new Button();
            backspaceButton.Width = this.Size.Width / 4;
            backspaceButton.Height = this.Size.Height / 9;
            backspaceButton.Location = new Point(this.Width - backspaceButton.Width * 2, this.Height - backspaceButton.Height * 11 / 2 - 10);
            backspaceButton.Text = @"<----";
            backspaceButton.Click += new EventHandler(backspaceButton_Click);
            
            // Clear Button
            var clearButton = new Button();
            clearButton.Width = this.Size.Width / 4;
            clearButton.Height = this.Size.Height / 9;
            clearButton.Location = new Point(this.Width - clearButton.Width * 3, this.Height - clearButton.Height * 11 / 2 - 10);
            clearButton.Text = @"C";
            clearButton.Click += new EventHandler(clearButton_Click);
            
            // Clear Current Button
            var clearCurrentButton = new Button();
            clearCurrentButton.Width = this.Size.Width / 4;
            clearCurrentButton.Height = this.Size.Height / 9;
            clearCurrentButton.Location = new Point(this.Width - clearCurrentButton.Width * 4, this.Height - clearCurrentButton.Height * 11 / 2 - 10);
            clearCurrentButton.Text = @"CC";
            clearCurrentButton.Click += new EventHandler(clearCurrentButton_Click);
            
            // Divide One By Button
            var divideOneByButton = new Button();
            divideOneByButton.Width = this.Size.Width / 4;
            divideOneByButton.Height = this.Size.Height / 9;
            divideOneByButton.Location = new Point(this.Width - divideOneByButton.Width, this.Height - divideOneByButton.Height * 13 / 2 - 10);
            divideOneByButton.Text = @"1/x";
            divideOneByButton.Click += new EventHandler(divideOneByButton_Click);
            
            // Square Button
            var squareButton = new Button();
            squareButton.Width = this.Size.Width / 4;
            squareButton.Height = this.Size.Height / 9;
            squareButton.Location = new Point(this.Width - squareButton.Width * 2, this.Height - squareButton.Height * 13 / 2 - 10);
            squareButton.Text = @"x^2";
            squareButton.Click += new EventHandler(squareButton_Click);
            
            // Square Root Button
            var squareRootButton = new Button();
            squareRootButton.Width = this.Size.Width / 4;
            squareRootButton.Height = this.Size.Height / 9;
            squareRootButton.Location = new Point(this.Width - squareRootButton.Width * 3, this.Height - squareRootButton.Height * 13 / 2 - 10);
            squareRootButton.Text = @"√";
            squareRootButton.Click += new EventHandler(squareRootButton_Click);
            
            // Percent Button
            var percentButton = new Button();
            percentButton.Width = this.Size.Width / 4;
            percentButton.Height = this.Size.Height / 9;
            percentButton.Location = new Point(this.Width - percentButton.Width * 4, this.Height - percentButton.Height * 13 / 2 - 10);
            percentButton.Text = @"%";
            percentButton.Click += new EventHandler(percentButton_Click);
            
            //Calculating Bar
            var calculatingBar = new RichTextBox();
            calculatingBar.Location = new Point(0, 0);
            calculatingBar.Width = this.Width - 16;
            calculatingBar.Height = (this.Height - zeroButton.Location.Y) * 3 / 2 - 10;
            calculatingBar.Font = new Font("Tahoma", 20);
            calculatingBar.TextChanged += new EventHandler(calculatingBar_TextChanged);
            _calculatingBar = calculatingBar;
            
            #endregion
            #region Adding Controls
            this.Controls.Add(calculatingBar);
            this.Controls.Add(addOperationButton);
            this.Controls.Add(divisionOperationButton);
            this.Controls.Add(subtractOperationButton);
            this.Controls.Add(equalButton);
            this.Controls.Add(commaButton);
            this.Controls.Add(multiplyOperationButton);
            this.Controls.Add(negativeButton);
            this.Controls.Add(zeroButton);
            this.Controls.Add(oneButton);
            this.Controls.Add(twoButton);
            this.Controls.Add(threeButton);
            this.Controls.Add(fourButton);
            this.Controls.Add(fiveButton);
            this.Controls.Add(sixButton);
            this.Controls.Add(sevenButton);
            this.Controls.Add(eightButton);
            this.Controls.Add(nineButton);
            this.Controls.Add(backspaceButton);
            this.Controls.Add(clearButton);
            this.Controls.Add(clearCurrentButton);
            this.Controls.Add(percentButton);
            this.Controls.Add(divideOneByButton);
            this.Controls.Add(squareButton);
            this.Controls.Add(squareRootButton);
            #endregion
    }

    private RichTextBox _calculatingBar;
  }
}

