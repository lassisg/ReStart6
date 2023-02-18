using D00_Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace E03_Cars
{

    public class Car
    {

        #region Enums

        /*
            Enumeration best practices (https://docs.microsoft.com/en-us/dotnet/api/system.enum?view=net-6.0#constructors)

                * If you have not defined an enumeration member whose value is 0, consider creating a None enumerated constant.
                  By default, the memory used for the enumeration is initialized to zero by the common language runtime.
                  Consequently, if you do not define a constant whose value is zero, the enumeration will contain an illegal value
                  when it is created.

                * If there is an obvious default case that your application has to represent, consider using an enumerated constant 
                  whose value is zero to represent it. If there is no default case, consider using an enumerated constant whose value is
                  zero to specify the case that is not represented by any of the other enumerated constants.

                * Do not specify enumerated constants that are reserved for future use.

                * When you define a method or property that takes an enumerated constant as a value, consider validating the value.
                  The reason is that you can cast a numeric value to the enumeration type even if that numeric value is not defined in
                  the enumeration.
        */

        // Apesar de não precisar incluir a atribuição, porque já inicia no valor 0, incluí na mesma para ilustrar o uso de Enums

        public enum EnumMake
        {
            None = 0,
            Bolide = 1,
            Renault = 2,
            Ferrari = 3
        }

        public enum EnumModel
        {
            None = 0,
            NewBolide = 1,
            Megane = 2,
            Clio = 3,
            Captur = 4,
            F40 = 5,
            California = 6
        }

        public enum EnumColor
        {
            None = 0,
            Black = 1,
            Blue = 2,
            Red = 3,
            Silver = 4,
            White = 5,
            Yellow = 6
        }


        #endregion

        #region Properties

        public EnumMake Make { get; set; }
        public EnumModel Model { get; set; }
        public EnumColor Color { get; set; }
        public string License { get; set; }
        public string CubicCapacity { get; set; }
        public int Speed { get; set; }
        public DateTime RegistrationDate { get; set; }

        #endregion

        #region Constructors

        public Car()
        {
            // Atenção com nulos se for adicionar à BD
            Make = EnumMake.None;
            Model = EnumModel.None;
            Color = EnumColor.None;
            License = string.Empty;
            CubicCapacity = "";
            Speed = 0;
            RegistrationDate = DateTime.MinValue;

        }

        public Car(EnumColor color, string license, int speed, DateTime registrationDate)
        {

            Make = EnumMake.Bolide;
            Model = EnumModel.NewBolide;
            Color = color;
            License = license;
            CubicCapacity = "1000";
            Speed = speed;
            RegistrationDate = registrationDate;

        }

        public Car(EnumMake make, EnumModel model, EnumColor color, string matricula, string cilindrada, int velociadde, DateTime dataRegisto)
        {

            Make = make;
            Model = model;
            Color = color;
            License = matricula;
            CubicCapacity = cilindrada;
            Speed = velociadde;
            RegistrationDate = dataRegisto;

        }

        #endregion

        #region Methods

        internal static void ShowMenu(bool isValidOption, bool showFullMenu)
        {

            Dictionary<string, string> menuOptions = GetMenuOptions(showFullMenu);

            Utils4.PrintHeader("E06_Cars");

            if (!isValidOption)
            {

                Utils4.PrintHeader("Calculadora Simples");
                ShowWarning();

            }

            Utils4.PrintSubHeader("Escolha uma das opções abaixo.");

            foreach (KeyValuePair<string, string> item in menuOptions)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.Write($"\nOpção selecionada: ");

        }

        private static void ShowWarning()
        {

            Console.Write($"\n{new string('-', 8)}>");
            Console.Write($"{new string(' ', 8)}Por favor selecione uma opção válida{new string(' ', 8)}");
            Console.Write($"<{new string('-', 8)}\n");

        }

        private static Dictionary<string, string> GetMenuOptions(bool fullMenu = true)
        {
            Dictionary<string, string> menuOptions = new Dictionary<string, string>();

            menuOptions.Add("1", "Criar carro");
            if (fullMenu)
            {
                menuOptions.Add("2", "Parar");
                menuOptions.Add("3", "Acelerar");
                menuOptions.Add("4", "Desacelerar");
            }
            menuOptions.Add("x", "Sair");

            return menuOptions;
        }

        internal static string ReadSelectedOption()
        {
            return Console.ReadLine();
        }

        internal static bool ValidateOption(string selectedOption, bool fullMenu)
        {

            Dictionary<string, string> menuOptions = GetMenuOptions(fullMenu);

            if (menuOptions.ContainsKey(selectedOption))
            {
                return true;
            }

            return false;
        }

        internal void ExecuteAction(string action)
        {

            switch (action)
            {
                case "1":
                    CreateCar();
                    break;
                case "2":
                    Stop();
                    break;

                case"3":
                    Accelerate();
                    break;

                case"4":
                    Decelerate();
                    break;

                default:
                    break;

            }

            Console.ReadLine();

        }

        internal void CreateCar()
        {

            string inputValue;

            do
            {
                ShowMakeMenu();
                inputValue = Console.ReadLine();
                ValidateMake(inputValue);

            } while (Make == Car.EnumMake.None);

            do
            {
                ShowModelMenu();
                inputValue = Console.ReadLine();
                ValidateModel(inputValue);

            } while (Model == Car.EnumModel.None);

            {
                ShowColorMenu();
                inputValue = Console.ReadLine();
                ValidateColor(inputValue);

            } while (Color == Car.EnumColor.None) ;

            do
            {
                Console.Write("\nDigite a matrícula do carro: ");
                inputValue = Console.ReadLine();
                License = ValidateLicense(inputValue);

            } while (License == string.Empty);

            do
            {
                Console.Write("\nDigite a cilindrada do carro: ");
                inputValue = Console.ReadLine();
                CubicCapacity = ValidateCC(inputValue);

            } while (CubicCapacity == string.Empty);

            do
            {
                Console.Write("\nDigite a velocidade do carro: ");
                inputValue = Console.ReadLine();
                Speed = ValidateSpeed(inputValue);

            } while (Speed == 0);

            do
            {
                Console.Write("\nDigite a data de registo do carro no formato \'dd/mm/aaaa\': ");
                inputValue = Console.ReadLine();
                RegistrationDate = ValidateRegistrationDate(inputValue);

            } while (RegistrationDate == DateTime.MinValue);

        }

        internal void ShowMakeMenu()
        {

            Console.WriteLine("\nEscolha uma marca de carro:");

            var enumValues = Enum.GetValues(typeof(EnumMake));

            foreach (EnumMake item in enumValues)
            {
                if (item != EnumMake.None)
                {
                    Console.WriteLine($"{item:D} - {GetFriendlyMake(item)}");
                }
            }

        }

        internal string GetFriendlyMake(EnumMake currentItem)
        {

            string friendlyMake;

            switch (currentItem)
            {
                case EnumMake.Bolide:
                    friendlyMake = "Bólide";
                    break;

                case EnumMake.Renault:
                    friendlyMake = "Renault";
                    break;

                case EnumMake.Ferrari:
                    friendlyMake = "Ferrari";
                    break;

                default:
                    friendlyMake = string.Empty;
                    break;
            }

            return friendlyMake;
        }

        internal void ValidateMake(string userInput)
        {
            
            bool isNumeric = int.TryParse(userInput, out int userValue);
            bool isDefined = Enum.IsDefined(typeof(EnumMake), userValue);

            Make = (isNumeric && isDefined) ? (EnumMake)userValue : Make;

        }

        internal void ShowModelMenu()
        {

            Console.WriteLine("\nEscolha um modelo de carro");

            var enumValues = Enum.GetValues(typeof(EnumModel));

            foreach (EnumModel item in enumValues)
            {
                if (item != EnumModel.None)
                {
                    Console.WriteLine($"{item:D} - {GetFriendlyModel(item)}");
                }
            }

        }

        internal string GetFriendlyModel(EnumModel currentItem)
        {

            string friendlyModel;

            switch (currentItem)
            {
                case EnumModel.NewBolide:
                    friendlyModel = "Novo Bólide";
                    break;

                case EnumModel.Megane:
                    friendlyModel = "Mégane";
                    break;

                case EnumModel.Clio:
                    friendlyModel = "Clio";
                    break;

                case EnumModel.Captur:
                    friendlyModel = "Captur";
                    break;

                case EnumModel.F40:
                    friendlyModel = "F40";
                    break;

                case EnumModel.California:
                    friendlyModel = "Califórnia";
                    break;

                default:
                    friendlyModel = string.Empty;
                    break;
            }

            return friendlyModel;

        }

        internal void ValidateModel(string userInput)
        {
            
            bool isNumeric = int.TryParse(userInput, out int userValue);
            bool isDefined = Enum.IsDefined(typeof(EnumModel), userValue);

            Model = (isNumeric && isDefined) ? (EnumModel)userValue : Model;

        }

        internal void ShowColorMenu()
        {

            Console.WriteLine("\nEscolha uma cor");

            var enumValues = Enum.GetValues(typeof(EnumColor));

            foreach (EnumColor item in enumValues)
            {
                if (item != EnumColor.None)
                {
                    Console.WriteLine($"{item:D} - {GetFriendlyColor(item)}");
                }
            }

        }

        internal string GetFriendlyColor(EnumColor currentItem)
        {

            string friendlyColor;

            switch (currentItem)
            {
                case EnumColor.Black:
                    friendlyColor = "Preto";
                    break;

                case EnumColor.White:
                    friendlyColor = "Branco";
                    break;

                case EnumColor.Red:
                    friendlyColor = "Vermelho";
                    break;

                case EnumColor.Silver:
                    friendlyColor = "Cinzento";
                    break;

                case EnumColor.Yellow:
                    friendlyColor = "Amarelo";
                    break;

                case EnumColor.Blue:
                    friendlyColor = "Azul";
                    break;

                default:
                    friendlyColor = string.Empty;
                    break;
            }

            return friendlyColor;

        }

        internal void ValidateColor(string userInput)
        {

            bool isNumeric = int.TryParse(userInput, out int userValue);
            bool isDefined = Enum.IsDefined(typeof(EnumColor), userValue);

            Color = (isNumeric && isDefined) ? (EnumColor)userValue : Color;

        }

        internal string ValidateLicense(string userValue)
        {

            string newValue = userValue.Trim().ToUpper().Replace(" ", "-");

            Regex rx = new Regex(@"(\d{2}|[a-zA-Z]{2})[\-]?(\d{2}|[a-zA-Z]{2})[\-]?(\d{2}|[a-zA-Z]{2})",
              RegexOptions.Compiled | RegexOptions.IgnoreCase);

            Match match = rx.Match(newValue);

            if (!match.Success)
            {
                return License;
            }

            newValue = $"{match.Groups[1].Value}-{match.Groups[2].Value}-{match.Groups[3].Value}";

            return newValue;

        }

        internal string ValidateCC(string userInput)
        {

            int userValue;
            bool isNumeric = int.TryParse(userInput, out userValue);

            return (isNumeric) ? userInput : CubicCapacity;

        }

        internal int ValidateSpeed(string userInput)
        {
            int userValue;
            bool isNumeric = int.TryParse(userInput, out userValue);

            return (isNumeric) ? userValue : 0;

        }

        internal DateTime ValidateRegistrationDate(string userValue)
        {

            // 1. Data deve estar no formato válido
            bool isValidDate = DateTime.TryParse(userValue, out DateTime newDate);

            // 2. Data deve ser, no máximo, a data de hoje
            if (isValidDate)
            {
                isValidDate = (newDate <= DateTime.Now) ? true : false;
            }

            newDate = (isValidDate) ? newDate : RegistrationDate;

            return newDate;

        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.Append(GetFriendlyMake(Make));
            sb.Append(" / ");
            sb.Append(GetFriendlyModel(Model));
            sb.Append(", ");
            sb.Append(GetFriendlyColor(Color));
            sb.Append(", ");
            sb.Append(CubicCapacity);
            sb.Append(" cc, velocidade ");
            sb.Append(Speed);
            sb.Append(" km/h, registado em ");
            sb.Append(RegistrationDate);
            sb.Append(" com a matrícula ");
            sb.Append(License);
            sb.Append(".");

            return sb.ToString();

        }

        internal void Stop()
        {

            Speed = 0;
            Console.WriteLine("\nCarro parado...");

        }

        internal void Accelerate()
        {
            string inputSpeed = ReadSpeed();
            int speed = ValidateSpeed(inputSpeed);

            Console.Write($"\nA acelelrar de {Speed} para ");
            Speed += speed;
            Console.WriteLine($"{Speed}...");

        }

        internal void Decelerate()
        {
            string inputSpeed = ReadSpeed();
            int speed = ValidateSpeed(inputSpeed);

            Console.Write($"\nA desacelelrar de {Speed} para ");
            Speed -= speed;
            Console.WriteLine($"{Speed}...");

        }

        private string ReadSpeed()
        {
            Console.Write("Qual a velocidade a (des)acelerar? ");
            string userInput = Console.ReadLine();

            return userInput;
        }

        #endregion

        #region Destructor

        // Para ver a mansagem do destrutor, correr com Ctrl+F5

        ~Car()
        {

            Console.WriteLine("O carro vai para a sucata...");

        }

        #endregion

    }

}
