using System.Collections.Generic;

namespace RSGym_DAL
{

    public interface ITrainer
    {

        int TrainerID { get; set; }

        string Code { get; set; }
        
        string Name { get; set; }
        
        ICollection<Request> Requests { get; set; }
        
    }

}