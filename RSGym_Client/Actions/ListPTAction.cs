using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSGym_Client
{

    class ListPTAction : IBaseAction, ICommunicable
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

        public ListPTAction()
        {
            Code = '2';
            Name = "List Trainers";
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
            Success = true;
            BuildFeedbackMessage();

            Console.Clear();
        }

        public void BuildFeedbackMessage(string previous = "", int current = 0)
        {
            var sb = new StringBuilder();

            if (Success)
            {
                List<Trainer> trainers = TrainerRepository.GetAllTrainers();

                sb.AppendLine(Utils.GetSimpleHeader("Lista de Personal Trainers disponíveis"));
                trainers.ForEach(t => sb.Append($"\n{t}"));
            }

            FeedbackMessage = sb.ToString();
        }

        #endregion

    }

}
