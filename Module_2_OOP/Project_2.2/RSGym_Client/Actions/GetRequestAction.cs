﻿using RSGym_DAL;
using System;
using System.Linq;
using System.Text;

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

            bool hasRequests =RequestRepository.GetRequestsByUserID(this.User.UserID).Any();
            if (!hasRequests)
                throw new ApplicationException("Não há pedidos para consultar.");

            Console.Write("\nDigite o nº do pedido que deseja consultar: ");
            string inputID = this.ReadUserInput();

            _ = int.TryParse(inputID, out int requestID);

            var request = RequestRepository
                .GetRequestsByUserID(this.User.UserID)
                .Where(r => r.RequestID == requestID)
                .FirstOrDefault();

            Success = !(request is null);

            BuildFeedbackMessage(requestID: requestID);

            Console.Clear();
        }

        public void BuildFeedbackMessage(string previous = "", int requestID = 0)
        {
            var sb = new StringBuilder();

            if (Success)
            {
                var requests = RequestRepository
                    .GetRequestsByUserID(this.User.UserID)
                    .Where(r => r.RequestID == requestID)
                    .ToList();

                string requestHeader = requests.GetRequestHeader(out int trainerLength, out int statusLength, out int messageLength);

                sb.AppendLine(Utils.GetSimpleHeader($"Informações sobre o pedido nº {requestID}"));
                sb.Append(requestHeader);
                requests.ForEach(r => sb.Append($"\n{r.ToString(trainerLength, statusLength, messageLength)}"));
            }
            else if(requestID == 0)
            {
                sb.Append($"Digite um nº de pedido válido.");
            }
            else
            {
                sb.Append($"Não foi encontrado um pedido com o nº {requestID} entre os seu pedidos.");
            }

            FeedbackMessage = sb.ToString();
        }

        #endregion

    }
}