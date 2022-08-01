using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{
    class GetRequestsByPTAction : IBaseAction
    {

        #region Properties

        public char Code { get; set; }

        public string Name { get; set; }

        public IUser User { get; set; }

        public MenuType MenuType { get; set; }

        public bool Success { get; set; }

        #endregion

        #region Contructor

        public GetRequestsByPTAction()
        {
            Code = '3';
            Name = "Get request count grouped by trainer";
            User = new GuestUser();
            MenuType = MenuType.Statistical;
        }

        #endregion

        #region Methods

        public void Execute(out bool isExit)
        {
            isExit = false;

            var requests = RequestRepository.GetRequestsByTrainer();

            Success = true;

            Console.Clear();

            Utils.PrintSubHeader("Lista de pedidos agrupados por PT");
            int trainerLength = requests.ToList().Select(r => TrainerRepository.GetTrainerById(r.Key).ToString().Split('-')[1].Length).Max();

            Console.WriteLine($"\n{"Personal trainer".PadRight(trainerLength)} | Nº de pedidos");
            Console.WriteLine($"{new String('-', trainerLength)}-+--------------");
            requests.ToList().ForEach(s => Console.WriteLine($"{TrainerRepository.GetTrainerById(s.Key).ToString().Split('-')[1].Trim().Replace(":", " -").PadRight(trainerLength)} | {s.Value}"));
            
            Console.WriteLine();

        }

        #endregion

    }
}
