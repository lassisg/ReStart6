using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymLibrary
{

    public interface IRegisteredUser : IUser
    {

        #region Methods

        bool Logout();

        #endregion

    }

}
