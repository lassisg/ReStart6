using RSGym_DAL;
using System;
using System.Linq;

namespace RSGym_Client
{
    class GetTopPTAction : IBaseAction
    {

        #region Properties

        public char Code { get; set; }

        public string Name { get; set; }

        public IUser User { get; set; }

        public MenuType MenuType { get; set; }

        public bool Success { get; set; }

        #endregion

        #region Contructor

        public GetTopPTAction()
        {
            Code = '4';
            Name = "Get trainer with most requests";
            User = new GuestUser();
            MenuType = MenuType.Statistical;
        }

        #endregion

        #region Methods

        public void Execute(out bool isExit)
        {
            isExit = false;

            var topPTRequest = TrainerRepository.GetTopTrainer();

            Success = true;

            Console.Clear();

            Utils.PrintSubHeader("Este PT é TOP!");

            if (topPTRequest.Count > 1)
            {
                Console.WriteLine("\nHouve um empate!");
                Console.WriteLine($"Cada um dos personal trainers abaixo conseguiu impressionantes {topPTRequest.First().Requests.Count()} pedidos!\n");
            }
            else
            {
                Console.Write($"\nO personal trainer mais requisitado, com {topPTRequest.First().Requests.Count()} pedidos em seu nome, é o ");
            }
            topPTRequest.ToList().ForEach(t => Console.WriteLine($"{t.ToString().Split('-')[1].Trim().Replace(":", " -")}"));

            Console.WriteLine();

        }

        #endregion

    }
}
