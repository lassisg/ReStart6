using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymLibrary
{

    public class RegisteredUser : IRegisteredUser
    {

        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<IRequest> Requests { get; set; }
        public LoginStatus IsLoggedIn { get; set; }

        #endregion

        #region Constructors

        public RegisteredUser()
        {
            Id = 0;
            Name = string.Empty;
            Password = string.Empty;
            List<IRequest> requests = new List<IRequest>();
            IsLoggedIn = LoginStatus.NotLoggedIn;
        }

        public RegisteredUser(int id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
            List<IRequest> requests = new List<IRequest>();
            IsLoggedIn = LoginStatus.NotLoggedIn;
        }

        public RegisteredUser(int id, string name, string password, List<IRequest> requests, LoginStatus isLoggedIn)
        {
            Id = id;
            Name = name;
            Password = password;
            Requests = requests;
            IsLoggedIn = isLoggedIn;
        }

        #endregion

        #region Methods

        public bool Logout()
        {
            IsLoggedIn = LoginStatus.NotLoggedIn;
            bool isLoggedOut = IsLoggedIn == LoginStatus.NotLoggedIn;

            return isLoggedOut;

        }

        #endregion

    }

}
