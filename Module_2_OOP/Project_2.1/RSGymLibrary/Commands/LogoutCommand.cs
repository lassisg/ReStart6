using System;
using System.Collections.Generic;
using System.Linq;

namespace RSGymLibrary
{
    public class LogoutCommand : IBaseCommand
    {

        #region Properties

        public IUser CurrentUser { get; set; }

        public string Name { get; }

        public string HelpText { get; }

        public Dictionary<string, string> Arguments { get; }

        public string Pattern { get; }

        public bool IsValid { get; set; }

        public bool IsRestricted { get; }

        #endregion

        #region Constructors

        public LogoutCommand()
        {
            Name = "logout";
            HelpText = "Faz o login da aplicação.";
            Arguments = new Dictionary<string, string>();
            Pattern = @"^logout$";
            IsValid = false;
            IsRestricted = true;
        }

        #endregion

        #region Methods

        public bool ValidateArguments(string inputCommand)
        {
            bool isValid = inputCommand.Split().Count() == Arguments.Count + 1;
            return isValid;
        }

        public bool Execute(Dictionary<string, string> inputArguments, out bool isExit)
        {
            Console.Clear();

            string message = $"Obrigado {CurrentUser.Name} por usar a aplicação.";
            message.WriteSuccessMessage();
            
            CurrentUser = new GuestUser();
            
            isExit = false;
            bool success = true;
            return success;
        }

        #endregion

    }
}
