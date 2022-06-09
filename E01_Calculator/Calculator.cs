using D00_Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01_Calculator
{

    internal abstract class Calculator
    {

        #region Properties

        internal abstract double Result { get; set; }
        internal abstract double Value01 { get; set; }
        internal abstract double Value02 { get; set; }

        #endregion

        #region Contructors (Classe abstrata, não será instanciada. Logo, não deve ter construtores)

        //internal Calculator()
        //{
        //    Value01 = 0;
        //    Value02 = 0;
        //    Result = 0;
        //}

        //internal Calculator(double value01, double value02)
        //{
        //    Value01 = value01;
        //    Value02 = value02;
        //    Result = 0;
        //}

        #endregion

        #region Methods

        internal abstract void ShowMenu();
        
        internal abstract string ReadUserInput();

        internal abstract bool ValidateOption(string selectedOption);

        internal abstract void ReadNumbers(string inputString);

        internal abstract double ValidateNumber(string inputString);

        internal abstract void ExecuteOperation(string selectedOperation);

        internal abstract void ShowResult();

        internal abstract double Sum(double value01, double value02);
        
        internal abstract double Subtract(double value01, double value02);
        
        internal abstract double Multiply(double value01, double value02);
        
        internal abstract double Divide(double value01, double value02);

        internal abstract void WriteErrorMessage(string message);
        
        #endregion

    }

}
