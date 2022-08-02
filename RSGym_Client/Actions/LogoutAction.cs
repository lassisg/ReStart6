using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{

    class LogoutAction : IBaseAction
    {

        #region Properties

        public char Code { get; set; }

        public string Name { get; set; }

        public IUser User { get; set; }

        public MenuType MenuType { get; set; }

        public bool Success { get; set; }

        #endregion

        #region Contructor

        public LogoutAction()
        {
            Code = '0';
            Name = "Logout";
            User = new User();
            MenuType = MenuType.Restricted;
        }

        #endregion

        #region Methods

        public void Execute(out bool isExit)
        {
            isExit = false;
            User = new GuestUser();
            Success = true;
            Console.Clear();
            Communicator.WriteSuccessMessage("Logout realizado com sucesso!\nAgora seu nome não aparece na barra de tíulos :-(");
        }

        #endregion

    }

}
