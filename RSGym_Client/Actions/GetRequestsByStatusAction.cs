using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{
    class GetRequestsByStatusAction : IBaseAction, ICommunicable
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

        public GetRequestsByStatusAction()
        {
            Code = '2';
            Name = "Get request count grouped by status";
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
            Console.Clear();
            BuildFeedbackMessage();

            Console.WriteLine();
        }

        public void BuildFeedbackMessage(string previous = "", int current = 0)
        {
            var sb = new StringBuilder();

            if (Success)
            {
                var allRequests = RequestRepository.GetAllRequests();
                var groupedRequests = allRequests.GroupBy(r => r.Status).Select(x => new { Status = x.Key, Count = x.Count() }).ToList();
                int statusLength = groupedRequests.Max(r => r.Status.ToString().Length);

                Utils.PrintSubHeader("Lista de pedidos agrupados por estado");

                sb.AppendLine($"{"Status".PadRight(statusLength)} | Nº de pedidos");
                sb.AppendLine($"{new String('-', statusLength)}-+--------------");
                groupedRequests.ToList().ForEach(s => sb.AppendLine($"{s.Status.ToString().PadRight(statusLength)} | {s.Count}"));
                sb.AppendLine();
            }

            FeedbackMessage = sb.ToString();
        }

        #endregion

    }
}
