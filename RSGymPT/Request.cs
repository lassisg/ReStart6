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
            None,
            Active,
            Completed,
            Canceled
        }

        #endregion

        #region Properties

        internal int Id { get; set; }
        internal string RequestNumber { get; set; }
        internal DateTime RequestDate { get; set; }
        public string TrainerName { get; set; }
        public EnumStatus RequestStatus { get; set; }

        #endregion

        #region Constructors

        internal Request()
        {
            RequestNumber = string.Empty;
            RequestDate = DateTime.MinValue;
            TrainerName = string.Empty;
            RequestStatus = EnumStatus.None;
        }

        internal Request(string requestNumber, DateTime requestDate, string trainerName, EnumStatus requestStatus)
        {
            RequestNumber = requestNumber;
            RequestDate = requestDate;
            TrainerName = trainerName;
            RequestStatus = requestStatus;
        }

        #endregion

        #region Methods

        

        #endregion

    }

}
