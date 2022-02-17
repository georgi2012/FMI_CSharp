using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zad2
{
    public class Invoice
    {
        #region Fields
            private string partDescrp;
            private string partNumber;
            private decimal pricePerItem;
            private double quant; 
        #endregion


        #region Properties
        public double Quant
        {
            get { return quant; }
            set { quant = value >= 0 ? value : 0; }

        }

        public string PartDescrp
        {
            get { return partDescrp; }
            set { partDescrp = value != null ? value : "Undef"; }
        }

        public string PartNumber
        {
            get { return partNumber; }
            set { partNumber = value != null ? value : "Undef"; }
        }

        public decimal PricePerItem
        {
            get { return pricePerItem; }
            set { pricePerItem = value > 0 ? value : 0; }
        } 
        #endregion


        public Invoice( string partDescrp,
        string partNumber,
        decimal pricePerItem,
        double quant )
        {


        }
    }
}