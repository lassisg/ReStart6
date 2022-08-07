using RSGym_DAL;
using System;

namespace RSGym_Client
{

    public class BasicAction : IBaseAction
    {

        #region Properties

        public char Code { get; set; }

        public string Name { get; set; }

        public IUser User { get; set; }

        public MenuType MenuType { get; set; }

        public bool Success { get; set; }

        public string FeedbackMessage { get; set; }

        #endregion

        #region Contructor

        public BasicAction()
        {
            Code = '0';
            Name = "Basic";
            User = new GuestUser();
            MenuType = MenuType.Guest;
            Success = false;
            FeedbackMessage = string.Empty;
        }

        #endregion

        #region Methods

        void IBaseAction.Execute(out bool isExit)
        {
            isExit = false;
            Success = true;
            Console.Clear();
        }

        #endregion

    }

}
