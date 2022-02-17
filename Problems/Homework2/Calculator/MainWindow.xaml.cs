using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        private double firstInput; //1st operand
        private double secondInput; //2nd operand
        private double result;
        private double memorySaved;
        private int inputIndex;//helper to know where are we in the input
        private enum Operation
        {
            NO_OPERATION, PLUS, MINUS, DIVIDE, MULTIPLY,
            SIN, COS, LOG, EXP, SQRT
        };
        private Operation operation;
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            firstInput = secondInput = memorySaved = inputIndex = 0;
            operation = Operation.NO_OPERATION;
        }
        #endregion

        #region EventHandlers


        private void BtnOff_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        #region Digit Operations

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {//remove just the last

            string currentText = txtInput.Text;
            if (currentText.Length <= 1)
            {
                txtInput.Text = "0";
            }
            else if (!Char.IsDigit(currentText[currentText.Length - 1]))
            { //its operation

                if (currentText[currentText.Length - 1] == ')')
                { //cos,sin and etc
                    string currentNumEnd = txtInput.Text.Substring(0, txtInput.Text.Length - 1);//remove ')'
                    if (!Char.IsDigit(currentNumEnd[currentNumEnd.Length - 1])) // last is not number , remove operator
                    {
                        operation = Operation.NO_OPERATION;
                        txtInput.Text = "0";
                        inputIndex = 0;
                    }
                    else //so its a digit
                    {
                        currentNumEnd = currentNumEnd.Remove(currentNumEnd.Length - 1);//remove the last digit
                        //inputIndex--;
                        txtInput.Text = currentNumEnd + ')';
                    }
                    return;
                }
                else
                {//remove the operation
                    operation = Operation.NO_OPERATION;
                }
            }
            txtInput.Text = currentText.Remove(currentText.Length - 1, 1);

        }

        private void BtnCA_Click(object sender, RoutedEventArgs e)
        {
            firstInput = secondInput = inputIndex = 0;
            operation = Operation.NO_OPERATION;
            txtInput.Text = "0";
        }

        private void OperationForSingleParamClick(object sender, RoutedEventArgs e)
        {
            string content = ((string)((Button)sender).Content); ; //get name of element , symbow

            double.TryParse(txtInput.Text, out firstInput); // 0 if fails

            switch (content)
            {
                case "SIN":
                    operation = Operation.SIN;
                    txtInput.Text = "Sin(" + firstInput + ')';
                    inputIndex = 3;
                    break;
                case "COS":
                    operation = Operation.COS;
                    txtInput.Text = "Cos(" + firstInput + ')';
                    inputIndex = 3;
                    break;
                case "SQRT":
                    operation = Operation.SQRT;
                    txtInput.Text = "Sqrt(" + firstInput + ')';
                    inputIndex = 4;
                    break;
                case "LOG":
                    operation = Operation.LOG;
                    txtInput.Text = "Log(" + firstInput + ')';
                    inputIndex = 3;
                    break;
                case "1/n":
                    txtInput.Text = "1/" + firstInput;
                    firstInput = 1;
                    operation = Operation.DIVIDE;
                    inputIndex = 2;
                    break;

                default:
                    operation = Operation.NO_OPERATION;
                    break;
            }


        }



        private void OperationForTwoParamClick(object sender, RoutedEventArgs e)
        {
            string content = ((string)((Button)sender).Content); ; //get name of element , symbow

            if (double.TryParse(txtInput.Text, out firstInput))
            {//if try is true , inicial firstInput

                switch (content)
                {
                    case "+":
                        operation = Operation.PLUS;
                        break;
                    case "-":
                        operation = Operation.MINUS;
                        break;
                    case "*":
                        operation = Operation.MULTIPLY;
                        break;
                    case "/":
                        operation = Operation.DIVIDE;
                        break;
                    case "EXP":
                        operation = Operation.EXP;
                        content = "E";
                        break;

                    default:
                        operation = Operation.NO_OPERATION;
                        break;
                }
                txtInput.Text += content;
                inputIndex = txtInput.Text.Length; //set position for second input to start from
                                                   
            }
            else
            {
                operation = Operation.NO_OPERATION;
                MessageBox.Show("Wrong input!");
            }

        }

        private void ComputeClick(object sender, RoutedEventArgs e)
        {
            if (operation == Operation.NO_OPERATION)
            {
                return;
            }

            string secondInputStr;
            if (txtInput.Text[txtInput.Text.Length - 1] == ')')
            {//its sin,log,cos,sqrt,log
                secondInputStr = txtInput.Text.Substring(inputIndex + 1, txtInput.Text.Length - inputIndex - 2);
            }
            else
            {
                secondInputStr = txtInput.Text.Substring(inputIndex);
            }
            inputIndex = 0;

            if (double.TryParse(secondInputStr, out secondInput))
            {
                switch (operation)
                {

                    case Operation.MINUS:
                        result = firstInput - secondInput;
                        break;
                    case Operation.PLUS:
                        result = firstInput + secondInput;
                        break;
                    case Operation.MULTIPLY:
                        result = firstInput * secondInput;
                        break;
                    case Operation.DIVIDE:
                        result = firstInput / secondInput;
                        break;
                    case Operation.EXP:
                        result = Math.Pow(firstInput, secondInput);
                        break;
                    case Operation.COS:
                        result = Math.Cos(secondInput);
                        break;
                    case Operation.SIN:
                        result = Math.Sin(secondInput);
                        break;
                    case Operation.LOG:
                        result = Math.Log(secondInput);
                        break;
                    case Operation.SQRT:
                        result = Math.Sqrt(secondInput);
                        break;
                }
                txtInput.Text = "" + result;
                firstInput = 0;
                secondInput = 0;
                operation = Operation.NO_OPERATION;
            }
            else
            {
                
                MessageBox.Show("Wrong input!");
            }
        }

        private void DigitClick(object sender, RoutedEventArgs e)
        {
            string btnTitle = (string)((Button)sender).Content;
            TypeDigit(btnTitle);
        }

        #endregion


        #region Memory operation

        private void MC_Click(object sender, RoutedEventArgs e)
        {
            memorySaved = 0;
        }

        private void MR_Click(object sender, RoutedEventArgs e)
        {
            TypeDigit(memorySaved.ToString());
        }

        private void MMinus_Click(object sender, RoutedEventArgs e)
        {
            double valueToAdd;

            if (double.TryParse(txtInput.Text, out valueToAdd))
            {
                memorySaved -= valueToAdd;
            }
            else
            {
                MessageBox.Show("Wrong value! Can not be added to memory.");
            }
        }
        private void MPlus_Click(object sender, RoutedEventArgs e)
        {
            double valueToExtract;

            if (double.TryParse(txtInput.Text, out valueToExtract))
            {
                memorySaved += valueToExtract;
            }
            else
            {
                MessageBox.Show("Wrong value! Can not be extracted from memory.");
            }
        }
        #endregion

        #endregion

        #region Utility methods
        private void TypeDigit(string digit)
        {
            if (txtInput.Text.Equals("0"))
            {
                txtInput.Text = digit;
            }
            else if (txtInput.Text[txtInput.Text.Length - 1] == ')')
            {//its sin,log,cos,sqrt,log
                string currentNum = txtInput.Text.Substring(inputIndex + 1, txtInput.Text.Length - inputIndex - 2);
                if (currentNum == "0")
                {
                    currentNum = digit;
                }
                else
                {
                    currentNum += digit;
                }
                txtInput.Text = txtInput.Text.Substring(0, inputIndex + 1) + currentNum + ')';
            }
            else
            {
                txtInput.Text += digit;
            }
        }

        #endregion


    }
}
