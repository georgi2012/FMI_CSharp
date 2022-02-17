using System;


namespace Homework1
{
    class TableTest
    {

        #region Constructors
        //default constr
        public TableTest() { }
        #endregion

        #region Methods
        public void GetFunctionValuesInInterval(double intervalStart, double intervalEnd, double intervalStep)
        {//creates objec and calls MakeTable ,validation
            //can create different tables

            if(intervalStep < 0)
            {
                Console.WriteLine("Error:Invalid Step value. Step value should not be a negative number.");
                return;
            }

            classTable tableObj = null;

            if (intervalStart > intervalEnd)
            {
                if (intervalStart > intervalEnd)
                {
                    double swapHelper = intervalStart;
                    intervalStart = intervalEnd;
                    intervalEnd = swapHelper;
                }
            }

            tableObj = new classTable(intervalStart, intervalEnd, intervalStep);
            tableObj.MakeTable();
        }

        #endregion
    }
}
