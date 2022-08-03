using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{
    class AddPTAction : IBaseAction, ICommunicable
    {

        #region Properties

        public char Code { get; set; }

        public string Name { get; set; }

        public IUser User { get; set; }

        public MenuType MenuType { get; set; }

        public bool Success { get; set; }

        public string FeedbackMessage { get; set; }

        #endregion

        #region Contructor

        public AddPTAction()
        {
            Code = '1';
            Name = "Add Trainer";
            User = new GuestUser();
            MenuType = MenuType.Restricted;
            Success = false;
            FeedbackMessage = string.Empty;
        }

        #endregion

        #region Methods

        public void Execute(out bool isExit)
        {
            isExit = false;

            Console.Write("\nDigite o nome do PT: ");
            string ptName = this.ReadUserInput();

            var newTrainer = new Trainer
            {
                Code = Trainer.GetNextCode(),
                Name = ptName
            };

            TrainerRepository.CreateTrainer(newTrainer);

            Success = true;
            BuildFeedbackMessage(newTrainerID: newTrainer.TrainerID);

            Console.Clear();

        }

        public void BuildFeedbackMessage(string previousTrainer = "", int newTrainerID = 0)
        {
            var sb = new StringBuilder();

            if (Success)
            {
                var newTrainer = TrainerRepository.GetTrainerById(newTrainerID);
            
                sb.AppendLine("Novo Personal Trainer adicionado:");
                sb.AppendLine(newTrainer.ToString());
            }

            FeedbackMessage = sb.ToString();
        }

        #endregion

    }

}
