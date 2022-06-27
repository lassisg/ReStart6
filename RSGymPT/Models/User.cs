using System.Collections.Generic;

namespace RSGymPT
{

    internal class User
    {

        #region Enums

        internal enum EnumLogin
        {
            NotLoggedIn,
            LoggedIn
        }

        #endregion
        
        #region Properties

        internal int Id { get; set; }
        internal string Name { get; set; }
        internal string Password { get; set; }
        internal List<Request> Requests { get; set; }
        internal EnumLogin IsLoggedIn { get; set; }

        #endregion

        #region Constructors

        internal User()
        {
            Id = 0;
            Name = string.Empty;
            Password = string.Empty;
            List<Request> requests = new List<Request>();
            IsLoggedIn = EnumLogin.NotLoggedIn;
        }

        internal User (int id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
            List<Request> requests = new List<Request>();
            IsLoggedIn = EnumLogin.NotLoggedIn;
        }

        internal User(int id, string name, string password, List<Request> requests, EnumLogin isLoggedIn)
        {
            Id = id;
            Name = name;
            Password = password;
            Requests = requests;
            IsLoggedIn = isLoggedIn;
        }

        #endregion

        #region Methods

        internal bool Login(string userName, string password)
        {
            bool validCredentials = (userName == Name && password == Password);
            IsLoggedIn = validCredentials ? EnumLogin.LoggedIn : EnumLogin.NotLoggedIn;

            return validCredentials;
        }

        internal bool Logout()
        {
            IsLoggedIn = EnumLogin.NotLoggedIn;
            bool isLoggedOut = IsLoggedIn == EnumLogin.NotLoggedIn;

            return isLoggedOut;

        }

        #endregion

    }

}
