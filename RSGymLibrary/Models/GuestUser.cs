using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymLibrary
{

    public class GuestUser : IUser, IGuestUser
    {

        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<IRequest> Requests { get; set; }
        public LoginStatus IsLoggedIn { get; set; }

        #endregion

        #region Constructors

        public GuestUser()
        {
            Id = 0;
            Name = "Guest";
            Password = string.Empty;
            List<IRequest> requests = new List<IRequest>();
            IsLoggedIn = LoginStatus.NotLoggedIn;
        }

        #endregion

        #region Methods

        public bool Login(string userName, string password)
        {
            bool validCredentials = (userName == Name && password == Password);
            IsLoggedIn = validCredentials ? LoginStatus.LoggedIn : LoginStatus.NotLoggedIn;

            return validCredentials;
        }

        #endregion

    }

}
