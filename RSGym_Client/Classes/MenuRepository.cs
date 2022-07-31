using RSGym_DAL;
using System;
using System.Collections.Generic;

namespace RSGym_Client
{

    internal static class MenuRepository
    {
 
        #region Methods

        internal static IMenu GetMenu(IUser currentUser, IBaseAction currentAction)
        {
            IMenu currentMenu;

            if (currentUser.IsLoggedIn == LoginStatus.NotLoggedIn)
            {
                currentMenu = new GuestMenu();
            }
            else if (currentAction.Code == '+')
            {
                currentMenu = new StatisticalMenu();
            }
            else
            {
                currentMenu =new RestrictedMenu() ;
            }

            return currentMenu;
        }

        internal static void Show(this Dictionary<char, string> menuItems)
        {

            Utils.PrintSubHeader("Escolha uma das opções abaixo");

            foreach (KeyValuePair<char, string> menuItem in menuItems)
            {
                Console.WriteLine($"{menuItem.Key} - {menuItem.Value}");
            }

            Console.Write($"\nOpção selecionada: ");

        }
        
        #endregion

    }

}
