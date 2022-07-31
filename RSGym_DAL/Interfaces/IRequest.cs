using System;

namespace RSGym_DAL
{

    public interface IRequest
    {

        int RequestID { get; set; }
        
        User User { get; set; }
        
        Trainer Trainer { get; set; }
        
        DateTime RequestDate { get; set; }
        
        TimeSpan RequestHour { get; set; }
        
        DateTime CreatedAt { get; set; }
        
        RequestStatus Status { get; set; }
        
        string Message { get; set; }
        
        DateTime? MessageAt { get; set; }
        
        
    }

}