using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculator
{
    public class CalculatorOperations
    {
        //fields
        private double firstNum;
        private double secondNum;
        private double result;
        public enum Operations
        {
            NO_OPERATION, PLUS, MINUS, DIVIDE, MULTIPLY,
            SIN, COS, LOG, EXP, SQRT
        };
        private Operations operation;
        //
        //ctors
        public CalculatorOperations(double first, double second, Operations oper)
        {
            firstNum = first;
            secondNum = second;
            operation = oper;
        }
        public CalculatorOperations()
            : this(0, 0,Operations.NO_OPERATION)
        { }
        public CalculatorOperations(CalculatorOperations other)
            : this(other.firstNum, other.secondNum,other.operation)
        { }

        //properties
        public double FirstNum
        {
            private get
            {
                return firstNum;
            }
            set
            {
                firstNum = value;
            }
        }
        public double SecondNum
        {
            private get
            {
                return secondNum;
            }
            set
            {
                secondNum = value;
            }
        }

        public double Result
        {
            get
            {
                return result;
            }
            private set
            {
                result = value;
            }
        }

        public Operations Operation
        {
            get
            {
                return operation;
            }
            set
            {
                operation = value;
            }
        }
        //
        public void CalculateResult()
        {
            result = CalculateFunction();
        }
        
        private double CalculateFunction()
        {
            switch (operation)
            {
                case Operations.NO_OPERATION:
                    throw new ArgumentException("No operation");
                case Operations.PLUS:
                    return firstNum + secondNum;
                case Operations.MINUS:
                    return firstNum - secondNum;
                case Operations.DIVIDE:
                    if(secondNum==0) throw new DivideByZeroException("second paramether is 0");
                    return firstNum / secondNum;//may throw
                case Operations.MULTIPLY:
                    return firstNum * secondNum;
                case Operations.SIN:
                    return Math.Sin(firstNum);
                case Operations.COS:
                    return Math.Cos(firstNum);
                case Operations.LOG:
                    return Math.Log10(firstNum);
                case Operations.EXP:
                    return Math.Pow(firstNum, secondNum);
                case Operations.SQRT:
                    return Math.Sqrt(firstNum);
                default:
                    throw new ArgumentException("No operation");
            }
            
        }



    }
}
