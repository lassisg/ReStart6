using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{
    class GetTotalUserRequestsAction : IBaseAction, ICommunicable
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

        public GetTotalUserRequestsAction()
        {
            Code = '1';
            Name = "Get request count for current user";
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
                var requests = RequestRepository.GetRequestsByUserID(this.User.UserID).Count();

                sb.AppendLine(Utils.GetSimpleHeader("Total de pedidos realizados"));
                sb.Append($"\nO total de pedidos em seu nome é: {requests}");
            }

            FeedbackMessage = sb.ToString();
        }

        #endregion

    }
}
