using System.Collections.Generic;

namespace RSGym_Client
{

    class GuestMenu : Menu
    {

        public GuestMenu()
        {
            Type = MenuType.Guest;
            MenuItems = new List<IMenuItem>() {
                new MenuItem { Code = '1', Description = "Fazer login" },
                new MenuItem { Code = 'X', Description = "Sair da aplicação" }
            };
        }

    }

}
