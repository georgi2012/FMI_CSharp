using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week2
{
    public class Account
    {
       
        #region Fields 
        //ctrl+k+s->region
        private long id;
        private decimal balance;
        private DateTime dateCreated;
        #endregion

        #region Constructors
        //general con
        public Account(long id, decimal balance,
        DateTime dateCreated, double interestRate)
        {
            Id = id;
            Balance = balance;
            DateCreated = dateCreated;
            InterestRate = interestRate;

        }

        //def con
        public Account()
        {
            Id = 0;
            Balance = 0;
            DateCreated = DateTime.Now;
            InterestRate = 0.01;
        }

        //copy
        public Account(Account account)
        {
            Id = account.id;
            Balance = account.balance;
            DateCreated = account.dateCreated;
            InterestRate = account.InterestRate;
        }

        #endregion

        #region Properties
        public DateTime DateCreated
        {
            get
            {
                return dateCreated;
            }
            set
            {
                dateCreated = value != null ? value : DateTime.Now;
                //ask for null if sumilar type
            }
        }



        public int MyProperty
        { get; set; }
        public long Id
        {
            get { return id; }
            set { id = value > 0 ? value : 1; }

        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value >= 0 ? value : 0; }
        }

        public double InterestRate
        {
            get;
            set;


        }
        #endregion

        #region UtilityMethods

        public void WithDraw(decimal amount)
        {
            if (amount > 0 || amount > balance)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Account: error.Invalid amount.");
            }
        }

        public void Deosit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
            {
                Console.WriteLine("Account: error.Invalid amount.");
            }
        }
        #endregion

        public override string ToString()
        {
            return string.Format($"Account: AnnualInterest {InterestRate:F4}, " +
                $"Balance: {balance:C}\nDate created: {dateCreated:M}\n");
        }

    }
}