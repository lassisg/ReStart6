using System;
using System.Collections.Generic;
using System.Linq;

namespace RSGymLibrary
{

    public class RequestsCommand : IBaseCommand
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

        public RequestsCommand()
        {
            Name = "requests";
            HelpText = "Lista todos os pedidos efetuados.";
            Arguments = new Dictionary<string, string>()
            {
                { "-a", "" },
            };
            Pattern = String.Join(
                string.Empty,
                $@"^{Name}\s{{1}}",
                $@"{Arguments.ElementAt(0).Key}$");
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
            isExit = false;
            Console.Clear();

            int userRequests = CurrentUser.Requests.Count();

            if (userRequests == 0)
            {
                string message = "Não há pedidos para mostrar.";
                message.WriteWarningMessage();
            }

            if (userRequests > 0)
                CurrentUser.Requests.ForEach(r => r.Write());

            bool success = true;
            return success;
        }

        #endregion

    }

}
