using System;
using System.Collections.Generic;

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
            
            string header = "Menu inicial";
            header = this is RestrictedMenu ? "Menu do utilizador" : header;
            header = this is StatisticalMenu ? "Menu estatístico" : header;

            Utils.PrintHeader(header, linesAfter: "\n", clearConsole: false);
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
