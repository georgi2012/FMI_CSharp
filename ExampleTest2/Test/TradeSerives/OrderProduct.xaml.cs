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

namespace TradeSerives
{
    /// <summary>
    /// Interaction logic for OrderProduct.xaml
    /// </summary>
    public partial class OrderProduct : UserControl
    {
        public class OrderEventArgs : EventArgs
        {
            private string prodID;
            private int qty;
            public OrderEventArgs(string id,int _qty)
            {
                qty = _qty;
                prodID = id;
            }
            public string ProductID
            {
                get
                {
                    return prodID;
                }
            }
            public int Quantity
            {
                get
                {
                    return qty;
                }
            }
        }
        public delegate void OrderEventHandler(object sender, OrderEventArgs e);
        public event OrderEventHandler OnOrder;
        public OrderProduct()
        {
            InitializeComponent();
        }

        public ComboBox ComboBoxProduct
        {
            get
            {
                return CmbBoxProduct;
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            TxtBoxQty.Text = "0";
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            int qty;
            if (!int.TryParse(TxtBoxQty.Text,out qty)){
                MessageBox.Show("Invalid Quantity number!");
                return;
            }
            if(CmbBoxProduct.SelectedItem == null)
            {
                MessageBox.Show("No item selected!");
                return;
            }
            OnOrder?.Invoke(this,new OrderEventArgs(((Product)CmbBoxProduct.SelectedItem).ID,qty));
        }
    }
}
