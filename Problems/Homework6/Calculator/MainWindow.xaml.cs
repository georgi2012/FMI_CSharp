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
        CalculatorOperations calculatorOperations;
        private double memorySaved;
        private int inputIndex;//helper to know where are we in the input
       
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            calculatorOperations = new CalculatorOperations();
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
                        calculatorOperations.Operation = CalculatorOperations.Operations.NO_OPERATION;
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
                    calculatorOperations.Operation = CalculatorOperations.Operations.NO_OPERATION;
                }
            }
            txtInput.Text = currentText.Remove(currentText.Length - 1, 1);

        }

        private void BtnCA_Click(object sender, RoutedEventArgs e)
        {
            calculatorOperations.FirstNum = calculatorOperations.SecondNum = inputIndex = 0;
            calculatorOperations.Operation = CalculatorOperations.Operations.NO_OPERATION;
            txtInput.Text = "0";
        }

        private void OperationForSingleParamClick(object sender, RoutedEventArgs e)
        {
            string content = ((string)((Button)sender).Content); ; //get name of element , symbow
            double firstInput;
            double.TryParse(txtInput.Text, out firstInput); // 0 if fails
            calculatorOperations.FirstNum = firstInput;

            switch (content)
            {
                case "SIN":
                    calculatorOperations.Operation = CalculatorOperations.Operations.SIN;
                    txtInput.Text = "Sin(" + firstInput + ')';
                    inputIndex = 3;
                    break;
                case "COS":
                    calculatorOperations.Operation = CalculatorOperations.Operations.COS;
                    txtInput.Text = "Cos(" + firstInput + ')';
                    inputIndex = 3;
                    break;
                case "SQRT":
                    calculatorOperations.Operation = CalculatorOperations.Operations.SQRT;
                    txtInput.Text = "Sqrt(" + firstInput + ')';
                    inputIndex = 4;
                    break;
                case "LOG":
                    calculatorOperations.Operation = CalculatorOperations.Operations.LOG;
                    txtInput.Text = "Log(" + firstInput + ')';
                    inputIndex = 3;
                    break;
                case "1/n":
                    txtInput.Text = "1/" + firstInput;
                    calculatorOperations.FirstNum = 1;
                    calculatorOperations.Operation = CalculatorOperations.Operations.DIVIDE;
                    inputIndex = 2;
                    break;

                default:
                    calculatorOperations.Operation = CalculatorOperations.Operations.NO_OPERATION;
                    break;
            }


        }

        private void OperationForTwoParamClick(object sender, RoutedEventArgs e)
        {
            string content = ((string)((Button)sender).Content); ; //get name of element , symbow
            double firstInput;
            if (double.TryParse(txtInput.Text, out firstInput))
            {//if try is true , inicial firstInput

                switch (content)
                {
                    case "+":
                        calculatorOperations.Operation = CalculatorOperations.Operations.PLUS;
                        break;
                    case "-":
                        calculatorOperations.Operation = CalculatorOperations.Operations.MINUS;
                        break;
                    case "*":
                        calculatorOperations.Operation = CalculatorOperations.Operations.MULTIPLY;
                        break;
                    case "/":
                        calculatorOperations.Operation = CalculatorOperations.Operations.DIVIDE;
                        break;
                    case "EXP":
                        calculatorOperations.Operation = CalculatorOperations.Operations.EXP;
                        content = "E";
                        break;

                    default:
                        calculatorOperations.Operation = CalculatorOperations.Operations.NO_OPERATION;
                        break;
                }
                txtInput.Text += content;
                inputIndex = txtInput.Text.Length; //set position for second input to start from
                calculatorOperations.FirstNum = firstInput;
            }
            else
            {
                calculatorOperations.Operation = CalculatorOperations.Operations.NO_OPERATION;
                MessageBox.Show("Wrong input!");
            }

        }

        private void ComputeClick(object sender, RoutedEventArgs e)
        {
            if (calculatorOperations.Operation == CalculatorOperations.Operations.NO_OPERATION)
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
            double secondInput;
            if (double.TryParse(secondInputStr, out secondInput))
            {
                calculatorOperations.SecondNum = secondInput;
                try
                {
                    if (secondInput == 0) throw new DivideByZeroException();
                    calculatorOperations.CalculateResult();
                    txtInput.Text = "" + calculatorOperations.Result;
                }
                catch(DivideByZeroException)
                {
                    txtInput.Text = "Zero division is not allowed!";
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("There is an invalid argument!");
                }
               
            }
            else
            {
                MessageBox.Show("There is an invalid argument!");
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
            else if (txtInput.Text.Length>0 && txtInput.Text[txtInput.Text.Length - 1] == ')')
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
