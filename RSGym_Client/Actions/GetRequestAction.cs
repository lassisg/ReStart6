using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{
    class GetRequestAction : IBaseAction, ICommunicable
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

        public GetRequestAction()
        {
            Code = '5';
            Name = "Get request";
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

            // ToDo: Add validation
            Console.Write("\nDigite o nº do pedido que deseja consultar: ");
            string inputID = this.ReadUserInput();

            _ = int.TryParse(inputID, out int requestID);

            var request = RequestRepository.GetRequestById(requestID);

            Success = !(request is null);

            BuildFeedbackMessage(requestID: requestID);

            Console.Clear();
        }

        public void BuildFeedbackMessage(string previous = "", int requestID = 0)
        {
            var sb = new StringBuilder();

            if (Success)
            {
                var request = RequestRepository.GetRequestById(requestID);
                Utils.PrintSubHeader($"Informações sobre o pedido nº {requestID}");

                List<Request> requests = new List<Request>
                {
                    request
                };

                string requestHeader = requests.GetHeader(out int trainerLength, out int statusLength, out int messageLength);

                sb.AppendLine(requestHeader);
                requests.ForEach(r => sb.AppendLine(r.ToString(trainerLength, statusLength, messageLength)));

                sb.AppendLine();
            }

            FeedbackMessage = sb.ToString();
        }

        #endregion

    }
}
