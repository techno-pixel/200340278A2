using System;
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
        private string CurrentDisplay = "0";

        // no code
        #region Constructor
        /// <summary>
        /// Default Constructor 
        /// </summary>
        public Calculator()
        {
            InitializeComponent();
            txtDisplay.ReadOnly = true;
            txtDisplay.Text = "0";
            txtDisplay.KeyPress += Calculator_KeyPress;
        }

        /// <summary>
        /// No work required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        #endregion

        // no code
        #region TextBoxes

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
        #region Return, Clear, Parentheses Buttons

        /// <summary>
        /// Erases last inputted character from the input text book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Clears entire input textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtDisplay.Text = string.Empty;
            this.txtMemoryUsed.Text = string.Empty;
            this.CurrentDisplay = string.Empty;
            this.txtDisplay.Text = "0";
        }

        /// <summary>
        /// Adds the left parentheses [(]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnParaL_Click(object sender, EventArgs e)
        {
            if(this.txtDisplay.Text == "0")
            {
                this.txtDisplay.Text = "(";
            } else
            {
                this.txtDisplay.Text = txtDisplay.Text + "(";
                this.CurrentDisplay = txtDisplay.Text;
            }
        }

        /// <summary>
        /// Adds the right parentheses [)]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnParaR_Click(object sender, EventArgs e)
        {
            if (this.txtDisplay.Text == "0")
            {
                this.txtDisplay.Text = ")";
            }
            else
            {
                this.txtDisplay.Text = txtDisplay.Text + ")";
                this.CurrentDisplay = txtDisplay.Text;
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
            AddString(".");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {

        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {

        }

        private void btnSubstract_Click(object sender, EventArgs e)
        {

        }

        private void btnAddition_Click(object sender, EventArgs e)
        {

        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            // Checking the inputs to make sure they are values that the form accepts (only positive, one decimal point, only numbers)
            try
            {

                if (String.IsNullOrEmpty(txtDisplay.Text)) // if textbox is empty, show message
                {
                    MessageBox.Show("You need to enter some value");
                }
                else if (!Regex.IsMatch(txtDisplay.Text, @"^\d+([\.\,]?\d+)?$")) // regex to allow only positive numbers and one decimal point
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
            
        }

        private void btnSign_Click(object sender, EventArgs e)
        {

        }
        #endregion

        // has code
        #region Numerical Buttons
        private void btnZero_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length >= 1)
            {
                txtDisplay.Text = txtDisplay.Text + "0";
            }
            else
            {
                return;
            }
            txtDisplay.Focus();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            AddInput(1);
            txtDisplay.Focus();
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            AddInput(2);
            txtDisplay.Focus();
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            AddInput(3);
            txtDisplay.Focus();
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            AddInput(4);
            txtDisplay.Focus();
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            AddInput(5);
            txtDisplay.Focus();
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            AddInput(6);
            txtDisplay.Focus();
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            AddInput(7);
            txtDisplay.Focus();
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            AddInput(8);
            txtDisplay.Focus();
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            AddInput(9);
            txtDisplay.Focus();
        }
        #endregion

        // has code
        #region methods
        private void AddInput(int number)
        {
            if (CurrentDisplay.Equals("0")) // when the current display is '0' start with the new number
            { 
                CurrentDisplay = number.ToString();
            } else
            {
                CurrentDisplay += number;
                txtDisplay.Text = CurrentDisplay;
            }
        }

        private void AddString(string period)
        {
            if(CurrentDisplay.Equals("0"))
            {
                CurrentDisplay = period.ToString(); // when the current display is '0' start with a period
            } else
            {
                CurrentDisplay += period;
                txtDisplay.Text = CurrentDisplay;
            }
        }

        /// <summary>
        /// operation types
        /// </summary>
        /// <param name="op"></param>
        private void PerformOperation(operation op)
        {
            switch (Operation)
            {
                case operation.Subtract:
                    //method here
                    break;
                case operation.Add:
                    //method here
                    break;
                case operation.Multiply:
                    //method here
                    break;
                case operation.Divide:
                    //method here
                    break;
            }
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
                btnParaL.PerformClick();
                e.Handled = true;
            }

            if(e.KeyChar == (char)8)
            {
                if(txtDisplay.Text.Length < 1)
                {
                    MessageBox.Show("You need some values to erase!");
                } else
                {
                    txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.TextLength - 1);
                }
            }
        }
        #endregion
    }
}
