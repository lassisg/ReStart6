using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{
    public abstract class Menu : IMenu
    {

        #region Properties

        public List<IMenuItem> MenuItems { get; set; }

        public MenuType Type { get; set; }

        #endregion

        #region Methods

        public void Show()
        {

            Utils.PrintSubHeader("Escolha uma das opções abaixo");

            foreach (MenuItem menuItem in MenuItems)
            {
                Console.WriteLine($"{menuItem.Code} - {menuItem.Description}");
            }

            Console.Write($"\nOpção selecionada: ");

        }

        #endregion

    }

}
