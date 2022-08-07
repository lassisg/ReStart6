using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSGym_Client
{
    class ListRequestAction : IBaseAction, ICommunicable
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

        public ListRequestAction()
        {
            Code = '9';
            Name = "List all requests";
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

            List<Request> requests = RequestRepository.GetRequestsByUserID(this.User.UserID);

            Success = requests.Count > 0;
            BuildFeedbackMessage();

            Console.Clear();
        }

        public void BuildFeedbackMessage(string previous = "", int current = 0)
        {
            var sb = new StringBuilder();

            if (Success)
            {
                List<Request> requests = RequestRepository.GetRequestsByUserID(this.User.UserID);
                string requestHeader = requests.GetRequestHeader(out int trainerLength, out int statusLength, out int messageLength);

                sb.AppendLine(Utils.GetSimpleHeader("Lista de pedidos realizados"));
                sb.Append(requestHeader);
                requests.ForEach(r => sb.Append($"\n{r.ToString(trainerLength, statusLength, messageLength)}"));
            }
            else
            {
                sb.Append("Não há pedidos para mostrar.");
            }

            FeedbackMessage = sb.ToString();
        }

        #endregion

    }
}
