using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        

        #endregion

    }

}
