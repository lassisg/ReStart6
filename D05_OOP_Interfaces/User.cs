using System;

namespace D05_OOP_Interfaces
{

    internal class User : IAuthentication
    {

        #region Properties

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        #endregion


        #region Constructors

        internal User() 
        {
            UserName = string.Empty;
            UserPassword = string.Empty;
        }

        internal User(string userName, string userPassword)
        {
            UserName = userName;
            UserPassword = userPassword;
        }

        #endregion

        #region Methods

        public bool Validate(string userName, string password)
        {
            bool isValid = (UserName == userName && UserPassword == password);
            return isValid;
        }

        public void Exit()
        {
            Console.WriteLine("A sair da aplicação...");
            Console.ReadKey();
        }

        public void Message(string message, string startline = "", string endlline = "")
        {
            Console.WriteLine($"{startline}{message}{endlline}");
        }
        
        #endregion

    }

}
