using System;
using System.Text;

namespace RSGymPT
{

    internal class Request
    {

        #region Enums

        internal enum EnumStatus
        {
            NaN,
            Agendado,
            Finalizado,
            Falta,
            Cancelado
        }

        #endregion

        #region Properties

        internal int Id { get; set; }
        public string TrainerName { get; set; }
        internal DateTime RequestDate { get; set; }
        internal EnumStatus RequestStatus { get; set; }
        internal DateTime CompletedAt { get; set; }
        internal string Message { get; set; }
        internal DateTime MessageAt { get; set; }

        #endregion

        #region Constructors

        internal Request()
        {
            Id = 0;
            RequestDate = DateTime.MinValue;
            TrainerName = string.Empty;
            RequestStatus = EnumStatus.NaN;
            CompletedAt = DateTime.MinValue;
            Message = string.Empty;
            MessageAt = DateTime.MinValue;
        }

        internal Request(int id, DateTime requestDate, string trainerName, EnumStatus requestStatus)
        {
            Id = id;
            RequestDate = requestDate;
            TrainerName = trainerName;
            RequestStatus = requestStatus;
            CompletedAt= DateTime.MinValue;
            Message = string.Empty;
            MessageAt = DateTime.MinValue;
        }

        #endregion

        #region Methods

        internal string Cancel()
        {
            RequestStatus = EnumStatus.Cancelado;
            
            StringBuilder message = new StringBuilder();

            message.AppendLine($"O pedido {Id}, de {RequestDate:dd/MM/yyyy HH:mm}, foi cancelado.");

            return message.ToString();
        }

        internal string Finish()
        {
            RequestStatus = EnumStatus.Finalizado;
            CompletedAt = DateTime.Now;
            Message = "Aula concluída";

            StringBuilder message = new StringBuilder();

            message.Append($"O pedido {Id}, de {RequestDate:dd/MM/yyyy}, ");
            message.AppendLine($"foi finalizado em {CompletedAt:dd/MM/yyyy HH:mm}.");

            return message.ToString();
        }

        internal string CommunicateAbsence(string subject)
        {
            RequestStatus = EnumStatus.Falta;
            CompletedAt = DateTime.Now;
            Message = subject;

            StringBuilder message = new StringBuilder();

            message.Append($"O pedido {Id}, de {RequestDate}, foi marcado como {RequestStatus}, ");
            message.AppendLine($"em {MessageAt:dd/MM/yyyy HH:mm}, com a mensagem:");
            message.AppendLine($"'{Message}'.");

            return message.ToString();
        }

        internal string Get()
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine("");
            message.AppendLine("Detalhes do pedido:");
            message.Append("- Nº:".PadRight(13));
            message.AppendLine($"{Id}");
            message.Append("- Treinador:".PadRight(13));
            message.AppendLine($"{TrainerName}");
            message.Append("- Data:".PadRight(13));
            message.AppendLine($"{RequestDate:dd/MM/yyyy}");
            message.Append("- Hora:".PadRight(13));
            message.AppendLine($"{RequestDate:HH:mm}");
            message.Append("- Status:".PadRight(13));
            message.Append($"{RequestStatus}");
            
            if (RequestStatus == EnumStatus.Finalizado)
                message.Append($" (finalizada em {CompletedAt:dd/MM/yyyy HH:mm})");

            return message.ToString();
        }

        #endregion

    }

}
