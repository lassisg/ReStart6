using D00_Utils;
using System;

namespace E03_Cars
{

    internal class Program
    {

        static void Main(string[] args)
        {

            Utils.PrintHeader("E06_Cars");

            #region Variables

            Car myCar = new Car();

            #endregion

            #region Methods

            string inputValue;

            do
            {
                myCar.ShowMakeMenu();
                inputValue = Console.ReadLine();
                myCar.ValidateMake(inputValue);

            } while (myCar.Make == Car.EnumMake.None);

            do
            {
                myCar.ShowModelMenu();
                inputValue = Console.ReadLine();
                myCar.ValidateModel(inputValue);

            } while (myCar.Model == Car.EnumModel.None);

            {
                myCar.ShowColorMenu();
                inputValue = Console.ReadLine();
                myCar.ValidateColor(inputValue);

            } while (myCar.Color == Car.EnumColor.None) ;

            do
            {
                Console.Write("\nDigite a matrícula do carro: ");
                inputValue = Console.ReadLine();
                myCar.License = myCar.ValidateLicense(inputValue);

            } while (myCar.License == string.Empty);

            Console.Write("\nDigite a cilindrada do carro: ");
            inputValue = Console.ReadLine();
            myCar.CubicCapacity = myCar.ValidateCC(inputValue);

            Console.Write("\nDigite a velocidade do carro: ");
            inputValue = Console.ReadLine();
            myCar.Speed = myCar.ValidateSpeed(inputValue);

            do
            {
                Console.Write("\nDigite a data de registo do carro no formato \'dd/mm/aaaa\': ");
                inputValue = Console.ReadLine();
                myCar.RegistrationDate = myCar.ValidateRegistrationDate(inputValue);

            } while (myCar.RegistrationDate == DateTime.MinValue);

            Console.Clear();

            Console.WriteLine(myCar.ToString());

            Console.ReadLine();

            myCar.Accelerate(90);

            myCar.Decelerate(20);

            myCar.Stop();

            #endregion

            Utils.CleanConsole();

        }

    }

}
