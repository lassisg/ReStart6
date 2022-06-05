using System.Collections.Generic;

namespace RSGymPT
{

    internal class User
    {

        #region Properties

        internal int Id { get; set; }
        internal string UserName { get; set; }
        internal string Password { get; set; }
        public List<Request> Requests { get; set; }

        #endregion

        #region Constructors

        internal User()
        {
            Id = 0;
            UserName = string.Empty;
            Password = string.Empty;
            List<Request> requests = new List<Request>();
        }

        internal User (int id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
            List<Request> requests = new List<Request>();
        }

        internal User(int id, string userName, string password, List<Request> requests)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Requests = requests;
        }

        #endregion

        #region Methods

        internal bool Login(string userName, string password)
        {
            return (userName == UserName && password == Password);
        }

        #endregion

    }

}
