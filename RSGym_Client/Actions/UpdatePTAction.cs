using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{
    class UpdatePTAction : IBaseAction
    {

        #region Properties

        public char Code { get; set; }

        public string Name { get; set; }

        public IUser User { get; set; }

        public MenuType MenuType { get; set; }

        public bool Success { get; set; }

        #endregion

        #region Contructor

        public UpdatePTAction()
        {
            Code = '3';
            Name = "Update Trainer";
            User = new GuestUser();
            MenuType = MenuType.Restricted;
        }

        #endregion

        #region Methods

        public void Execute(out bool isExit)
        {
            isExit = false;

            var trainers = TrainerRepository.GetAllTrainers();

            Console.WriteLine("\nQual dos PTs deseja alterar?");
            trainers.ForEach(t => Console.WriteLine(t.ToString()));

            Console.Write("\nOpção selecionada: ");
            string trainerID = this.ReadUserInput();

            var trainer = trainers.Where(t => t.TrainerID == int.Parse(trainerID)).Single();

            Console.Write($"\nDigite o novo nome para o PT '{trainer.Name}': ");
            string trainerName = this.ReadUserInput();

            string previousName = trainer.Name;
            trainer.Name = trainerName;

            TrainerRepository.UpdateTrainer(trainer);

            Success = true;

            Console.Clear();

            var sb = new StringBuilder();
            sb.Append("O nome do Personal Trainer foi editado: ");
            sb.Append($"'{previousName}' --> '{trainer.Name}'");

            Communicator.WriteSuccessMessage(sb.ToString());
        }

        #endregion

    }
}
