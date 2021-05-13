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

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        //adds a 0 to the memory at start of the program
        private void Calculator_Load(object sender, EventArgs e)
        {
            memoryList.Add(0);
        }

        //used to print a number depending on which button is clicked
        private void buttonClickPrintNumber(object sender, EventArgs e)
        {
            if (tBoxResult.Text == "0")
            {
                tBoxResult.Clear();
            }

            Button clickedButton = (Button)sender;
            tBoxResult.Text += clickedButton.Text;
        }

        //controls what the user can input into the calculator (forbids letters and other signs not allowed in the calculator)
        //also forces the input to go through the buttons of the calculator
        private void keyPressLimitations(object sender, KeyPressEventArgs e)
        {
            #region Limitations
            if (char.IsLetter(e.KeyChar))
            {
                labelWarning.Text = "You cannot calculate with letters!";
                e.Handled = true;
            }
            else
            {
                if (!char.IsNumber(e.KeyChar))
                {
                    switch (e.KeyChar)
                    {
                        case '+':
                            btnPlus.PerformClick();
                            e.Handled = true;
                            break;
                        case '-':
                            btnMinus.PerformClick();
                            e.Handled = true;
                            break;
                        case '*':
                            btnMultiply.PerformClick();
                            e.Handled = true;
                            break;
                        case '/':
                            btnDivide.PerformClick();
                            e.Handled = true;
                            break;
                        case '=':
                            btnEquals.PerformClick();
                            e.Handled = true;
                            break;
                        case '.':
                            btnFractionSign.PerformClick();
                            e.Handled = true;
                            break;
                        case ',':
                            btnFractionSign.PerformClick();
                            e.Handled = true;
                            break;
                        case '\b':
                            break;
                        default:
                            labelWarning.Text = "Invalid symbol!";
                            e.Handled = true;
                            break;
                    }
                }
                else
                {
                    switch (e.KeyChar)
                    {
                        case '1':
                            btnNumber1.PerformClick();
                            e.Handled = true;
                            break;
                        case '2':
                            btnNumber2.PerformClick();
                            e.Handled = true;
                            break;
                        case '3':
                            btnNumber3.PerformClick();
                            e.Handled = true;
                            break;
                        case '4':
                            btnNumber4.PerformClick();
                            e.Handled = true;
                            break;
                        case '5':
                            btnNumber5.PerformClick();
                            e.Handled = true;
                            break;
                        case '6':
                            btnNumber6.PerformClick();
                            e.Handled = true;
                            break;
                        case '7':
                            btnNumber7.PerformClick();
                            e.Handled = true;
                            break;
                        case '8':
                            btnNumber8.PerformClick();
                            e.Handled = true;
                            break;
                        case '9':
                            btnNumber9.PerformClick();
                            e.Handled = true;
                            break;
                        case '0':
                            btnNumber0.PerformClick();
                            e.Handled = true;
                            break;
                        default:
                            labelWarning.Text = "Invalid symbol!";
                            e.Handled = true;
                            break;
                    }
                }
            }
            #endregion
            //to add other actions on key press
            //specifically refresh info

        }

        //clears the tbox for typing in case it is zero
        private void placeholderZeroClear(object sender, EventArgs e)
        {
            if (tBoxResult.Text == "0")
            {
                tBoxResult.Clear();
            }
        }

        //checks if the input is of the format: number operation number and divides it into 3 strings in an array
        private string[] splitInputLine(string input)
        {
            var regex = new Regex(@"([\-\+]?\d*\.?\d{1,})([\+\-\*\/])([\-\+]?\d*\.?\d{1,})");
            string[] splitResult = new string[3];
            if (regex.IsMatch(input))
            {
                var match = regex.Match(input);
                splitResult[0] = match.Groups[1].Value;
                splitResult[1] = match.Groups[2].Value;
                splitResult[2] = match.Groups[3].Value;
            }
            else
            {
                //labelWarning.Text = "Invalid expression!";
                splitResult = null;
            }

            return splitResult;
        }

        //calculates result after receiving and already split input
        private double CalculateFinalResult(string[] splitInput)
        {
            if (splitInput == null)
            {
                labelWarning.Text = "Invalid expression!";
                return 0;
            }
            double firstNumber = double.Parse(splitInput[0]);
            double secondNumber = double.Parse(splitInput[2]);
            double result = 0;

            switch (splitInput[1])
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
                default:
                    labelWarning.Text = "Unpredicted Error";
                    break;
            }

            return result;
        }
        

        private void btnPlus_Click(object sender, EventArgs e)
        {
            string[] splitInput = splitInputLine(tBoxResult.Text);
            if (splitInput != null)
            {
                btnEquals.PerformClick();
            }
            tBoxResult.Text += "+";
        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            string[] splitInput = splitInputLine(tBoxResult.Text);
            if (splitInput != null)
            {
                btnEquals.PerformClick();
            }
            tBoxResult.Text += "-";
        }
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            string[] splitInput = splitInputLine(tBoxResult.Text);
            if (splitInput != null)
            {
                btnEquals.PerformClick();
            }
            tBoxResult.Text += "*";
        }
        private void btnDivide_Click(object sender, EventArgs e)
        {
            string[] splitInput = splitInputLine(tBoxResult.Text);
            if (splitInput != null)
            {
                btnEquals.PerformClick();
            }
            tBoxResult.Text += "/";
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            //CalculateResult(tBoxResult.Text);
            labelWarning.Text = "";
            string[] splitInput = splitInputLine(tBoxResult.Text);
            double result = CalculateFinalResult(splitInput);
            tBoxResult.Text = result.ToString();

        }

        private void btnFractionSign_Click(object sender, EventArgs e)
        {
            tBoxResult.Text += ".";
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (tBoxResult.Text != "")
            {
                tBoxResult.Text = tBoxResult.Text.Remove(tBoxResult.Text.Length - 1, 1);
            }
            
        }

        //forbids users to type into the memory
        private void KeyPressRestrictOnMemory(object sender, KeyPressEventArgs e)
        {
            labelWarning.Text = "You cannot directly change memory!";
            e.Handled = true;
        }

        //checks if the input is just a number and puts it into an array (can be potentionally optimized to be just a single string)
        private string[] splitInputLineAtNumber(string input)
        {
            var regex = new Regex(@"([\-\+]?\d*\.?\d{1,})");
            string[] splitResult = new string[1];
            if (regex.IsMatch(input))
            {
                var match = regex.Match(input);
                splitResult[0] = match.Groups[1].Value;
            }
            else
            {
                //labelWarning.Text = "Invalid expression!";
                splitResult = null;
            }

            return splitResult;
        }

        //note the next four methods will behave in the following way in case of the format: number operation, operation, ... operation number
        //it will take into account only the first number
        // behaves correctly in case of format: number operation number (will calculate the expression first and then affect the number)
        private void btnDivide1_Click(object sender, EventArgs e)
        {
            string[] splitInput = splitInputLine(tBoxResult.Text);
            if (splitInput != null)
            {
                btnEquals.PerformClick();
                tBoxResult.Text = (1 / double.Parse(tBoxResult.Text)).ToString();
            }
            else
            {
                string[] splitInputVersion2 = splitInputLineAtNumber(tBoxResult.Text);
                if (splitInputVersion2 != null)
                {
                    tBoxResult.Text = splitInputVersion2[0];
                    tBoxResult.Text = (1 / double.Parse(tBoxResult.Text)).ToString();
                }
                else
                {
                    labelWarning.Text = "Invalid expression!";
                }
            }
        }
        
        private void btnSquare_Click(object sender, EventArgs e)
        {
            string[] splitInput = splitInputLine(tBoxResult.Text);
            if (splitInput != null)
            {
                btnEquals.PerformClick();
                tBoxResult.Text = Math.Pow(double.Parse(tBoxResult.Text), 2).ToString();
            }
            else
            {
                string[] splitInputVersion2 = splitInputLineAtNumber(tBoxResult.Text);
                if (splitInputVersion2 != null)
                {
                    tBoxResult.Text = splitInputVersion2[0];
                    tBoxResult.Text = Math.Pow(double.Parse(tBoxResult.Text), 2).ToString();
                }
                else
                {
                    labelWarning.Text = "Invalid expression!";
                }
            }
        }

        private void btnSquareRoot_Click(object sender, EventArgs e)
        {
            string[] splitInput = splitInputLine(tBoxResult.Text);
            if (splitInput != null)
            {
                btnEquals.PerformClick();
                tBoxResult.Text = Math.Pow(double.Parse(tBoxResult.Text), 0.5).ToString();
            }
            else
            {
                string[] splitInputVersion2 = splitInputLineAtNumber(tBoxResult.Text);
                if (splitInputVersion2 != null)
                {
                    tBoxResult.Text = splitInputVersion2[0];
                    tBoxResult.Text = Math.Pow(double.Parse(tBoxResult.Text), 0.5).ToString();
                }
                else
                {
                    labelWarning.Text = "Invalid expression!";
                }

            }
        }

        private void btnReverseSign_Click(object sender, EventArgs e)
        {
            string[] splitInput = splitInputLine(tBoxResult.Text);
            if (splitInput != null)
            {
                btnEquals.PerformClick();
                double currentNumber = double.Parse(tBoxResult.Text);
                tBoxResult.Text = (double.Parse(tBoxResult.Text) * (-1) ).ToString();
            }
            else
            {
                string[] splitInputVersion2 = splitInputLineAtNumber(tBoxResult.Text);
                if (splitInputVersion2 != null)
                {
                    tBoxResult.Text = splitInputVersion2[0];
                    tBoxResult.Text = (double.Parse(tBoxResult.Text) * (-1)).ToString();
                }
                else
                {
                    labelWarning.Text = "Invalid expression!";
                }

            }
        }

        
        private List<double> memoryList = new List<double>();
        private void PrintMemoryList()
        {
            tBoxMemory.Text = "";

            for (int i = memoryList.Count - 1; i >= 0; i--)
            {
                tBoxMemory.Text += memoryList[i] + Environment.NewLine;
            }
        }


        private void btnMemorySave_Click(object sender, EventArgs e)
        {
            string[] splitInput = splitInputLine(tBoxResult.Text);
            if (splitInput != null)
            {
                btnEquals.PerformClick();
                double currentNumber = double.Parse(tBoxResult.Text);
                memoryList.Add(currentNumber);
                PrintMemoryList();
            }
            else
            {
                string[] splitInputVersion2 = splitInputLineAtNumber(tBoxResult.Text);
                if (splitInputVersion2 != null)
                {
                    tBoxResult.Text = splitInputVersion2[0];
                    memoryList.Add(double.Parse(tBoxResult.Text));
                    PrintMemoryList();
                }
                else
                {
                    labelWarning.Text = "Invalid expression!";
                }
            }
        }

        private void btnMemoryPlus_Click(object sender, EventArgs e)
        {
            string[] splitInput = splitInputLine(tBoxResult.Text);
            if (splitInput != null)
            {
                btnEquals.PerformClick();
                double currentNumber = double.Parse(tBoxResult.Text);
                memoryList[memoryList.Count - 1] += currentNumber;
                PrintMemoryList();
            }
            else
            {
                string[] splitInputVersion2 = splitInputLineAtNumber(tBoxResult.Text);
                if (splitInputVersion2 != null)
                {
                    tBoxResult.Text = splitInputVersion2[0];
                    memoryList[memoryList.Count - 1] += double.Parse(tBoxResult.Text);
                    PrintMemoryList();
                }
                else
                {
                    labelWarning.Text = "Invalid expression!";
                }
            }
        }

        private void btnMemoryMinus_Click(object sender, EventArgs e)
        {
            string[] splitInput = splitInputLine(tBoxResult.Text);
            if (splitInput != null)
            {
                btnEquals.PerformClick();
                double currentNumber = double.Parse(tBoxResult.Text);
                memoryList[memoryList.Count - 1] -= currentNumber;
                PrintMemoryList();
            }
            else
            {
                string[] splitInputVersion2 = splitInputLineAtNumber(tBoxResult.Text);
                if (splitInputVersion2 != null)
                {
                    tBoxResult.Text = splitInputVersion2[0];
                    memoryList[memoryList.Count - 1] -= double.Parse(tBoxResult.Text);
                    PrintMemoryList();
                }
                else
                {
                    labelWarning.Text = "Invalid expression!";
                }
            }
        }

        private void btnMemoryRecall_Click(object sender, EventArgs e)
        {
            tBoxResult.Text = memoryList[memoryList.Count - 1].ToString();
        }

        private void btnMemoryClear_Click(object sender, EventArgs e)
        {
            int numberCount = memoryList.Count;
            for (int i = numberCount - 1; i >= 0; i--)
            {
                memoryList.RemoveAt(i);
            }
            memoryList.Add(0);
            PrintMemoryList();
        }
    }
}
