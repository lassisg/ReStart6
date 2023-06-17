using RSGym_DAL;
using System;
using System.Linq;
using System.Text;

namespace RSGym_Client
{
    class UpdatePTAction : IBaseAction, ICommunicable
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

        public UpdatePTAction()
        {
            Code = '3';
            Name = "Update Trainer";
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

            var trainers = TrainerRepository.GetAllTrainers();

            Console.WriteLine("\nQual dos PTs deseja alterar?");
            trainers.ForEach(t => Console.WriteLine(t.ToString()));

            Console.Write("\nOpção selecionada: ");
            string userInput = this.ReadUserInput();

            _ = int.TryParse(userInput, out int trainerID);

            var trainer = trainers.Where(t => t.TrainerID == trainerID).FirstOrDefault();
            string previousName = string.Empty;

            if (trainer != null)
            {
                Console.Write($"\nDigite o novo nome para o PT '{trainer.Name}': ");
                string trainerName = this.ReadUserInput();

                previousName = trainer.Name;
                trainer.Name = trainerName;

                TrainerRepository.UpdateTrainer(trainer);
            }

            Success = !(trainer is null);
            
            BuildFeedbackMessage(previousName, trainerID);

            Console.Clear();
        }

        public void BuildFeedbackMessage(string previousName = "", int newTrainerID = 0)
        {
            var sb = new StringBuilder();

            if (Success)
            {
                var newTrainer = TrainerRepository.GetTrainerById(newTrainerID);

                sb.AppendLine("O nome do Personal Trainer foi editado: ");
                sb.Append($"'{previousName}' --> '{newTrainer.Name}'");
            }
            else
            {
                sb.Append("Selecione uma opção válida.");
            }

            FeedbackMessage = sb.ToString();
        }

        #endregion

    }
}
