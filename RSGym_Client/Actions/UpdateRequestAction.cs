using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{
    class UpdateRequestAction : IBaseAction, ICommunicable
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

        public UpdateRequestAction()
        {
            Code = '6';
            Name = "Update request";
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

            // Permitir alterar
            //   - data,
            //   - hora,
            //   - PT,
            //   - adicionar mensagem (neste caso, mudar para cancelado)

            List<Request> scheduledRequests = RequestRepository.GetRequestsByUserID(this.User.UserID)
                .Where(r => r.Status == RequestStatus.Agendado).ToList();

            Console.WriteLine("\nEscolha um pedido para editar.");

            string requestHeader = scheduledRequests.GetHeader(out int trainerLength, out int statusLength, out int messageLength);

            Console.WriteLine(requestHeader);
            scheduledRequests.ForEach(r => Console.WriteLine(r.ToString(trainerLength, statusLength, messageLength)));

            Console.Write("\nOpção selecionada: ");
            string request = this.ReadUserInput();

            // toDo: Validate if input is integer
            int requestID = int.Parse(request);

            Request currentRequest = scheduledRequests.Where(r => r.RequestID == requestID).Single();

            Console.Write("\nPara todas as opções, caso seja deixado em vazio, será considerado o valor entre '[...]'\n");

            Console.Write($"\nDigite a data desejada (no formato dd/MM/aaaa) [{currentRequest.RequestDate:d}]: ");
            string newRequestDate = this.ReadUserInput();

            Console.Write($"\nDigite a data desejada (no formato HH:mm) [{currentRequest.RequestHour:hh\\:mm}]: ");
            string newRequestHour = this.ReadUserInput();

            var trainers = TrainerRepository.GetAllTrainers();

            Console.WriteLine("\nSelecione o treinador:");
            trainers.ForEach(t => Console.WriteLine(t.ToString()));

            Console.Write($"\nOpção selecionada [{currentRequest.TrainerID}]: ");
            string trainerID = this.ReadUserInput();

            Console.Write($"\nSe quiser escrever uma mensagem, digite abaixo [{currentRequest.Message}]: \n");
            string newRequestMessage = this.ReadUserInput();


            // ToDo: Validate with Project 1 if a change in Status is needed

            // ToDo: Validate date e hour (formatos e períodos)
            // em outro método que possa ser usado pelo create

            currentRequest.RequestDate = newRequestDate != string.Empty ? DateTime.Parse(newRequestDate) : currentRequest.RequestDate;
            currentRequest.RequestHour = newRequestHour != string.Empty ? TimeSpan.Parse(newRequestHour) : currentRequest.RequestHour;
            currentRequest.TrainerID = trainerID != string.Empty ? int.Parse(trainerID) : currentRequest.TrainerID;
            currentRequest.Message = newRequestMessage != string.Empty ? newRequestMessage : currentRequest.Message;
            currentRequest.MessageAt = newRequestMessage != string.Empty ? DateTime.Now : currentRequest.MessageAt;

            RequestRepository.UpdateRequest(currentRequest);

            Success = true;

            BuildFeedbackMessage(currentRequestID: currentRequest.RequestID);

            Console.Clear();
        }

        public void BuildFeedbackMessage(string previousRequest = "", int currentRequestID = 0)
        {
            // ToDo: Add previous request (in red) above the current (in green)
            var sb = new StringBuilder();

            if (Success)
            {
                var currentRequest = RequestRepository.GetRequestById(currentRequestID);
                var requests = new List<Request>
                {
                    currentRequest
                };

                string requestHeader = requests.GetHeader(out int trainerLength, out int statusLength, out int messageLength);


                sb.AppendLine("Pedido atualizado:");
                sb.AppendLine(requestHeader);
                sb.Append(currentRequest.ToString(trainerLength, statusLength, messageLength));
            }

            FeedbackMessage = sb.ToString();
        }

        #endregion

    }
}
