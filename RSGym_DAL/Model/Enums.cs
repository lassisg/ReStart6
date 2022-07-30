using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_DAL
{

    public enum LoginStatus
    {
        NotLoggedIn, // 0
        LoggedIn     // 1
    }

    public enum RequestStatus
    {
        Agendado,   // 0
        Concluido,  // 1
        Cancelado   // 2
    }

}
