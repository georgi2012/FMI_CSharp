using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeSerives
{
    [Serializable]//dont forget!
    public class Product
    {

        public readonly string ID;
        private static uint NUMBER = 0;
        private Category productCategory;
        private int qty;
        private int reorderLevel;

        //ctors
        public Product(Category cat, int _qty, int reorLvl,string _ID="")
        {
            //with 4 leading zeros
            if (string.IsNullOrEmpty(_ID))
            {
                _ID=string.Format("P{0:D4}", NUMBER++);
            }
            ID = _ID;
            productCategory = cat;
            qty = _qty;
            reorderLevel = reorLvl;
        }
        public Product(Product other)
            : this(other.ProductCategory, other.Qty, other.ReorderLevel,other.ID){}
        public Product() : this(Category.INVALID, 0, 0, string.Format("P{0:D4}", NUMBER++)) { } //for serialization
        public Category ProductCategory
        {
            get
            {
                return productCategory;
            }
            set
            {
                productCategory = value;
            }
        }
        public int Qty
        {
            get
            {
                return qty;
            }
            set
            {
                qty = value >= 0 ? value : 0;
            }
        }
        public int ReorderLevel
        {
            get
            {
                return reorderLevel;
            }
            set
            {
                reorderLevel = value >= 0 ? value : 0;
            }
        }
       
        public override string ToString()
        {
            return string.Format($"PID:{ID}, Cat:{productCategory.ToString()}, Qty:{qty} ,Reorder at:{reorderLevel}");
        }

    }
}
