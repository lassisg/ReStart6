using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            string deletedRequest = string.Empty;

            List<Request> scheduledRequests = RequestRepository
                .GetRequestsByUserID(this.User.UserID)
                .Where(r => r.Status == RequestStatus.Agendado)
                .ToList();

            if (scheduledRequests.Count() == 0)
                throw new ApplicationException("Não há pedidos para cancelar/eliminar.");

            Console.WriteLine("\nEscolha um pedido para cancelar/apagar");

            string requestHeader = scheduledRequests
                .GetRequestHeader(out int trainerLength, out int statusLength, out int messageLength);

            Console.WriteLine(requestHeader);
            scheduledRequests
                .ForEach(r => Console.WriteLine(r.ToString(trainerLength, statusLength, messageLength)));

            Console.Write("\nOpção selecionada: ");
            string request = this.ReadUserInput();

            _ = int.TryParse(request, out int requestID);

            Request currentRequest = scheduledRequests
                .Where(r => r.RequestID == requestID)
                .FirstOrDefault();
            

            if (currentRequest != null)
            {
                deletedRequest = $"{requestHeader}\n{currentRequest.ToString(trainerLength, statusLength, messageLength)}";
                RequestRepository.DeleteRequestByID(requestID);
            }

            Success = !(currentRequest is null);

            BuildFeedbackMessage(deletedRequest, requestID);

            Console.Clear();
        }

        public void BuildFeedbackMessage(string request = "", int requestID = 0)
        {
            var sb = new StringBuilder();

            if (Success)
            {
                sb.AppendLine("Pedido cancelado/apagado:");
                sb.Append(request);
            }
            else if(requestID == 0)
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
