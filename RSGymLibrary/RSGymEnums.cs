using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymLibrary
{
    public enum LoginStatus
    {
        NotLoggedIn, // 0
        LoggedIn     // 1
    }

    public enum RequestStatus
    {
        NaN,        // 0
        Agendado,   // 1
        Finalizado, // 2
        Falta,      // 3
        Cancelado   // 4
    }

}
