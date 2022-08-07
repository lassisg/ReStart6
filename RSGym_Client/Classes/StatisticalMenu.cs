using System.Collections.Generic;

namespace RSGym_Client
{
    class StatisticalMenu : Menu
    {

        #region Constructors

        public StatisticalMenu()
        {
            Type = MenuType.Statistical;
            MenuItems = new List<IMenuItem>() {
                new MenuItem { Code = '1', Description = "Meu total de pedidos" },
                new MenuItem { Code = '2', Description = "Pedidos (por estado)" },
                new MenuItem { Code = '3', Description = "Pedidos (por PT)" },
                new MenuItem { Code = '4', Description = "PT mais solicitado (Esse é Top!)" },
                new MenuItem { Code = '0', Description = "Voltar ao menu anterior" },
                new MenuItem { Code = 'X', Description = "Sair da aplicação" }
            };
        }

        #endregion

    }

}
