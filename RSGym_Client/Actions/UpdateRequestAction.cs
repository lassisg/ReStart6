using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{
    class UpdateRequestAction : IBaseAction
    {

        #region Properties

        public char Code { get; set; }

        public string Name { get; set; }

        public IUser User { get; set; }

        public MenuType MenuType { get; set; }

        public bool Success { get; set; }

        #endregion

        #region Contructor

        public UpdateRequestAction()
        {
            Code = '6';
            Name = "Update request";
            User = new GuestUser();
            MenuType = MenuType.Restricted;
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

            // 1. Listar apenas pedidos agendados do user

            List<Request> scheduledRequests = RequestRepository.GetRequestsByUserID(this.User.UserID)
                .Where(r => r.Status == RequestStatus.Agendado).ToList();

            Console.WriteLine("\nEscolha um pedido para editar.");

            string requestHeader = scheduledRequests.GetHeader(out int trainerLength, out int statusLength, out int messageLength);

            Console.WriteLine(requestHeader);
            scheduledRequests.ForEach(r => Console.WriteLine(r.ToString(trainerLength, statusLength, messageLength)));

            // 2. Selecionar um dos pedidos, pelo id
            Console.Write("\nOpção selecionada: ");
            string request = this.ReadUserInput();

            // toDo: Validate if input is integer
            int requestID = int.Parse(request);

            Request currentRequest = scheduledRequests.Where(r => r.RequestID == requestID).Single();

            // 3. Se não preencher um novo valor, será mantido o atual (informar o user!)
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


            // ToDo: Validate with Priject 1 if a change in Status is needed

            // ToDo: Validar data e hora (formatos e períodos)
            // em outro método que possa ser usado pelo create

            currentRequest.RequestDate = newRequestDate != string.Empty ? DateTime.Parse(newRequestDate) : currentRequest.RequestDate;
            currentRequest.RequestHour = newRequestHour != string.Empty ? TimeSpan.Parse(newRequestHour) : currentRequest.RequestHour;
            currentRequest.TrainerID = trainerID != string.Empty ? int.Parse(trainerID) : currentRequest.TrainerID;
            currentRequest.Message = newRequestMessage != string.Empty ? newRequestMessage : currentRequest.Message;
            currentRequest.MessageAt = newRequestMessage != string.Empty ? DateTime.Now : currentRequest.MessageAt;

            RequestRepository.UpdateRequest(currentRequest);
            Success = true;

            Console.Clear();

            var sb = new StringBuilder();
            sb.AppendLine("Pedido atualizado:");
            sb.AppendLine(requestHeader);
            sb.Append(currentRequest.ToString(trainerLength, statusLength, messageLength));

            Communicator.WriteSuccessMessage(sb.ToString());
            
        }

        #endregion

    }
}
