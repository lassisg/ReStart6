using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSGym_Client
{
    class UpdateRequestAction : IBaseAction, ICommunicable, IBreakable
    {

        #region Properties

        public char Code { get; set; }

        public string Name { get; set; }

        public IUser User { get; set; }

        public MenuType MenuType { get; set; }

        public bool Success { get; set; }

        public string FeedbackMessage { get; set; }

        public List<RequestError> Errors { get; set; }

        #endregion

        #region Contructor

        public UpdateRequestAction()
        {
            Code = '6';
            Name = "Update request";
            User = new GuestUser();
            MenuType = MenuType.Restricted;
            Success = false;
            FeedbackMessage = string.Empty;
            Errors = new List<RequestError>();
        }

        #endregion

        #region Methods

        public void Execute(out bool isExit)
        {
            isExit = false;
            string inputValues = string.Empty;
            
            // Coleta de dados
            List<Request> scheduledRequests = RequestRepository
                .GetRequestsByUserID(this.User.UserID)
                .Where(r => r.Status == RequestStatus.Agendado)
                .ToList();

            Console.WriteLine("\nEscolha um pedido para editar.");

            string requestHeader = scheduledRequests
                .GetRequestHeader(out int trainerLength, out int statusLength, out int messageLength);

            Console.WriteLine(requestHeader);
            scheduledRequests.ForEach(r => Console.WriteLine(r.ToString(trainerLength, statusLength, messageLength)));

            Console.Write("\nOpção selecionada: ");
            string request = this.ReadUserInput();

            _ = int.TryParse(request, out int requestID);

            Request currentRequest = scheduledRequests.Where(r => r.RequestID == requestID).FirstOrDefault();

            if (currentRequest is null)
                throw new InvalidOperationException("É necessário escolher um dos pedidos da lista.");

            Console.Write("\nPara todas as opções, caso seja deixado em vazio, será considerado o valor entre '[...]'\n");
            
            Console.Write($"\nDigite a data desejada (no formato dd/MM/aaaa) [{currentRequest.RequestDate:d}]: ");
            string newRequestDate = this.ReadUserInput();

            Console.Write($"\nDigite a data desejada (no formato hh:mm) [{currentRequest.RequestDate:HH\\:mm}]: ");
            string newRequestHour = this.ReadUserInput();

            var trainers = TrainerRepository.GetAllTrainers();

            Console.WriteLine("\nSelecione o treinador:");
            trainers.ForEach(t => Console.WriteLine(t.ToString()));

            Console.Write($"\nOpção selecionada [{currentRequest.TrainerID}]: ");
            string selectedID = this.ReadUserInput();

            string previousMessage = (currentRequest.Message != null && currentRequest.Message.Length > 0) ? $" [{currentRequest.Message}]" : "";
            Console.Write($"\nSe quiser escrever uma mensagem, digite abaixo{previousMessage}: \n");
            string newRequestMessage = this.ReadUserInput();

            // Validação de dados
            Errors.AddRange(newRequestDate.ValidateRequestDate(true));
            Errors.AddRange(newRequestHour.ValidateRequestHour(true));
            Errors.AddRange(selectedID.ValidateRequestTrainer(true));

            // Validações funcionais
            string requestPeriod = $"{newRequestDate}|{newRequestHour}";
            Errors.AddRange(requestPeriod.ValidateRequestPeriod(true));
            Errors.AddRange(requestPeriod.ValidateRequestConflict(this.User.UserID, true));

            bool hasChanges = newRequestDate != string.Empty ||
                              newRequestHour != string.Empty ||
                              selectedID != string.Empty ||
                              newRequestMessage != string.Empty;

            
            if (hasChanges && Errors.Count() == 0)
            {
                string newDate = newRequestDate != string.Empty ? newRequestDate : currentRequest.RequestDate.ToString("d");
                string newHour = newRequestHour != string.Empty ? newRequestHour : currentRequest.RequestDate.ToString("t");
                DateTime requestDate = DateTime.Parse($"{newDate:d} {newHour:t}");
                
                currentRequest.RequestDate = requestDate;
                currentRequest.TrainerID = selectedID != string.Empty ? int.Parse(selectedID) : currentRequest.TrainerID;
                currentRequest.Message = newRequestMessage != string.Empty ? newRequestMessage : currentRequest.Message;
                currentRequest.MessageAt = newRequestMessage != string.Empty ? DateTime.Now : currentRequest.MessageAt;

                RequestRepository.UpdateRequest(currentRequest);
            }

            Success = hasChanges && Errors.Count() == 0;
            
            BuildFeedbackMessage(hasChanges.ToString(), requestID);

            Console.Clear();
        }

        public void BuildFeedbackMessage(string changes = "", int currentRequestID = 0)
        {
            var sb = new StringBuilder();

            if (Success)
            {
                var requests = RequestRepository.GetRequestsByUserID(this.User.UserID)
                       .Where(r => r.RequestID == currentRequestID)
                       .ToList(); 
                
                string requestHeader = requests.GetRequestHeader(out int trainerLength, out int statusLength, out int messageLength);

                sb.AppendLine(Utils.GetSimpleHeader("Pedido atualizado:"));
                sb.Append(requestHeader);
                requests.ForEach(r => sb.Append($"\n{r.ToString(trainerLength, statusLength, messageLength)}"));
            }
            else if (Errors.Count() > 0)
            {
                sb.Append(Errors.GetFormattedRequestError());
            }
            else if (Errors.Count() == 0)
            {
                sb.Append("Não há mudanças a realizar.");
            }

            FeedbackMessage = sb.ToString();
        }

        #endregion

    }
}
