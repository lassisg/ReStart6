using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{
    class FinishRequestAction : IBaseAction
    {

        #region Properties

        public char Code { get; set; }

        public string Name { get; set; }

        public IUser User { get; set; }

        public MenuType MenuType { get; set; }

        public bool Success { get; set; }

        #endregion

        #region Contructor

        public FinishRequestAction()
        {
            Code = '7';
            Name = "Finish request";
            User = new GuestUser();
            MenuType = MenuType.Restricted;
        }

        #endregion

        #region Methods

        public void Execute(out bool isExit)
        {
            isExit = false;

            //Console.Write("\nDigite o nome do PT: ");
            //string ptName = this.ReadUserInput();

            //var newTrainer = new Trainer
            //{
            //    Code = Trainer.GetNextCode(),
            //    Name = ptName
            //};

            //TrainerRepository.CreateTrainer(newTrainer);
            Success = true;

            Console.Clear();

            //var sb = new StringBuilder();
            //sb.AppendLine("Novo Personal Trainer adicionado:");
            //sb.AppendLine(newTrainer.ToString());

            //Communicator.WriteSuccessMessage(sb.ToString());
            Communicator.WriteSuccessMessage("ToDo: Finalizar pedido");
        }

        #endregion

    }
}
