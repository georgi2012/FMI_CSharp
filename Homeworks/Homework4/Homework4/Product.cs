using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework4
{
    public class Product
    {
        #region Fields
        private static long cnt;
        public string ID;
        static private Random rnd = new Random();
        public List<int> WeeklyPurchases;
        // static private UInt32 counter;// used to make an unique ID
        static public List<Product> products;//stores the data for the products 
        #endregion

        #region Constructors
        //general purp constr
        public Product(string dsrp, Type cat, List<int> weeklyPurch, decimal price)
        {
            Description = dsrp;
            WeeklyPurchases = new List<int>(weeklyPurch);
            Category = cat;
            Price = price;
            Quarter = (YearlyQuarter)(rnd.Next(1, 5));
            ID = $"{Category}{cnt++:D6}";
        }

        #endregion

        #region Properties
        public Type Category
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        public decimal Price
        {
            get; set;
        }

        public YearlyQuarter Quarter
        {
            get; set;

        }
        #endregion


        #region Methods

        public static void GroupByCategoryCountDescending()
        {
            if (products == null)
            {
                Console.WriteLine("Error: Products can't be sorted. Products list is not set!");
                return;
            }
            var sortedByCat = products.GroupBy(prod => prod.Category);
            Console.WriteLine("Sorting by Caregory:");
            foreach (var item in sortedByCat)
            {
                Console.WriteLine($"Category group :{item.Key}");
                Console.WriteLine($"\tNumber of prducts in {item.Key}: {item.Count()}");
            }
        }

        public static void GroupByQtrAndProductPriceAvg()
        {
            if (products == null)
            {
                Console.WriteLine("Error: Products can't be sorted. Products list is not set!");
                return;
            }
            Console.WriteLine("Sorting by Group and product average:");
            var sortedByQuart = products.GroupBy(prod => prod.Quarter, item => item.Price).OrderBy(prod => prod.Key)
                .Select(item => new { item.Key, Avg = item.Average() });


            foreach (var item in sortedByQuart)
            {
                Console.WriteLine($"Quarter group :{item.Key}");
                Console.WriteLine($"\tAverage price per one: {item.Avg:C2}");
            }

        }

        public static void GroupByQtrCategoryWeeklySum()
        {
            /*
                declare a LINQ statement that groups products by Quarter and next by Category in each
                Quarter. The Quarter groups must be sorted in ascending order of the Quarter and the
                Category groups show the tuple of Description and the total sum of WeeklyPurchases
                for each Product in the respective Quarter/Category group... Evaluate the LINQ statement
                inside the method and run the method to test the execution. 
             */
            //quart -> cate -> (decr , weekly.Sum())
            Console.WriteLine("Sorting by Quarter and category with products sum of sales:");
            if (products == null)
            {
                Console.WriteLine("Error: Products can't be sorted. Products list is not set!");
                return;
            }


            var sorted = products.GroupBy(q => q.Quarter)
                .Select(grp => new
                {
                    quart = grp.Key,
                    items = grp.GroupBy(c => c.Category)
                .Select(grp2 => new { category = grp2.Key, descr = grp2.GroupBy(d => (d.Description, d.WeeklyPurchases.Sum())) })
                }).OrderBy(i=>i.quart);

            foreach (var quart in sorted)
            {
                Console.WriteLine("Quarter {0}", quart.quart);
                foreach (var cat in quart.items)
                {
                    Console.WriteLine("\tCategory {0}", cat.category);
                    foreach (var descr in cat.descr)
                    {
                        Console.WriteLine("\t\t({0},{1})", descr.Key.Description, descr.Key.Item2);
                    }

                }
            }


        }

        public static void GroupByQtrCategoryAndProducts()
        {
            /*to declare a LINQ statement that groups products by Quarter and next by Category in each
                Quarter. The Quarter groups must be sorted in ascending order of the Quarter and the
                Category groups in ascending order of the Category. Show all the products in each
                Category group sorted in ascending order of the Category using the ToString() method of
                class Product . Evaluate the LINQ statement inside the method and run the method to test
                the execution*/

            Console.WriteLine("Sorting by Quarter and category with ID:");
            if (products == null)
            {
                Console.WriteLine("Error: Products can't be sorted. Products list is not set!");
                return;
            }

            var sorted = products.GroupBy(q => q.Quarter)
                .Select(grp => new
                {
                    quart = grp.Key,
                    items = grp.GroupBy(c => c.Category)
                .Select(grp2 => new { category = grp2.Key, descr = grp2.GroupBy(d => d.ToString()) })
                }).OrderBy(i => i.quart);

            foreach (var quart in sorted)
            {
                Console.WriteLine("Quarter {0}", quart.quart);
                foreach (var cat in quart.items)
                {
                    Console.WriteLine("\tCategory {0}", cat.category);
                    foreach (var descr in cat.descr)
                    {
                        Console.WriteLine("\t\t{0}",descr.Key);
                    }

                }
            }
        }

        public static void GroupByQtrMinMaxPrice()
        {
            Console.WriteLine("Sorting by Quarter and showing Min , Max:");
            if (products == null)
            {
                Console.WriteLine("Error: Products can't be sorted. Products list is not set!");
                return;
            }

            var sorted = products.GroupBy(q => q.Quarter).Select(grp => new
            {
                quart = grp.Key,
                Min = grp.OrderBy(item => item.Price).First().Price,
                Max = grp.OrderBy(item => item.Price).Last().Price
            });

            foreach (var quart in sorted)
            {
                Console.WriteLine("Quarter {0}", quart.quart);
                Console.WriteLine("\tMin value:{0}",quart.Min);
                Console.WriteLine("\tMaw value:{0}", quart.Max);

            }
        }

        public override string ToString()
        {
            return $"ID:{ID}, Purchases:{string.Join(",",WeeklyPurchases)}";
        }
        #endregion
    }
}