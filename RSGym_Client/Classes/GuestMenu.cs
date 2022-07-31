using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{

    class GuestMenu : Menu
    {

        #region Constructors

        public GuestMenu()
        {
            Type = MenuType.Guest;
            MenuItems = new List<IMenuItem>() {
                new MenuItem { Code = '1', Description = "Fazer login" },
                new MenuItem { Code = 'X', Description = "Sair da aplicação" }
            };
        }

        #endregion

    }

}
