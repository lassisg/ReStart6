using System;
using System.Text;

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
            try
            {

                bool isNumeric = int.TryParse(userInput, out int userValue);
                bool isDefined = Enum.IsDefined(typeof(EnumMake), userValue);

                Make = (isNumeric && isDefined) ? (EnumMake)userValue : Make;

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

        }

        internal void ShowModelMenu()
        {

            Console.WriteLine("Escolha um modelo de carro");

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

            try {

                bool isNumeric = int.TryParse(userInput, out int userValue);
                bool isDefined = Enum.IsDefined(typeof(EnumModel), userValue);
                Model = (isNumeric && isDefined) ? (EnumModel)userValue : Model;

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

            try {

                bool isNumeric = int.TryParse(userInput, out int userValue);
                bool isDefined = Enum.IsDefined(typeof(EnumColor), userValue);

                Color = (isNumeric && isDefined) ? (EnumColor)userValue : Color;

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

        }

        internal string ValidateLicense(string userValue)
        {

            /*
                Matrículas válidas:
                * de 00-00-AA a 00-00-ZZ
                * de 00-AA-00 a 00-AA-ZZ
                * de AA-00-00 a AA-00-ZZ
                * de AA-AA-00 a AA-AA-ZZ
            
                Podem ser ignorados os separadoes.
                Podem ser utilizados espaços ' ' como separadores
                Exemplos de inputs:
                    * AA-00-01
                    * AB 52 BC
                    * Ac-26 09 (apesar de não haver padrão, aceitaremos este input
            */

            // Acho que seria melhor usar Regular Expressions (se eu soubesse como...)

            string newValue = userValue;

            try
            {

                // 1. Remove caracteres inválidos
                foreach (char c in newValue)
                {
                    if (!char.IsLetterOrDigit(c))
                    {
                        newValue = newValue.Remove(newValue.IndexOf(c), 1);
                    }
                }


                // 2. Verificar se restaram 6 caraceteres
                if (newValue.Length > 6)
                    throw new FormatException("Valor de entrada inválido.");

                // 3. Separa em partes de 2
                string[] licenseParts = new string[3];

                for (int i = 2; i <= newValue.Length; i += 2)
                {
                    licenseParts[(i / 2) - 1] = newValue.Substring(i - 2, 2);
                }

                // 4. Valida se cada parte possui apenas um tipo de dado: numérico ou caractere
                foreach (var item in licenseParts)
                {
                    if (!IsValidLicensePart(item))
                    {
                        throw new FormatException($"Valor de entrada inválido. Parte \'{item}\' não é válida!");
                    }
                }

                // 5. Unir os grupos com separador '-' entre eles
                newValue = string.Join("-", licenseParts);

                // 6. Padronizar com uso de Uppercase
                newValue = newValue.ToUpper();

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return License;
            }

            return newValue;

        }

        private bool IsValidLicensePart(string licencePart)
        {

            byte numericCount = 0;

            foreach (char c in licencePart)
            {
                if (char.IsNumber(c))
                {
                    numericCount += 1;
                }
            }

            bool result = (numericCount == 0 || numericCount == 2) ? true : false;

            return result;

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

            return (isNumeric) ? userValue : Speed;

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

        internal void Accelerate(int speed)
        {

            Console.Write($"\nA acelelrar de {Speed} para ");
            Speed += speed;
            Console.WriteLine($"{Speed}...");

        }

        internal void Decelerate(int speed)
        {

            Console.Write($"\nA desacelelrar de {Speed} para ");
            Speed -= speed;
            Console.WriteLine($"{Speed}...");

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
