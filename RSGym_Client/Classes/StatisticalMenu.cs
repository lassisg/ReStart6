using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{
    class StatisticalMenu : Menu
    {

        #region Constructors

        public StatisticalMenu()
        {
            Type = MenuType.Statistical;
            MenuItems = new List<IMenuItem>() {
                new MenuItem { Code = '1', Description = "Meu total de pedidos             - ToDo" },
                new MenuItem { Code = '2', Description = "Pedidos (por estado)             - ToDo" },
                new MenuItem { Code = '3', Description = "Pedidos (por PT)                 - ToDo" },
                new MenuItem { Code = '4', Description = "PT mais solicitado (Esse é Top!) - ToDo" },
                new MenuItem { Code = '0', Description = "Voltar ao menu anterior" }
            };
        }

        #endregion

    }

}
