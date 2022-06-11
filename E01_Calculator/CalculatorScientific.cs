using System;

namespace E01_Calculator
{

    internal class CalculatorScientific : Calculator
    {

        #region Properties

        internal override double Value01 { get; set; }
        internal override double Value02 { get; set; }
        internal override double Result { get; set; }

        #endregion

        #region Constructors

        internal CalculatorScientific()
        {
            Value01 = 0;
            Value02 = 0;
            Result = 0;
        }

        internal CalculatorScientific(double value01, double value02)
        {
            Value01 = value01;
            Value02 = value02;
            Result = 0;
        }

        #endregion

        #region Methods

        internal override double Sum(double value01, double value02)
        {

            Result = value01 + value02;
            return Result;

        }

        internal override double Subtract(double value01, double value02)
        {

            Result = value01 - value02;
            return Result;

        }

        internal override double Multiply(double value01, double value02)
        {

            Result = value01 * value02;
            return Result;

        }

        internal override double Divide(double value01, double value02)
        {

            Result = value01 / value02;
            return Result;

        }

        internal double GetSquareRoot(double inputNUmber)
        { 
            Result = Math.Sqrt(inputNUmber); 
            return Result;
        }

        internal static int GetDivisionMod(int dividend, int divisor)
        { 

            Math.DivRem(dividend, divisor, out int result);
            return result;

        }

        #endregion

    }

}
