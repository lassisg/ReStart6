using D00_Utils;
using E03_Cars;

#region Variables

List<Car> cars = new List<Car>();
Car myCar = new Car();
bool validOption = true;

#endregion

#region Methods

try
{
    string selectedOption;

    do
    {
        Car.ShowMenu(validOption, cars.Count > 0);

        selectedOption = Car.ReadSelectedOption();

        if (selectedOption.ToLower() != "x")
        {
            validOption = Car.ValidateOption(selectedOption, cars.Count > 0);

            if (validOption)
            {
                myCar.ExecuteAction(selectedOption);
                if (cars.Count == 0)
                    cars.Add(myCar);
            }

        }

    } while (selectedOption.ToLower() != "x");

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