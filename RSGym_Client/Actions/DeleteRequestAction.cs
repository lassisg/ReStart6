using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{
    class DeleteRequestAction : IBaseAction, ICommunicable
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

        public DeleteRequestAction()
        {
            Code = '8';
            Name = "Delete request";
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

            Console.WriteLine("\nEscolha um pedido para cancelar/apagar");

            string requestHeader = scheduledRequests.GetHeader(out int trainerLength, out int statusLength, out int messageLength);

            Console.WriteLine(requestHeader);
            scheduledRequests.ForEach(r => Console.WriteLine(r.ToString(trainerLength, statusLength, messageLength)));

            // 2. Selecionar um dos pedidos, pelo id
            Console.Write("\nOpção selecionada: ");
            string request = this.ReadUserInput();

            // toDo: Validate if input is integer
            int requestID = int.Parse(request);

            Request currentRequest = scheduledRequests.Where(r => r.RequestID == requestID).Single();

            RequestRepository.DeleteRequestByID(requestID);
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

                sb.AppendLine("Pedido cancelado/apagado:");
                sb.Append(currentRequest.ToString());
            }

            FeedbackMessage = sb.ToString();
        }

        #endregion

    }
}
