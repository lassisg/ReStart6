using RSGym_DAL;
using System;
using System.Text;

namespace RSGym_Client
{

    class LogoutAction : IBaseAction, ICommunicable
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

        public LogoutAction()
        {
            Code = '0';
            Name = "Logout";
            User = new User();
            MenuType = MenuType.Restricted;
            Success = false;
            FeedbackMessage = string.Empty;
        }

        #endregion

        #region Methods

        public void Execute(out bool isExit)
        {
            isExit = false;
            User = new GuestUser();
            Success = true;

            BuildFeedbackMessage();

            Console.Clear();
        }

        public void BuildFeedbackMessage(string previousUser = "", int currentUserID = 0)
        {
            var sb = new StringBuilder();

            if (Success)
            {
                sb.AppendLine("Logout realizado com sucesso!");
                sb.Append("Agora seu nome não aparece na barra de tíulos :-(");
            }

            FeedbackMessage = sb.ToString();
        }

        #endregion

    }

}
