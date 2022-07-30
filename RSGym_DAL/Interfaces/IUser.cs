using System.Collections.Generic;

namespace RSGym_DAL
{

    public interface IUser
    {

        #region Properties
        
        int UserID { get; set; }
        
        string Username { get; set; }
        
        string Password { get; set; }
        
        ICollection<Request> Requests { get; set; }
        
        LoginStatus IsLoggedIn { get; set; }

        #endregion

    }

}