using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using TradeSerives;

namespace TradeSOAPService
{
  
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class TradeProducts : IOrderWService
    {
        private Dictionary<string, Product> products;
        //static object locker = new object();
        public TradeProducts()
        {
            const int startQty = 12;
            Random rng = new Random();
            int prodCount = rng.Next(6, 11);
            int maxCategories = Enum.GetNames(typeof(Category)).Length;
            products = new Dictionary<string, Product>(prodCount);
            for (int i = 0; i < prodCount; i++)
            {
                //making random product
                Category cat = (Category)rng.Next(1, maxCategories - 1);//0 invalid
                int lvl = rng.Next(6, 12);
                Product product = new Product(cat, startQty, lvl);
                //
                products[product.ID] = product;
            }
            //
            Thread thread = new Thread(CheckQty);
            thread.Start();
        }

        private void CheckQty()
        {
            Random rng = new Random();
            while (true)
            {
                foreach (var prod in products.Values)
                {
                    if (prod.Qty <= prod.ReorderLevel)
                    {
                        prod.Qty += rng.Next(prod.ReorderLevel, prod.ReorderLevel + 11);
                    }
                }
                Thread.Sleep(1000);
            }
        }
        public Product[] Retrieve()
        {
            lock (products) //thread-safety first!
            {
                Product[] prodArr = new Product[products.Count];
                int ind = 0;
                foreach (var prod in products.Values)
                {
                    prodArr[ind++] = new Product(prod);
                }
                return prodArr;
            }
        }

        public void Update(string sender, string productID, int qty)
        {
            lock (products) {
                const string fileName = "C:\\Test\\reorder.txt";
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
                using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
                {
                    writer.WriteLine(string.Format($"{sender}:{products[productID]},Wanted:{qty};"));
                }

            }
        }
    }
}
