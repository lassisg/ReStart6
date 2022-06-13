using System;

namespace E01_Calculator
{

    internal class CalculatorStandard : Calculator
    {

        #region Properties

        internal override double Result { get; set; }
        internal override double Value01 { get; set; }
        internal override double Value02 { get; set; }
        internal double Value03 { get; set; }

        #endregion

        #region Constructors

        internal CalculatorStandard()
        {
            Value01 = 0;
            Value02 = 0;
            Value03 = 0;
            Result = 0;
        }

        internal CalculatorStandard(double value01, double value02)
        {
            Value01 = value01;
            Value02 = value02;
            Value03 = 0;
            Result = 0;
        }

        internal CalculatorStandard(double value01, double value02, double value03)
        {
            Value01 = value01;
            Value02 = value02;
            Value03 = value03;
            Result = 0;
        }

        #endregion

        #region Methods

        internal override double Sum(double value01, double value02) 
        {

            Result = value01 + value02;
            return Result;

        }

        internal double Sum(double value01, double value02, double value03) 
        {

            Result = value01 + value02 + value03;
            return Result;

        }

        internal override double Divide(double value01, double value02) 
        {

            Result = value01 / value02;
            return Result;

        }

        internal override double Multiply(double value01, double value02) 
        {

            Result = value01 * value02;
            return Result;

        }

        internal override double Subtract(double value01, double value02) 
        {

            Result = value01 - value02;
            return Result;

        }

        internal static double RoundTo(double inputValue, int precision)
        {

            double result = Math.Round(inputValue, precision);
            return result;

        }

        #endregion

    }

}
