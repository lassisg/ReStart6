using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSGym_Client
{
    class FinishRequestAction : IBaseAction, ICommunicable
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

        public FinishRequestAction()
        {
            Code = '7';
            Name = "Finish request";
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

            List<Request> scheduledRequests = RequestRepository
                .GetRequestsByUserID(this.User.UserID)
                .Where(r => r.Status == RequestStatus.Agendado)
                .ToList();

            Console.WriteLine("\nEscolha um pedido para concluir.");

            string requestHeader = scheduledRequests
                .GetRequestHeader(out int trainerLength, out int statusLength, out int messageLength);

            Console.WriteLine(requestHeader);
            scheduledRequests
                .ForEach(r => Console.WriteLine(r.ToString(trainerLength, statusLength, messageLength)));

            Console.Write("\nOpção selecionada: ");
            string userInput = this.ReadUserInput();

            _ = int.TryParse(userInput, out int requestID);

            Request request = scheduledRequests
                .Where(r => r.RequestID == requestID)
                .FirstOrDefault();

            if (request != null)
            {
                request.Status = RequestStatus.Concluido;
                request.CompletedAt = DateTime.Now;
                request.Message = "Aula concluída";
                request.MessageAt = DateTime.Now;
                
                RequestRepository.UpdateRequest(request);
            }

            Success = !(request is null);

            BuildFeedbackMessage(requestID: requestID);

            Console.Clear();
        }

        public void BuildFeedbackMessage(string previousRequest = "", int requestID = 0)
        {
            var sb = new StringBuilder();

            if (Success)
            {
                var currentRequest = RequestRepository.GetRequestById(requestID);
                var requests = new List<Request>
                {
                    currentRequest
                };

                string requestHeader = requests.GetRequestHeader(out int trainerLength, out int statusLength, out int messageLength);

                sb.AppendLine("Pedido concluído:");
                sb.AppendLine(requestHeader);
                sb.Append(currentRequest.ToString(trainerLength, statusLength, messageLength));
            }
            else if (requestID == 0)
            {
                sb.Append("Selecione um pedido válido.");
            }
            else
            {
                sb.Append($"Não foi localizado um pedido com o nº {requestID} nas sua lista de pedidos.");
            }

            FeedbackMessage = sb.ToString();
        }

        #endregion

    }
}
