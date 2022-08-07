using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<(string, string)> Errors { get; set; }

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
            Errors = new List<(string, string)>();
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

            // ToDo: Validar data e hora (formatos e períodos)
            // em outro método que possa ser usado pelo update
            // Validação de dados
            if (inputDate == string.Empty)
            {
                Errors.Add(("RequestDate", "A data do pedido é obrigatória."));
                inputValues += $"{inputDate},";
            }
            if (!inputDate.HasValidDatePattern())
            {
                Errors.Add(("RequestDate", "A data deve ter o formato 'dd/mm/aaaa'. Ex.: 25/11/2022."));
                inputValues += $"{inputDate},";
            }

            if (inputHour == string.Empty)
            {
                Errors.Add(("RequestHour", "A hora do pedido é obrigatória."));
                inputValues += $"{inputHour},";
            }
            if (!inputHour.HasValidHourPattern())
            {
                Errors.Add(("RequestHour", "A hora deve ter o formato 'hh:mm'. Ex.: 16:30."));
                inputValues += $"{inputHour},";
            }

            bool validTrainerID = int.TryParse(selectedID, out int trainerID);
            if (!validTrainerID)
            {
                Errors.Add(("TrainerID", "Selecione um PT da lista."));
                inputValues += $"{selectedID},";
            }
            
            int requestID = 0;
            if (Errors.Count() == 0)
            {
                // Validações funcionais
                DateTime requestDate = DateTime.Parse($"{inputDate:d} {inputHour:t}");
                if (requestDate <= DateTime.Now)
                {
                    Errors.Add(("RequestDate", "O pedido não pode ser solicitado para data no passado."));
                    inputValues += $"{inputDate:d} {inputHour:t},";
                    Errors.Add(("RequestHour", "O pedido não pode ser solicitado para data no passado."));
                    inputValues += $"{inputDate:d} {inputHour:t},";
                }

                // Validação feita tendo em conta cada aula com duração de 1 hora
                DateTime startDate = requestDate;
                DateTime finishDate = startDate.AddHours(1);

                IRequest conflictedRequest = RequestRepository.GetRequestsByUserID(this.User.UserID).Find(r =>
                    (startDate >= r.RequestDate && startDate <= r.RequestDate.AddHours(1)) ||
                    (finishDate >= r.RequestDate && finishDate <= r.RequestDate.AddHours(1)));

                if (conflictedRequest != null)
                {
                    Errors.Add(("RequestDate", "Há conflitos de horários."));
                    inputValues += $"{inputDate:d} {inputHour:t},";
                    Errors.Add(("RequestHour", "Há conflitos de horários."));
                    inputValues += $"{inputDate:d} {inputHour:t}";
                }

                // Simulação de resposta do ginásio
                bool approved = Utils.ApproveRequest();

                // Criação do pedido
                requestID = approved ? 0 : -1;

                Request newRequest = new Request
                {
                    TrainerID = trainerID,
                    UserID = this.User.UserID,
                    RequestDate = requestDate,
                    CreatedAt = DateTime.Now,
                    Status = RequestStatus.Agendado
                };

                RequestRepository.CreateRequest(newRequest);
                requestID = newRequest.RequestID;
            }

            Success = Errors.Count() == 0 && requestID > 0;
            if (Success)
            {
                BuildFeedbackMessage(newRequestID: requestID);
            }
            else
            {
                BuildFeedbackMessage(inputValues, requestID);
            }

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
                sb.Append(Errors.GetFormattedRequestError(inputValues));
            }
            else if(newRequestID == -1)
            {
                sb.AppendLine("Solicitação negada pelo ginásio.");
                sb.Append("Tente outro período ou entre em contacto por telefone ou email para fazer seu pedido.");
            }
            else
            {
                sb.Append("Não foi possível executar sua solicitação.");
            }

            FeedbackMessage = sb.ToString();
        }

        #endregion

    }
}
