using System.Collections.Generic;

namespace RSGym_DAL
{

    public interface ITrainner
    {
        #region Properties

        int TrainnerID { get; set; }

        string Code { get; set; }
        
        string Name { get; set; }
        
        ICollection<Request> Requests { get; set; }
        
        #endregion

    }

}