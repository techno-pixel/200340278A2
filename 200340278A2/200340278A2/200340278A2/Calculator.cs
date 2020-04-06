using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _200340278A2
{
    public enum operation
    {
        /// <summary>
        /// Operation subtract  
        /// </summary>
        Subtract,
        Add,
        Multiply,
        Divide
    }

    public partial class Calculator : Form
    {
        public operation Operation;
        public decimal firstOp = 0;
        public decimal secondOp = 0;
        private string CurrentDisplay = "0";
        private List<string> indexOperation = new List<string>();

        // has code
        #region Constructor
        /// <summary>
        /// Default Constructor 
        /// </summary>
        public Calculator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calculator_Load(object sender, EventArgs e)
        {
            txtDisplay.ReadOnly = true;
            txtDisplay.KeyPress += Calculator_KeyPress;
            txtDisplay.Text = string.Empty;
            txtDisplay.Cursor = Cursors.Arrow;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
            txtOperationString.ReadOnly = true;
        }

        private void txtDisplay_GotFocus(object sender, EventArgs e)
        {
            ((TextBox)sender).Parent.Focus();
        }
        #endregion

        // no code
        #region TextBoxes
        private void txtOperationString_TextChanged(object sender, EventArgs e)
        {

        } 

        /// <summary>
        /// Shows input from the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Shows an M when memory is being used
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMemoryUsed_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        // has code
        #region Backspace, Clear, Parentheses Buttons

        /// <summary>
        /// Erases last inputted character from the input text book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            txtDisplay.Focus();
            txtDisplay.GotFocus += txtDisplay_GotFocus;
            if(txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
        }

        /// <summary>
        /// Clears entire input textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtMemoryUsed.Text = string.Empty;
            this.CurrentDisplay = "0";
            this.indexOperation.Clear();
            this.txtDisplay.Text = string.Empty;
            this.txtOperationString.Text = string.Empty;
            txtDisplay.Focus();
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        /// <summary>
        /// Adds the left parentheses [(]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnParaL_Click(object sender, EventArgs e)
        {
            string removeDisplay = txtDisplay.Text;
            txtDisplay.Text = string.Empty;

            txtOperationString.Text = string.Empty;

            indexOperation.Add(removeDisplay);

            indexOperation.Add("(");

            foreach (string indexOps in indexOperation)
            {
                txtOperationString.Text = txtOperationString.Text + indexOps;
            }
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        /// <summary>
        /// Adds the right parentheses [)]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnParaR_Click(object sender, EventArgs e)
        {
            if (this.indexOperation.Count < 1)
            {
                MessageBox.Show("Invalid use of closing parentheses");
            }
            else
            {
                string removeDisplay = txtDisplay.Text;
                txtDisplay.Text = string.Empty;

                txtOperationString.Text = string.Empty;

                indexOperation.Add(removeDisplay);

                indexOperation.Add(")");

                foreach (string indexOps in indexOperation)
                {
                    txtOperationString.Text = txtOperationString.Text + indexOps;
                }
                txtDisplay.GotFocus += txtDisplay_GotFocus;
            }
        }
        #endregion

        // has code
        #region Memory Buttons

        /// <summary>
        /// Clears memory stack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMemClear_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Recalls the last number added to the memory stack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMemRecall_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Stores the input number into memory stack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMemStore_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Adds the value in the input box to the last value added into the memory stack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMemAdd_Click(object sender, EventArgs e)
        {

        }
        #endregion

        // has code
        #region Operation Buttons
        /// <summary>
        /// Adds a period "." to the text display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPeriod_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnPeriod.Text;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            string removeDisplay = txtDisplay.Text;
            txtDisplay.Text = string.Empty;

            txtOperationString.Text = string.Empty;

            indexOperation.Add(removeDisplay);


            if (txtOperationString.Text.Equals(indexOperation[indexOperation.Count - 1]) || txtOperationString.Text.Equals("+") ||
                txtOperationString.Text.Equals("*") || txtOperationString.Text.Equals("-"))
            {
                MessageBox.Show("Invalid use of operator");
                btnClear.PerformClick();
            }
            else
            {
                indexOperation.Add("/");

                foreach (string indexOps in indexOperation)
                {
                    txtOperationString.Text = txtOperationString.Text + indexOps;
                }
                txtDisplay.GotFocus += txtDisplay_GotFocus;
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            string removeDisplay = txtDisplay.Text;
            txtDisplay.Text = string.Empty;

            txtOperationString.Text = string.Empty;

            indexOperation.Add(removeDisplay);


            if (txtOperationString.Text.Equals(indexOperation[indexOperation.Count - 1]) || txtOperationString.Text.Equals("/") ||
                txtOperationString.Text.Equals("+") || txtOperationString.Text.Equals("-"))
            {
                MessageBox.Show("Invalid use of operator");
                btnClear.PerformClick();
            }
            else
            {
                indexOperation.Add("*");

                foreach (string indexOps in indexOperation)
                {
                    txtOperationString.Text = txtOperationString.Text + indexOps;
                }
                txtDisplay.GotFocus += txtDisplay_GotFocus;
            }
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            string removeDisplay = txtDisplay.Text;
            txtDisplay.Text = string.Empty;

            txtOperationString.Text = string.Empty;

            indexOperation.Add(removeDisplay);
            string s = indexOperation[indexOperation.Count - 1];

            if (txtOperationString.Text.Equals(s) || txtOperationString.Text.Equals("/") ||
                txtOperationString.Text.Equals("*") || txtOperationString.Text.Equals("+"))
            {
                MessageBox.Show("Invalid use of operator");
                btnClear.PerformClick();
            }
            else
            {
                indexOperation.Add("-");

                foreach (string indexOps in indexOperation)
                {
                    txtOperationString.Text = txtOperationString.Text + indexOps;
                }
                txtDisplay.GotFocus += txtDisplay_GotFocus;
            }
        }

        private void btnAddition_Click(object sender, EventArgs e)
        {
            string removeDisplay = txtDisplay.Text;
            txtDisplay.Text = string.Empty;
            
            txtOperationString.Text = string.Empty;

            indexOperation.Add(removeDisplay);

         
            if(indexOperation[indexOperation.Count - 1].Equals("+") || indexOperation[indexOperation.Count - 1].Equals("-") ||
                indexOperation[indexOperation.Count - 1].Equals("/") || indexOperation[indexOperation.Count - 1].Equals("*"))
            {
                MessageBox.Show("Invalid use of operator");
                btnClear.PerformClick();
            }
            else
            {
                indexOperation.Add("+");

                foreach (string indexOps in indexOperation)
                {
                    txtOperationString.Text = txtOperationString.Text + indexOps;
                }
                txtDisplay.GotFocus += txtDisplay_GotFocus;
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {

                if (String.IsNullOrEmpty(txtOperationString.Text)) // if textbox is empty, show message
                {
                    MessageBox.Show("You need to enter some value");
                }
                else if (!Regex.IsMatch(txtDisplay.Text, @"^([-+]? ?(\d+(\.\d{0,8})?)( ?[-+*\/] ?)?)$"))
                {
                    throw new ApplicationException("Please enter only numbers/decimals.");
                }
                else
                {
                    // method(); // if everything passes, calculate
                }
            }
            catch (ApplicationException) // catch the exception to not break the program
            {
                MessageBox.Show("Please enter only numbers/decimals.");
            }
        }
        #endregion

        // has code
        #region Additional Function Buttons
        private void btnSqrt_Click(object sender, EventArgs e)
        {

        }

        private void btnInverse_Click(object sender, EventArgs e)
        {
            Inverse();
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            //int count = 0;
            //string s = "-";
            //if (count == 0 || count % 2 == 0)
            //{
            //    CurrentDisplay = txtDisplay.Text;
            //    txtDisplay.Text = s + " " + CurrentDisplay;
            //    count++;
            //}
            //else if (count % 2 != 0)
            //{

            //}
        }
        #endregion

        //my buttons 10
        //my buttons 0 = btnZero

        // has code
        #region Numerical Buttons
        private void btnZero_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length >= 1)
            {
                txtDisplay.Text += btnZero.Text;
            }
            else
            {
                return;
            }
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnOne.Text;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnTwo.Text;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnThree.Text;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnFour.Text;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnFive.Text;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnSix.Text;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnSeven.Text;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnEight.Text;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnNine.Text;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }
        #endregion

        // has code
        #region methods
        /// <summary>
        /// operation types
        /// </summary>
        /// <param name="op"></param>
        private void PerformOperation(operation op)
        {
            Operation = op;
            firstOp = decimal.Parse(txtDisplay.Text);
            txtDisplay.Text = string.Empty;
        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar.Equals('0') || e.KeyChar.Equals(Keys.NumPad0))
            {
                btnZero.PerformClick();
                e.Handled = true;
            }

            if(e.KeyChar.Equals('1') || e.KeyChar.Equals(Keys.NumPad1))
            {
                btnOne.PerformClick();
                e.Handled = true;
            }

            if(e.KeyChar.Equals('2') || e.KeyChar.Equals(Keys.NumPad2))
            {
                btnTwo.PerformClick();
                e.Handled = true;
            }

            if(e.KeyChar.Equals('3') || e.KeyChar.Equals(Keys.NumPad3))
            {
                btnThree.PerformClick();
                e.Handled = true;
            }

            if(e.KeyChar.Equals('4') || e.KeyChar.Equals(Keys.NumPad4))
            {
                btnFour.PerformClick();
                e.Handled = true;
            }

            if(e.KeyChar.Equals('5') || e.KeyChar.Equals(Keys.NumPad5))
            {
                btnFive.PerformClick();
                e.Handled = true;
            }

            if(e.KeyChar.Equals('6') || e.KeyChar.Equals(Keys.NumPad6))
            {
                btnSix.PerformClick();
                e.Handled = true;
            }

            if(e.KeyChar.Equals('7') || e.KeyChar.Equals(Keys.NumPad7))
            {
                btnSeven.PerformClick();
                e.Handled = true;
            }

            if(e.KeyChar.Equals('8') || e.KeyChar.Equals(Keys.NumPad8))
            {
                btnEight.PerformClick();
                e.Handled = true;
            }

            if(e.KeyChar.Equals('9') || e.KeyChar.Equals(Keys.NumPad9))
            {
                btnNine.PerformClick();
                e.Handled = true;
            }

            if(e.KeyChar.Equals('('))
            {
                btnParaL.PerformClick();
                e.Handled = true;
            }

            if(e.KeyChar.Equals(')'))
            {
                btnParaR.PerformClick();
                e.Handled = true;
            }

            if(e.KeyChar == (char)8)
            {
                btnBack.PerformClick();
                e.Handled = true;
            }

            if(e.KeyChar.Equals('.') || e.KeyChar.Equals(Keys.OemPeriod))
            {
                btnPeriod.PerformClick();
                e.Handled = true;
            }

            if(e.KeyChar.Equals('+') || e.KeyChar.Equals(Keys.Oemplus))
            {
                btnAddition.PerformClick();
                e.Handled = true;
            }

            if (e.KeyChar.Equals('/') || e.KeyChar.Equals(Keys.Divide))
            {
                btnDivide.PerformClick();
                e.Handled = true;
            }

            if (e.KeyChar.Equals('*') || e.KeyChar.Equals(Keys.Multiply))
            {
                btnMultiply.PerformClick();
                e.Handled = true;
            }

            if (e.KeyChar.Equals('-') || e.KeyChar.Equals(Keys.Subtract))
            {
                btnSubtract.PerformClick();
                e.Handled = true;
            }
        }

        private void Inverse()
        {
            decimal inverseResult;
            string txtToParse = txtDisplay.Text;
            if (decimal.TryParse(txtToParse, out decimal parsedNumbers))
            {
                inverseResult = 1 / parsedNumbers;
                txtDisplay.Text = inverseResult.ToString();
                CurrentDisplay = string.Empty;
            }
            txtDisplay.Focus();
        }

        private void Parse()
        {
            
        }
        #endregion
    }
}
