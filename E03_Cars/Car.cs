using System;
using System.ComponentModel;
using System.Text;

namespace E03_Cars
{

    internal class Car
    {

        #region Enums

        public enum Make
        {
            Bolide = 1,
            Renault = 2,
            Ferrari = 3
        }

        public enum Model
        {
            NewBolide = 1,
            Megane =2,
            Clio = 3,
            Captur = 4,
            F40 = 5,
            California = 6
        }

        public enum Color
        {
            Black = 1,
            Blue = 2,
            Red = 3,
            Silver = 4,
            White = 5,
            Yellow = 6
        }
        

        #endregion

        #region Properties

        public Make? CarMake { get; set; }
        public Model? CarModel { get; set; }
        public Color? CarColor { get; set; }
        public string License { get; set; }
        public int CubicCapacity { get; set; }
        public double Speed { get; set; }
        public DateTime? RegistrationDate { get; set; }

        #endregion

        #region Constructors

        public Car()
        {

            CarMake = null;
            CarModel = null;
            CarColor = null;
            License = string.Empty;
            CubicCapacity = 0;
            Speed = 0;
            RegistrationDate = null;

        }

        public Car (Make make, Model model, int cubicCapacity)
        {

            CarMake = make;
            CarModel = model;
            CarColor = null;
            License = string.Empty;
            CubicCapacity = cubicCapacity;
            Speed = 0;
            RegistrationDate = null;

        }

        public Car(Make make, Model model, Color color, string matricula, int cilindrada, double velociadde, DateTime dataRegisto)
        {

            CarMake = make;
            CarModel = model;
            CarColor = color;
            License = matricula;
            CubicCapacity = cilindrada;
            Speed = velociadde;
            RegistrationDate = dataRegisto;

        }

        #endregion

        #region Methods

        public void Create()
        {
            
            string inputValue;

            // TODO: Validate input values
            do
            {
                ShowMakeMenu();
                inputValue = Console.ReadLine();
                CarMake = ValidateMake(inputValue);

            } while (!CarMake.HasValue);

            ShowModelMenu();
            inputValue = Console.ReadLine();
            //CarModel = ValidateModel(inputValue);

            ShowColorMenu();
            inputValue = Console.ReadLine();
            //CarColor = ValidateColor(inputValue);

            Console.Write("\nDigite a matrícula do carro: ");
            inputValue = Console.ReadLine();
            //License = ValidateLicense(inputValue);

            Console.Write("\nDigite a cilindrada do carro: ");
            inputValue = Console.ReadLine();
            //CubicCapacity = ValidateCC(inputValue);

            Console.Write("\nDigite a velocidade atual do carro: ");
            inputValue = Console.ReadLine();
            //Speed = ValidateSpeed(inputValue);

            Console.Write("\nDigite a data de registo do carro: ");
            inputValue = Console.ReadLine();
            //RegistrationDate = ValidateRegistrationDate(inputValue);

        }

        private void ShowMakeMenu()
        {

            Console.Clear();

            Console.WriteLine("\nEscolha uma marca de carro:");

            var enumValues = Enum.GetValues(typeof(Make));
            
            foreach (Make item in enumValues)
            {
                Console.WriteLine($"{(int)item} - {GetFriendlyMake(item)}");
            }

        }

        private string GetFriendlyMake(Make currentItem)
        {

            string friendlyMake;

            switch (currentItem)
            {
                case Make.Bolide:
                    friendlyMake = "Bólide";
                    break;

                case Make.Renault:
                    friendlyMake = "Renault";
                    break;

                case Make.Ferrari:
                    friendlyMake = "Ferrari";
                    break;

                default:
                    friendlyMake = string.Empty;
                    break;
            }

            return friendlyMake;
        }

        private Make? ValidateMake(string userValue)
        {

            Make currentMake;

            if (Enum.TryParse(userValue, out currentMake))
            {
                return currentMake;
            }

            return null;

        }

        private void ShowModelMenu()
        {

            Console.Clear();

            Console.WriteLine("Escolha um modelo de carro");
            
            var enumValues = Enum.GetValues(typeof(Model));
            foreach (Model item in enumValues)
            {
                Console.WriteLine($"{(int)item} - {GetFriendlyModel(item)}");
            }

        }

        private string GetFriendlyModel(Model currentItem)
        {

            string friendlyModel;

            switch (currentItem)
            {
                case Model.NewBolide:
                    friendlyModel = "Novo Bólide";
                    break;

                case Model.Megane:
                    friendlyModel = "Mégane";
                    break;

                case Model.Clio:
                    friendlyModel = "Clio";
                    break;

                case Model.Captur:
                    friendlyModel = "Captur";
                    break;

                case Model.F40:
                    friendlyModel = "F40";
                    break;

                case Model.California:
                    friendlyModel = "Califórnia";
                    break;

                default:
                    friendlyModel = string.Empty;
                    break;
            }

            return friendlyModel;

        }

        private Model ValidateModel(string userValue)
        {

            Console.Clear();

            return Model.California;
        }

        private void ShowColorMenu()
        {

            Console.Clear();

            Console.WriteLine("\nEscolha uma cor");
            
            var enumValues = Enum.GetValues(typeof(Color));
            foreach (Color item in enumValues)
            {
                Console.WriteLine($"{(int)item} - {GetFriendlyColor(item)}");
            }

        }

        private string GetFriendlyColor(Color currentItem)
        {

            string friendlyColor;

            switch (currentItem)
            {
                case Color.Black:
                    friendlyColor = "Preto";
                    break;

                case Color.White:
                    friendlyColor = "Branco";
                    break;

                case Color.Red:
                    friendlyColor = "Vermelho";
                    break;

                case Color.Silver:
                    friendlyColor = "Cinzento";
                    break;

                case Color.Yellow:
                    friendlyColor = "Amarelo";
                    break;

                case Color.Blue:
                    friendlyColor = "Azul";
                    break;

                default:
                    friendlyColor = string.Empty;
                    break;
            }

            return friendlyColor;

        }

        private Color ValidateColor(string userValue)
        {
            return Color.Black;
        }

        private string ValidateLicense(string userValue)
        {
            return userValue;
        }

        private int ValidateCC(string userValue)
        {
            return Convert.ToInt16(userValue);
        }

        private double ValidateSpeed(string userValue)
        {
            return Convert.ToDouble(userValue);
        }

        private DateTime ValidateRegistrationDate(string userValue)
        {
            return Convert.ToDateTime(userValue);
        }

        public override string ToString()
        {

            // TODO: Adicionar mais informação e melhor formatação
            return "Carro criado!";

        }

        public void Stop()
        {
            
            Speed = 0;
            Console.WriteLine("\nCarro parado...");

        }

        public void Accelerate(double speed)
        {

            Console.Write($"\nA acelelrar de {Speed} para ");
            Speed += speed;
            Console.WriteLine($"{Speed}...");

        }
        
        public void Decelerate(double speed)
        {
            Console.Write($"\nA desacelelrar de {Speed} para ");
            Speed -= speed;
            Console.WriteLine($"{Speed}...");
        }

        #endregion

        #region Destructor

        ~Car()
        {

            Console.WriteLine("O carro vai para a sucata...");

        }

        #endregion

    }

}
