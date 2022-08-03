using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{

    class LoginAction : IBaseAction, ICommunicable
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

        public LoginAction()
        {
            Code = '1';
            Name = "Login";
            User = new GuestUser();
            MenuType = MenuType.Guest;
            Success = false;
            FeedbackMessage = string.Empty;
        }

        #endregion

        #region Methods

        public void Execute(out bool isExit)
        {
            isExit = false;

            Console.Write("\nDigite seu nome de utilizador: ");
            string username = this.ReadUserInput();

            Console.Write("Digite sua palavra passe: ");
            string password = this.ReadUserInput();

            var currentUser = UserRepository.GetAllUsers()
                .Where(u => u.Username == username && u.Password == password)
                .FirstOrDefault();

            User = currentUser is null ? User : currentUser;
            User.IsLoggedIn = currentUser is null ? LoginStatus.NotLoggedIn : LoginStatus.LoggedIn;

            Success = !(currentUser is null);

            BuildFeedbackMessage();

            Console.Clear();
        }

        public void BuildFeedbackMessage(string previousUser = "", int currentUserID = 0)
        {
            var sb = new StringBuilder();

            if (Success)
            {
                sb.AppendLine("Login realizado com sucesso!");
                sb.Append("Agora seu nome aparece na barra de tíulos ;-)");
            }

            FeedbackMessage = sb.ToString();
        }

        #endregion

    }

}
