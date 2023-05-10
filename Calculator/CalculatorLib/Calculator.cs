using System.Collections.Generic;
using System.Linq.Expressions;

namespace CalculatorLib
{
    public class Calculator
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }

        public int ADD() => Num1 + Num2;

        public int Divide()
        {
            if(Num2 == 0)
            {
                throw new DivideByZeroException("Cannot Divide By Zero");
            }
            else
            {
                return Num1 / Num2;
            }
        }

        public int Multiply() => Num1 * Num2;

        public int Subtract() => Num1 - Num2;

        public int SumOfNumbersDivisibleBy2(List<int> list)
        {
            int x = 0;
            foreach(int element in list)
            {
                if (element % 2 == 0)
                {
                    x += element;
                }
            }
            return x;
        }
    }
}