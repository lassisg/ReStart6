using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // 1. Listar apenas pedidos agendados do user
            List<Request> scheduledRequests = RequestRepository.GetRequestsByUserID(this.User.UserID)
                .Where(r => r.Status == RequestStatus.Agendado).ToList();

            Console.WriteLine("\nEscolha um pedido para concluir.");

            string requestHeader = scheduledRequests.GetHeader(out int trainerLength, out int statusLength, out int messageLength);

            Console.WriteLine(requestHeader);
            scheduledRequests.ForEach(r => Console.WriteLine(r.ToString(trainerLength, statusLength, messageLength)));

            // 2. Selecionar um dos pedidos, pelo id
            Console.Write("\nOpção selecionada: ");
            string request = this.ReadUserInput();

            // toDo: Validate if input is integer
            int requestID = int.Parse(request);

            Request currentRequest = scheduledRequests.Where(r => r.RequestID == requestID).Single();

            currentRequest.Status = RequestStatus.Concluido;
            currentRequest.CompletedAt = DateTime.Now;
            currentRequest.Message = "Aula concluída";
            currentRequest.MessageAt = DateTime.Now;

            RequestRepository.UpdateRequest(currentRequest);
            Success = true;

            BuildFeedbackMessage(currentRequestID: currentRequest.RequestID);

            Console.Clear();

        }

        public void BuildFeedbackMessage(string previousRequest = "", int currentRequestID = 0)
        {
            var sb = new StringBuilder();

            if (Success)
            {
                var currentRequest = RequestRepository.GetRequestById(currentRequestID);
                var requests = new List<Request>
                {
                    currentRequest
                };

                string requestHeader = requests.GetHeader(out int trainerLength, out int statusLength, out int messageLength);

                sb.AppendLine("Pedido concluído:");
                sb.AppendLine(requestHeader);
                sb.Append(currentRequest.ToString(trainerLength, statusLength, messageLength));
            }

            FeedbackMessage = sb.ToString();
        }

        #endregion

    }
}
