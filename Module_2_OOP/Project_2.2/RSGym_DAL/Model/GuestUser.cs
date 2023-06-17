﻿using System.Collections.Generic;

namespace RSGym_DAL
{

    public class GuestUser : IUser
    {

        #region Properties

        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Request> Requests { get; set; }
        public LoginStatus IsLoggedIn { get; set; }

        #endregion

        #region Constructor

        public GuestUser()
        {
            UserID = 0;
            Username = "Convidado";
            Password = string.Empty;
            Requests = new List<Request>();
            IsLoggedIn = LoginStatus.NotLoggedIn;
        }
        
        #endregion

    }

}
