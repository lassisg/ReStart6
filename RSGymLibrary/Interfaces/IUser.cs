using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymLibrary
{

    public interface IUser
    {

        #region Properties

        int Id { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        List<IRequest> Requests { get; set; }
        LoginStatus IsLoggedIn { get; set; }

        #endregion

    }

}
