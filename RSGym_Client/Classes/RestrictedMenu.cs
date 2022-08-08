using System.Collections.Generic;

namespace RSGym_Client
{
    class RestrictedMenu : Menu
    {

        public RestrictedMenu()
        {
            Type = MenuType.Restricted;
            MenuItems = new List<IMenuItem>() {
                new MenuItem { Code = '1', Description = "Registar PT" },
                new MenuItem { Code = '2', Description = "Listar PTs" },
                new MenuItem { Code = '3', Description = "Atualizar PT" },
                new MenuItem { Code = '4', Description = "Registar pedido" },
                new MenuItem { Code = '5', Description = "Consultar pedido" },
                new MenuItem { Code = '6', Description = "Atualizar pedido" },
                new MenuItem { Code = '7', Description = "Conlcuir pedido" },
                new MenuItem { Code = '8', Description = "Cancelar/Eliminar pedido" },
                new MenuItem { Code = '9', Description = "Listar pedidos" },
                new MenuItem { Code = '+', Description = "Estatísticas..." },
                new MenuItem { Code = '0', Description = "Logout" },
                new MenuItem { Code = 'X', Description = "Sair da aplicação" }
            };
        }

    }

}
