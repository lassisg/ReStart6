using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSGym_Client
{
    class AddRequestAction : IBaseAction, ICommunicable, IBreakable
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

        public AddRequestAction()
        {
            Code = '4';
            Name = "Add request";
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
            Console.Write("\nDigite a data desejada (no formato dd/MM/aaaa): ");
            string inputDate = this.ReadUserInput();

            Console.Write("\nDigite a hora desejada (no formato HH:mm): ");
            string inputHour = this.ReadUserInput();

            var trainers = TrainerRepository.GetAllTrainers();
            Console.WriteLine("\nSelecione o treinador:");
            trainers.ForEach(t => Console.WriteLine(t.ToString()));

            Console.Write("\nOpção selecionada: ");
            string selectedID = this.ReadUserInput();

            // Validação de dados
            Errors.AddRange(inputDate.ValidateRequestDate());
            Errors.AddRange(inputHour.ValidateRequestHour());
            Errors.AddRange(selectedID.ValidateRequestTrainer());

            // Validações funcionais
            string requestPeriod = $"{inputDate}|{inputHour}";
            Errors.AddRange(requestPeriod.ValidateRequestPeriod());
            Errors.AddRange(requestPeriod.ValidateRequestConflict(this.User.UserID));

            int requestID = 0;
            if (Errors.Count() == 0)
            {
                // Simulação de resposta do ginásio
                bool approved = Utils.ApproveRequest();

                // Criação do pedido
                requestID = approved ? 0 : -1;

                DateTime requestDate = DateTime.Parse($"{inputDate:d} {inputHour:t}");
                Request newRequest = new Request
                {
                    TrainerID = int.Parse(selectedID),
                    UserID = this.User.UserID,
                    RequestDate = requestDate,
                    CreatedAt = DateTime.Now,
                    Status = RequestStatus.Agendado
                };

                RequestRepository.CreateRequest(newRequest);
                requestID = newRequest.RequestID;
            }

            Success = Errors.Count() == 0 && requestID > 0;
            
            BuildFeedbackMessage(newRequestID: requestID);

            Console.Clear();
        }

        public void BuildFeedbackMessage(string inputValues = "", int newRequestID = 0)
        {
            var sb = new StringBuilder();

            if (Success)
            {
                var requests = RequestRepository
                       .GetRequestsByUserID(this.User.UserID)
                       .Where(r => r.RequestID == newRequestID)
                       .ToList();

                string requestHeader = requests.GetRequestHeader(out int trainerLength, out int statusLength, out int messageLength);

                sb.AppendLine(Utils.GetSimpleHeader($"Informações sobre o novo pedido nº {newRequestID}"));
                sb.Append(requestHeader);
                requests.ForEach(r => sb.Append($"\n{r.ToString(trainerLength, statusLength, messageLength)}"));
            }
            else if (Errors.Count() > 0)
            {
                sb.Append(Errors.GetFormattedRequestError());
            }
            else if(newRequestID == -1)
            {
                sb.AppendLine("Solicitação negada pelo ginásio.");
                sb.Append("Tente outro período ou entre em contacto por telefone ou email para fazer seu pedido.");
            }

            FeedbackMessage = sb.ToString();
        }

        #endregion

    }
}
