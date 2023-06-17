using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymLibrary
{

    public class Request : IRequest
    {

        #region Properties

        public int Id { get; set; }
        public string TrainerName { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public DateTime CompletedAt { get; set; }
        public string Message { get; set; }
        public DateTime MessageAt { get; set; }

        #endregion

        #region Constructors

        public Request()
        {
            Id = 0;
            RequestDate = DateTime.MinValue;
            TrainerName = string.Empty;
            RequestStatus = RequestStatus.NaN;
            CompletedAt = DateTime.MinValue;
            Message = string.Empty;
            MessageAt = DateTime.MinValue;
        }

        public Request(int id, DateTime requestDate, string trainerName, RequestStatus requestStatus)
        {
            Id = id;
            RequestDate = requestDate;
            TrainerName = trainerName;
            RequestStatus = requestStatus;
            CompletedAt = DateTime.MinValue;
            Message = string.Empty;
            MessageAt = DateTime.MinValue;
        }

        #endregion

        #region Methods

        public void Cancel()
        {
            RequestStatus = RequestStatus.Cancelado;

            StringBuilder message = new StringBuilder();
            message.AppendLine($"O pedido {Id}, de {RequestDate:dd/MM/yyyy HH:mm}, foi cancelado.");

            message.ToString().WriteSuccessMessage();
        }

        public void Finish()
        {
            RequestStatus = RequestStatus.Finalizado;
            CompletedAt = DateTime.Now;
            Message = "Aula concluída";

            StringBuilder message = new StringBuilder();

            message.Append($"O pedido {Id}, de {RequestDate:dd/MM/yyyy}, ");
            message.AppendLine($"foi finalizado em {CompletedAt:dd/MM/yyyy HH:mm}.");

            message.ToString().WriteSuccessMessage();
        }

        public void CommunicateAbsence(string subject)
        {
            RequestStatus = RequestStatus.Falta;
            CompletedAt = DateTime.Now;
            Message = subject;

            StringBuilder message = new StringBuilder();

            message.Append($"O pedido {Id}, de {RequestDate}, foi marcado como {RequestStatus}, ");
            message.AppendLine($"em {MessageAt:dd/MM/yyyy HH:mm}, com a mensagem:");
            message.AppendLine($"{"",-9}'{Message}'.");

            message.ToString().WriteSuccessMessage();
        }

        public void Write()
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine("Detalhes do pedido:");
            
            message.AppendLine($"{"- Nº:",-13}{Id}");
            message.AppendLine($"{"- Treinador:",-13}{TrainerName}");
            message.AppendLine($"{"- Data:",-13}{RequestDate:dd/MM/yyyy}");
            message.AppendLine($"{"- Hora:",-13}{RequestDate:HH:mm}");
            message.Append($"{"- Status:",-13}{RequestStatus}");

            if (RequestStatus == RequestStatus.Finalizado)
                message.Append($" (finalizada em {CompletedAt:dd/MM/yyyy HH:mm})");

            message.AppendLine("");

            if (Message.Length > 0)
                message.AppendLine($"{"- Mensagem:",-13}{Message}");

            Console.WriteLine(message.ToString());
        }

        #endregion

    }

}
