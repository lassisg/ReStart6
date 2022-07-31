using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{
    class RestrictedMenu : Menu
    {

        #region Constructors

        public RestrictedMenu()
        {
            Type = MenuType.Restricted;
            MenuItems = new List<IMenuItem>() {
                new MenuItem { Code = '1', Description = "Registar PT" },
                new MenuItem { Code = '2', Description = "Consultar/Listar PTs" },
                new MenuItem { Code = '3', Description = "Atualizar PT" },
                new MenuItem { Code = '4', Description = "Registar pedido" },
                new MenuItem { Code = '5', Description = "Consultar pedido       - ToDo" },
                new MenuItem { Code = '6', Description = "Atualizar pedido       - ToDo" },
                new MenuItem { Code = '7', Description = "Conlcuir pedido        - ToDo" },
                new MenuItem { Code = '8', Description = "Eliminar pedido        - ToDo" },
                new MenuItem { Code = '9', Description = "Listar pedidos do user - ToDo" },
                new MenuItem { Code = '+', Description = "Estatísticas..." },
                new MenuItem { Code = '0', Description = "Logout" },
                new MenuItem { Code = 'X', Description = "Sair da aplicação" }
            };
        }

        #endregion

    }

}
