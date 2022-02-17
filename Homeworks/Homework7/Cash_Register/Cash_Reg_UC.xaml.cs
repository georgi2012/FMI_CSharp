using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Cash_Register
{
    /// <summary>
    /// Interaction logic for Cash_Reg_UC.xaml
    /// </summary>
    public partial class Cash_Reg_UC : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        double subtotal;
        double tax;
        double total;

        public double Subtotal
        {
            get
            {
                return subtotal;
            }
            private set
            {
                subtotal = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            }
        }
        public double Tax
        {
            get
            {
                return tax;
            }
            private set
            {
                tax = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            }
        }
        public double Total
        {
            get
            {
                return total;
            }
            private set
            {
                total = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            }
        }

        public Cash_Reg_UC()
        {
            subtotal = tax = total = 0;
            InitializeComponent();
            DataContext = this;
        }

        public void OnAddCharToText(object sender, RoutedEventArgs e)
        {
            string btnTitle = (string)((Button)sender).Content;
            txtBox_Input.Text = txtBox_Input.Text.Equals("0") ? btnTitle : txtBox_Input.Text + btnTitle;
        }
        public void OnEnter(object sender, RoutedEventArgs e)
        {
            string input = txtBox_Input.Text;
            double value;
            if (Double.TryParse(input, out value))
            {
                if (value < 0)
                {
                    Tax = tax - value;
                }
                else
                {
                    Subtotal = subtotal + value;
                }
                txtBox_Input.Text = "0";
            }
            else
            {
                MessageBox.Show("Invalid number entered!");
            }
        }
        public void OnClear(object sender, RoutedEventArgs e)
        {
            Total = Tax = Subtotal = 0;
            txtBox_Input.Text = "0";
        }
        public void OnTotal(object sender, RoutedEventArgs e)
        {
            Total = subtotal - tax;
        }
        public void OnDelete(object sender, RoutedEventArgs e)
        {
            txtBox_Input.Text = "0";
        }
    }
}
