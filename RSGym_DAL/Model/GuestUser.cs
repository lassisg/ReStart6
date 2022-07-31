using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_DAL
{

    public class GuestUser : IUser
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Request> Requests { get; set; }
        public LoginStatus IsLoggedIn { get; set; }

        public GuestUser()
        {
            UserID = 0;
            Username = "Convidado";
            Password = string.Empty;
            Requests = new List<Request>();
            IsLoggedIn = LoginStatus.NotLoggedIn;
        }

    }

}
