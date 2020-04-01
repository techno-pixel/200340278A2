using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _200340278A2
{
    public partial class Calculator : Form
    {
        #region Constructor
        /// <summary>
        /// Default Constructor 
        /// </summary>
        public Calculator()
        {
            InitializeComponent();
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
        }

        /// <summary>
        /// Adds the left parentheses [(]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnParaL_Click(object sender, EventArgs e)
        {
            this.txtDisplay.Text = txtDisplay.Text + "(";
        }

        /// <summary>
        /// Adds the right parentheses [)]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnParaR_Click(object sender, EventArgs e)
        {
            this.txtDisplay.Text = txtDisplay.Text + ")";
        }
        #endregion

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

        #region Operation Buttons
        private void btnPeriod_Click(object sender, EventArgs e)
        {
            
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

        }
        #endregion

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

        #region Numerical Buttons
        private void btnZero_Click(object sender, EventArgs e)
        {

        }

        private void btnOne_Click(object sender, EventArgs e)
        {

        }

        private void btnTwo_Click(object sender, EventArgs e)
        {

        }

        private void btnThree_Click(object sender, EventArgs e)
        {

        }

        private void btnFour_Click(object sender, EventArgs e)
        {

        }

        private void btnFive_Click(object sender, EventArgs e)
        {

        }

        private void btnSix_Click(object sender, EventArgs e)
        {

        }

        private void btnSeven_Click(object sender, EventArgs e)
        {

        }

        private void btnEight_Click(object sender, EventArgs e)
        {

        }

        private void btnNine_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
