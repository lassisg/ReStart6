using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymLibrary
{

    public interface IGuestUser : IUser
    {

        #region Methods

        bool Login(string userName, string password);

        #endregion

    }

}
