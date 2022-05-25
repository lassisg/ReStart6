using D00_Utils;
using System;
using System.Collections.Generic;

namespace E03_Cars
{

    internal class Program
    {

        static void Main(string[] args)
        {


            #region Variables

            List<Car> cars = new List<Car>();
            string selectedOption = "";
            bool validOption = true;

            #endregion

            #region Methods
            try
            {

                // TODO: Adicionar loop para adicionar carro ou acelerar, desacelerar e parar
                do
                {
                    
                    if (selectedOption != "x")
                    {

                        Car.ShowMenu(validOption, cars.Count > 0);
                        
                        selectedOption = Car.ReadSelectedOption();

                        if (selectedOption != "x")
                        {

                            validOption = Car.ValidateOption(selectedOption, cars.Count > 0);

                            // 4. Execute selection (if valid selection)
                            Console.WriteLine("Execute something");

                        }
                    }

                } while (selectedOption != "x" );

                Console.WriteLine("Exited menu.");

                //Car myCar = new Car();
                //myCar.CreateCar();

                //Console.Clear();

                //Console.WriteLine(myCar.ToString());

                //Console.ReadLine();

                //myCar.Accelerate(90);

                //myCar.Decelerate(20);

                //myCar.Stop();

            }
            catch (FormatException)
            {
                Console.WriteLine("\nHouve um erro na conversão do valor informado.");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro desconhecido:");
                Console.WriteLine(e.Message);
            }

            #endregion

            Utils.CleanConsole();

        }

    }

}
