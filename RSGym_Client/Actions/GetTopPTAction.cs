using RSGym_DAL;
using System;
using System.Linq;
using System.Text;

namespace RSGym_Client
{
    class GetTopPTAction : IBaseAction, ICommunicable
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

        public GetTopPTAction()
        {
            Code = '4';
            Name = "Get trainer with most requests";
            User = new GuestUser();
            MenuType = MenuType.Statistical;
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
            {// ToDo: Test Top PT
                var allTrainers = TrainerRepository.GetAllTrainers();
                int maxRequests = allTrainers.Max(o => o.Requests.Count());
                var topRequestPT = allTrainers.Where(f => f.Requests.Count() == maxRequests).ToList();

                Utils.PrintSubHeader("Este PT é TOP!");
                sb.AppendLine();
                if (topRequestPT.Count > 1)
                {
                    sb.AppendLine("Houve um empate!");
                    sb.AppendLine($"Cada um dos personal trainers abaixo conseguiu impressionantes {topRequestPT.First().Requests.Count()} pedidos!\n");
                }
                else
                {
                    sb.AppendLine($"O personal trainer mais requisitado, com {topRequestPT.First().Requests.Count()} pedidos em seu nome, é o ");
                }
                topRequestPT.ToList().ForEach(t => sb.AppendLine($"{t.ToString().Split('-')[1].Trim().Replace(":", " -")}"));

                sb.AppendLine();
            }

            FeedbackMessage = sb.ToString();
        }

        #endregion

    }
}
