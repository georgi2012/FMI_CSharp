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
using TradeSerives;
using static TradeSerives.OrderProduct;

namespace ProductClientApp
{
    
    public partial class OrderClients : Window
    {
        private OrderProduct orderProduct;//user control
        private ServiceReference1.OrderWServiceClient client;
    
        public OrderClients()
        {
            InitializeComponent();
            orderProduct = UCOrdPrd;
            Random random = new Random();
            this.Title = string.Format("Order client {0}", random.Next(1, 1000));
            // 
            client = new ServiceReference1.OrderWServiceClient();
            Dispatcher.Invoke(new Action(() =>
            {
                Product[] pr = client.Retrieve();
                orderProduct.ComboBoxProduct.ItemsSource = pr;
            }));
            orderProduct.OnOrder += OnUpdateRequest;
        }

        private void OnUpdateRequest(object sender, OrderEventArgs e)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                client.Update(this.Title,e.ProductID,e.Quantity);
            }));
        }
    }
}
