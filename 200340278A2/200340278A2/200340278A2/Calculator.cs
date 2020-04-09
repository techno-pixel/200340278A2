using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data; // for evaluating order of operations
using System.Collections; // for the stack



namespace _200340278A2
{
    #region KEKW MemoryCalculator Class
    public class MemoryCalculator : _200340278A2.Calculator
    {
        // create a stack for memory
        public Stack memoryStack = new Stack();

        // method to add text value in display to the last stored memory
        public void memAdd(Calculator cal)
        {
            if (cal.memAddClick == true) 
            {
                if (memoryStack.Count < 1)
                {
                    MessageBox.Show("You need to store a value first!");
                }
                else
                {
                    string toAdd = memoryStack.Pop().ToString();
                    double resulties = Double.Parse(toAdd) + double.Parse(cal.txtDisplay.Text);
                    memoryStack.Push(resulties);
                    cal.txtOperationString.Text = resulties.ToString();
                    cal.txtDisplay.Text = string.Empty;
                    cal.memAddClick = false;
                }
            }
        }

        // method to add text value in display to the memory stack
        public void memStore(Calculator cal)
        {
            if(cal.txtDisplay.Text.Length < 1)
            {
                MessageBox.Show("No values to store!");
            } else if(cal.storeClicked == true)
            {
                memoryStack.Push(cal.txtDisplay.Text);
                cal.txtMemoryUsed.Text = "M";
                cal.txtDisplay.Text = string.Empty;
                cal.storeClicked = false;
            }
        }

        // method to clear M from txtbox and to clear stack
        public void memClear(Calculator cal)
        {
            if (memoryStack.Count < 1)
            {
                MessageBox.Show("No memory to clear!");
            } else if (cal.memClearClicked == true)
            {
                memoryStack.Clear();
                cal.memClearClicked = false;
            }
        }

        // method to display last memory in stack in text display
        public void memRecall(Calculator cal)
        {
            if (memoryStack.Count < 1)
            {
                MessageBox.Show("No values to recall!");
            }
            else if (cal.recallClicked == true)
            {
                cal.txtDisplay.Text = memoryStack.Pop().ToString();
                cal.recallClicked = false;
            }
        }
    }
    #endregion

    public partial class Calculator : Form
    {
        /// <summary>
        /// had to create these objects so that I can call the methods in the memorycalc class
        /// </summary>
        public class MemoryClass 
        { 
            public MemoryCalculator memCalc;

            public MemoryClass() 
            {
                memCalc = new MemoryCalculator();
            }
        }

        // all my variables and objects
        public string CurrentDisplay = "0";
        public List<string> indexOperation = new List<string>();
        public const string OPERATORS = "+-/*.";
        public int countL = 0;
        public int countR = 0;
        public bool storeClicked = false;
        public bool recallClicked = false;
        public bool memAddClick = false;
        public bool memClearClicked = false;
        public DataTable CalendarDataTable = new DataTable();  // object that behaves like excel tables to perform calculations while following order of operations
        public MemoryClass mc;


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
        /// things to do on load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Calculator_Load(object sender, EventArgs e)
        {
            txtDisplay.ReadOnly = true;
            txtDisplay.KeyPress += Calculator_KeyPress;
            txtDisplay.Text = string.Empty;
            txtDisplay.Cursor = Cursors.Arrow;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
            txtOperationString.ReadOnly = true;
            mc = new MemoryClass();
        }

        protected void txtDisplay_GotFocus(object sender, EventArgs e)
        {
            ((TextBox)sender).Parent.Focus(); // to put focus back on textbox
        }
        #endregion

        // no code
        #region TextBoxes
        protected void txtOperationString_TextChanged(object sender, EventArgs e)
        {

        } 

        /// <summary>
        /// Shows input from the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtDisplay_TextChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Shows an M when memory is being used
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtMemoryUsed_TextChanged(object sender, EventArgs e)
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
        protected void btnBack_Click(object sender, EventArgs e)
        {
            txtDisplay.Focus();
            txtDisplay.GotFocus += txtDisplay_GotFocus;
            if (string.IsNullOrEmpty(txtDisplay.Text))
            {
                txtDisplay.Text = txtDisplay.Text;
            }
            else if (txtDisplay.Text.Last().Equals("("))
            {
                countL--;
            } 
            else if(txtDisplay.Text.Last().Equals(")"))
            {
                countR--;
            } 
            else if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
        }

        /// <summary>
        /// Clears entire input textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
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
        protected void btnParaL_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnParaL.Text;
            countL++;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        /// <summary>
        /// Adds the right parentheses [)]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnParaR_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnParaR.Text;
            countR++;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
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
            memClearClicked = true;
            txtMemoryUsed.Text = string.Empty;
            mc.memCalc.memClear(this);
        }

        /// <summary>
        /// Recalls the last number added to the memory stack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnMemRecall_Click(object sender, EventArgs e)
        {
            recallClicked = true;
            mc.memCalc.memRecall(this);
        }

        /// <summary>
        /// Stores the input number into memory stack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnMemStore_Click(object sender, EventArgs e)
        {
            storeClicked = true;
            mc.memCalc.memStore(this);
        }

        /// <summary>
        /// Adds the value in the input box to the last value added into the memory stack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnMemAdd_Click(object sender, EventArgs e)
        {
            memAddClick = true;
            mc.memCalc.memAdd(this);
        }
        #endregion
        
        // has code
        #region Operation Buttons (+-*/.=)
        /// <summary>
        /// Adds a period "." to the text display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPeriod_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDisplay.Text))
            {
                txtDisplay.Text += "0.";
            }
            else if (OPERATORS.Contains(txtDisplay.Text.Last()))  // if that last operator is a +-/*. then remove it
            {
                txtDisplay.Text = txtDisplay.Text;
            } 
            else
            {
                txtDisplay.Text += btnPeriod.Text;
            }
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        /// <summary>
        /// Adds a /
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDivide_Click(object sender, EventArgs e)
        {
            if((countL == countR) && (countL > 0 && countR > 0))
            {
                string removeDisplay = txtDisplay.Text;
                txtDisplay.Text = string.Empty;

                txtOperationString.Text = string.Empty;

                indexOperation.Add(removeDisplay);

                indexOperation.Add("/");

                foreach (string indexOps in indexOperation)
                {
                    txtOperationString.Text = txtOperationString.Text + indexOps;
                }
                countL = 0;
                countR = 0;
            } else if (string.IsNullOrEmpty(txtDisplay.Text) || OPERATORS.Contains(txtDisplay.Text.Last())) // if that last operator is a +-/*. then remove it
            {
                txtDisplay.Text = txtDisplay.Text;
            }
            else
            {
                txtDisplay.Text += btnDivide.Text;
            }
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        /// <summary>
        /// Adds a *
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnMultiply_Click(object sender, EventArgs e)
        {
            if ((countL == countR) && (countL > 0 && countR > 0))
            {
                string removeDisplay = txtDisplay.Text;
                txtDisplay.Text = string.Empty;

                txtOperationString.Text = string.Empty;

                indexOperation.Add(removeDisplay);

                indexOperation.Add("*");

                foreach (string indexOps in indexOperation)
                {
                    txtOperationString.Text = txtOperationString.Text + indexOps;
                }
                countL = 0;
                countR = 0;
            }
            else if (string.IsNullOrEmpty(txtDisplay.Text) || OPERATORS.Contains(txtDisplay.Text.Last())) // if that last operator is a +-/*. then remove it
            {
                txtDisplay.Text = txtDisplay.Text;
            }
            else
            {
                txtDisplay.Text += btnMultiply.Text;
            }
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        /// <summary>
        /// Adds a period -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubtract_Click(object sender, EventArgs e)
        {
            if ((countL == countR) && (countL > 0 && countR > 0))
            {
                string removeDisplay = txtDisplay.Text;
                txtDisplay.Text = string.Empty;

                txtOperationString.Text = string.Empty;

                indexOperation.Add(removeDisplay);

                indexOperation.Add("-");

                foreach (string indexOps in indexOperation)
                {
                    txtOperationString.Text = txtOperationString.Text + indexOps;
                }
                countL = 0;
                countR = 0;
            }
            else if (string.IsNullOrEmpty(txtDisplay.Text) || OPERATORS.Contains(txtDisplay.Text.Last())) // if that last operator is a +-/*. then remove it
            {
                txtDisplay.Text = txtDisplay.Text;
            }
            else
            {
                txtDisplay.Text += btnSubtract.Text;
            }
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        /// <summary>
        /// Adds a period +
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddition_Click(object sender, EventArgs e)
        {
            if((countL == countR) && (countL > 0 && countR > 0))
            {
                string removeDisplay = txtDisplay.Text;
                txtDisplay.Text = string.Empty;

                txtOperationString.Text = string.Empty;

                indexOperation.Add(removeDisplay);

                indexOperation.Add("+");

                foreach (string indexOps in indexOperation)
                {
                    txtOperationString.Text = txtOperationString.Text + indexOps;
                }
                countL = 0;
                countR = 0;
            }
            else if (string.IsNullOrEmpty(txtDisplay.Text) || OPERATORS.Contains(txtDisplay.Text.Last())) // if that last operator is a +-/*. then remove it
            {
                txtDisplay.Text = txtDisplay.Text;
            }
            else
            {
                txtDisplay.Text += btnAddition.Text;
            }
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        /// <summary>
        /// to evaluate or hit equals on the entire operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEquals_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            try
            {
                if(string.IsNullOrEmpty(txtDisplay.Text))
                {
                    txtDisplay.Text = txtDisplay.Text;
                }
                else if (OPERATORS.Contains(txtDisplay.Text.Last())) // if that last operator is a +-/*. then remove it
                {
                    txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
                } else if (countL != countR)
                {
                    MessageBox.Show("Your brackets are not balanced!"); // to catch unbalanced brackets i.e. ((xxx)
                    txtDisplay.GotFocus += txtDisplay_GotFocus;
                }
                else if (!Regex.IsMatch(txtDisplay.Text, @"[0-9]*\.?[0-9]+([-+]?[0-9]+)?|[-^+*/()]|\w+")) // small regex to allow decimals and brackets and operators
                {
                    throw new ApplicationException("Please enter only numbers/decimals.");
                }
                else
                {
                    // if everything passes, calculate
                    string removeDisplay = txtDisplay.Text;
                    txtDisplay.Text = string.Empty;

                    txtOperationString.Text = string.Empty;

                    indexOperation.Add(removeDisplay);

                    foreach (string indexOps in indexOperation)
                    {
                        txtOperationString.Text = txtOperationString.Text + indexOps;
                    }
                    result = CalendarDataTable.Compute(txtOperationString.Text, "").ToString();
                    if (result == "∞") // x / 0 shows an infinity symbol in textbox, so i worked my way around it
                    {
                        MessageBox.Show("Cannot divide by zero");
                        btnClear.PerformClick();
                        txtDisplay.GotFocus += txtDisplay_GotFocus;
                    }
                    else
                    {
                        btnClear.PerformClick();
                        txtDisplay.GotFocus += txtDisplay_GotFocus;
                        txtDisplay.Text = result;
                    }
                } 
            }
            catch (ApplicationException) // catch the exception to not break the program
            {
                MessageBox.Show("Please enter only valid numbers/decimals and operators.");
            }
        }
        #endregion

        // has code
        #region Additional Function Buttons
        /// <summary>
        /// square root a number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSqrt_Click(object sender, EventArgs e)
        {
            
            if (txtDisplay.Text.Length < 1)
            {
                MessageBox.Show("No value entered!");
            }
            else
            {
                double rez = Double.Parse(txtDisplay.Text);
                if(rez < 1)
                {
                    MessageBox.Show("Cannot square root a negative number"); // number cant be negative
                    btnClear.PerformClick();
                } else
                {
                    string result = Math.Sqrt(rez).ToString();
                    txtDisplay.GotFocus += txtDisplay_GotFocus;
                    txtDisplay.Text = result;
                }
            }
        }

        /// <summary>
        /// 1/X function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInverse_Click(object sender, EventArgs e)
        {
            if(txtDisplay.Text.Length < 1)
            {
                MessageBox.Show("No value entered!");
            } else
            {
                Inverse();
                txtDisplay.GotFocus += txtDisplay_GotFocus;
            }
        }

        /// <summary>
        /// reverses the sign, adds - at the beginning if it is positive, and vice versa removes it if it is negative
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSign_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length < 1)
            {
                MessageBox.Show("No value entered!");
            }
            else
            {
                double rez = Double.Parse(txtDisplay.Text);
                double result = rez * (-1);
                string finalRez = result.ToString();
                txtDisplay.GotFocus += txtDisplay_GotFocus;
                txtDisplay.Text = finalRez;
            }
        }
        #endregion

        // all of the code is just appending the button's text (i.e. the numbers) to the text box
        #region Numerical Buttons
        protected void btnZero_Click(object sender, EventArgs e)
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

        protected void btnOne_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnOne.Text;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        protected void btnTwo_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnTwo.Text;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        protected void btnThree_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnThree.Text;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        protected void btnFour_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnFour.Text;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        protected void btnFive_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnFive.Text;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        protected void btnSix_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnSix.Text;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        protected void btnSeven_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnSeven.Text;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        protected void btnEight_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnEight.Text;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }

        protected void btnNine_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnNine.Text;
            txtDisplay.GotFocus += txtDisplay_GotFocus;
        }
        #endregion

        // just if statements to measure key presses so that we can capture keyboard typing too
        #region methods
        protected void Calculator_KeyPress(object sender, KeyPressEventArgs e)
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

        // method to perform 1/X
        public virtual void Inverse()
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
        #endregion
    }
}




