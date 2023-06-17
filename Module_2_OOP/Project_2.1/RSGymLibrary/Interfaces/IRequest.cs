using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymLibrary
{

    public interface IRequest
    {

        #region Properties

        int Id { get; set; }

        string TrainerName { get; set; }

        DateTime RequestDate { get; set; }

        RequestStatus RequestStatus { get; set; }

        DateTime CompletedAt { get; set; }

        string Message { get; set; }

        DateTime MessageAt { get; set; }

        #endregion

        #region Methods

        void Cancel();

        void Finish();

        void CommunicateAbsence(string subject);

        void Write();

        #endregion

    }

}
