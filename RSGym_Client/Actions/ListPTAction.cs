using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{

    class ListPTAction : IBaseAction
    {

        #region Properties

        public char Code { get; set; }

        public string Name { get; set; }

        public IUser User { get; set; }

        public MenuType MenuType { get; set; }

        public bool Success { get; set; }

        #endregion

        #region Contructor

        public ListPTAction()
        {
            Code = '2';
            Name = "List Trainers";
            User = new GuestUser();
            MenuType = MenuType.Restricted;
        }

        #endregion

        #region Methods

        public void Execute(out bool isExit)
        {
            isExit = false;

            Console.Clear();
            Utils.PrintSubHeader("Lista de Personal Trainers disponíveis");

            List<Trainer> trainers = TrainerRepository.GetAllTrainers();
            trainers.ForEach(t => Console.WriteLine(t.ToString()));

            Console.WriteLine();

            Success = true;
        }

        #endregion

    }

}
