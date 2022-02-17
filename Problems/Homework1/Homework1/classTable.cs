using System;


namespace Homework1
{
    public class classTable
    {
        #region Fields

        double startParam;
        double finalParam;
        double step;

        #endregion

        #region Properties

        public double StartParam
        {
            get { return startParam; }
            set { startParam = value; }
            //there is no invalid number
        }

        public double FinalParam
        {
            get { return finalParam; }
            set { finalParam = value; }
            //all numbers are valid
        }

        public double Step
        {
            get { return step; }
            set { step = value; }
            //all numbers are valid
        }
        #endregion

        #region Constructors
        //general
        public classTable(double start, double end, double step)
        {
            StartParam = start;
            FinalParam = end;
            Step = step;
        }

        //def
        public classTable()
        {
            StartParam = 0d;
            FinalParam = 1d;
            Step = 0.05d;
        }

        #endregion

        #region Methods
        private double CaculateFunction(double x)
        {//helper for MakeTable()
            return (Math.Abs(x - 2) * Math.Abs(x - 2)) / (x * x + 1);
        }
        public void MakeTable()
        {//calculates and prints the value of the function

            double currentStartPosition = startParam;
            int numOfValues = step == 0 ? 1 : (int)(Math.Abs(finalParam - startParam) / step + 1); //+1 because we forget the finalParam , works for negative numbers
            bool keepPrinting = true;

            do
            {
                Console.WriteLine("{0,20}{1,20}", "Value of X", "Value of f(x)");
                for (int i = 0; i < (numOfValues >= 20 ? 20 : numOfValues); i++)
                {
                    Console.WriteLine("{0,20:0.0000}{1,20:0.0000}", currentStartPosition, CaculateFunction(currentStartPosition));

                    currentStartPosition += step; //take one step
                }

                numOfValues -= 20;
                if (numOfValues > 0)
                {
                    Console.WriteLine("Press return to continue …\n");
                    ConsoleKeyInfo key = Console.ReadKey();

                    keepPrinting = true;//if we use Enter/Return we will continue
                    while (key.Key != ConsoleKey.Enter)
                    {//wait for enter or ESC
                        if (key.Key == ConsoleKey.Escape)
                        {
                            keepPrinting = false;
                            Console.WriteLine("Exiting program.");
                            break; //enable to be able to exit if dont want to continue with ESC
                        }
                        key = Console.ReadKey();
                    }
                }
                else
                {//we ran out of values
                    Console.WriteLine("There are no more values to be printed");
                    keepPrinting = false;
                }


            } while (keepPrinting);
        }
        #endregion

    }
}