using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Product.products = new List<Product>
            {
                  new Product("Electric sander", (Type)'M', new List<int>{99, 82, 81, 79 } ,157.98M),
                  new Product("Power saw", (Type)'M', new List<int>{ 93, 92, 80, 87 } ,99.99M),
                  new Product("Sledge hammer", (Type)'F', new List<int>{ 93, 92, 80, 87 } ,21.50M),
                  new Product("Hammer", (Type)'M', new List<int>{ 97, 89, 85, 82 } ,11.99M),
                  new Product("Lawn mower", (Type)'F', new List<int>{ 35, 72, 91, 70 } ,139.50M ),
                  new Product("Screwdriver", (Type)'F', new List<int>{ 88, 94, 65, 91 } ,56.99M),
                  new Product("Jig saw", (Type)'M', new List<int>{ 75, 84, 91, 39 } , 11.00M),
                  new Product("Wrench", (Type)'F', new List<int>{ 97, 92, 81, 60 } ,17.50M),
                  new Product("Sledge hammer", (Type)'M', new List<int>{ 75, 84, 91, 39 } ,21.50M),
                  new Product("Hammer", (Type)'F', new List<int>{ 94, 92, 91, 91 } ,11.99M  ),
                  new Product("Lawn mower", (Type)'M', new List<int>{ 96, 85, 91, 60 } ,179.50M),
                  new Product("Screwdriver", (Type)'M', new List<int>{ 96, 85, 51, 30 } ,66.99M)
            };

            Product.GroupByCategoryCountDescending();
            Console.WriteLine("--------------------------------------------------");
            Product.GroupByQtrAndProductPriceAvg();
            Console.WriteLine("--------------------------------------------------");
            Product.GroupByQtrCategoryWeeklySum();
            Console.WriteLine("--------------------------------------------------");
            Product.GroupByQtrCategoryAndProducts();
            Console.WriteLine("--------------------------------------------------");
            Product.GroupByQtrMinMaxPrice();
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
