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
            this.txtDisplay.Text = txtDisplay.Text + "(";
            this.CurrentDisplay = txtDisplay.Text;
        }

        /// <summary>
        /// Adds the right parentheses [)]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnParaR_Click(object sender, EventArgs e)
        {
            this.txtDisplay.Text = txtDisplay.Text + ")";
            this.CurrentDisplay = txtDisplay.Text;
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
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            AddInput(1);
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            AddInput(2);
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            AddInput(3);
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            AddInput(4);
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            AddInput(5);
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            AddInput(6);
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            AddInput(7);
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            AddInput(8);
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            AddInput(9);
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
        #endregion
    }
}
