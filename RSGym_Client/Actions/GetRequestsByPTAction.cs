using RSGym_DAL;
using System;
using System.Linq;
using System.Text;

namespace RSGym_Client
{
    class GetRequestsByPTAction : IBaseAction, ICommunicable
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

        public GetRequestsByPTAction()
        {
            Code = '3';
            Name = "Get request count grouped by trainer";
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
            {
                var allRequests = RequestRepository.GetAllRequests();
                var groupedRequests = allRequests.GroupBy(r => r.Trainer).Select(x => new { Trainer = x.Key, Count = x.Count() }).ToList();
                int trainerLength = groupedRequests.Max(g => g.Trainer.ToString().Split('-')[1].Length);

                // ToDo: Move to ShowFeedbackMessage
                Utils.PrintSubHeader("Lista de pedidos agrupados por PT");

                sb.AppendLine($"\n{"Personal trainer".PadRight(trainerLength)} | Nº de pedidos");
                sb.AppendLine($"{new String('-', trainerLength)}-+--------------");
                groupedRequests.ToList().ForEach(g => sb.AppendLine($"{g.Trainer.ToString().Split('-')[1].Trim().Replace(":", " -").PadRight(trainerLength)} | {g.Count}"));
                sb.AppendLine();
            }

            FeedbackMessage = sb.ToString();
        }

        #endregion

    }
}
