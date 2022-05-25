using System;
using D00_Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E03_Cars
{

    internal class Program
    {

        static void Main(string[] args)
        {

            Utils.PrintHeader("E03_Cars");

            #region Variables

            Car myCar = new Car();

            #endregion

            #region Methods

            myCar.Create();

            Console.Clear();

            Console.WriteLine(myCar.ToString());

            Console.ReadLine();

            myCar.Accelerate(90);

            myCar.Decelerate(20.5);

            myCar.Stop();

            #endregion

            Utils.CleanConsole();

        }

    }

}
