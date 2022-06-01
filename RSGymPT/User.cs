using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT
{

    internal class User
    {

        #region Properties

        internal string UserName { get; set; }
        internal string Password { get; set; }
        public List<Request> Requests { get; set; }

        #endregion

        #region Constructors

        internal User()
        {
            UserName = string.Empty;
            Password = string.Empty;
            List<Request> requests = new List<Request>();
        }

        internal User (string userName, string password)
        {
            UserName = userName;
            Password = password;
            List<Request> requests = new List<Request>();
        }

        internal User(string userName, string password, List<Request> requests)
        {
            UserName = userName;
            Password = password;
            Requests = requests;
        }

        #endregion

        #region Methods



        #endregion

    }

}
