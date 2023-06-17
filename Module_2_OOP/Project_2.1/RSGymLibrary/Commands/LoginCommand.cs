using System;
using System.Collections.Generic;
using System.Linq;

namespace RSGymLibrary
{

    public class LoginCommand : IBaseCommand, IArgumentCommand
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

        public LoginCommand()
        {
            CurrentUser = null;
            Name = "login";
            HelpText = "Faz o login na aplicação.";
            Arguments = new Dictionary<string, string>()
            {
                { "-u", "username" },
                { "-p", "password" },
            };
            Pattern = String.Join(
                string.Empty,
                $@"^{Name}\s{{1}}",
                $@"{Arguments.ElementAt(0).Key}\s{{1}}(?<{Arguments.ElementAt(0).Value}>\w{{1}})\s{{1}}",
                $@"{Arguments.ElementAt(1).Key}\s{{1}}(?<{Arguments.ElementAt(1).Value}>\w{{1}})$");
            IsValid = false; 
            IsRestricted = false;
        }

        #endregion

        #region Methods

        public bool ValidateArguments(string inputCommand)
        {
            string usernameValue = Validator.GetValueFromPatternMatch(inputCommand, Pattern, Arguments.First(a => a.Key == "-u").Value);
            string passwordValue = Validator.GetValueFromPatternMatch(inputCommand, Pattern, Arguments.First(a => a.Key == "-p").Value);

            bool isValid = usernameValue.HasValidUsernamePattern() && passwordValue.HasValidPasswordPattern();

            return isValid;
        }

        public Dictionary<string, string> ParseInputValues(string inputCommand)
        {
            Dictionary<string, string> result = Arguments.GetArgumentValues(inputCommand, Pattern);

            return result;
        }

        public bool Execute(Dictionary<string, string> inputArguments, out bool isExit)
        {
            isExit = false;
            Console.Clear();

            // 1. Valido se existe user com as credenciais atuais
            List<IUser> users = GlobalConfig.UsersFile.FullFilePath().LoadFile().ConvertToUsers();
            bool success = users.Any(u => u.Name == inputArguments["-u"].ToString() &&
                                          u.Password == inputArguments["-p"].ToString());

            if (!success)
                throw new UnauthorizedAccessException("Utilizador e/ou palavra passe incorreto(s).");

            // 2. Se bem sucedido, pego todos os dados do user e atribuo novo valor para IsLoggedIn
            List<IRequest> requests = GlobalConfig.RequestsFile.FullFilePath().LoadFile().ConvertToRequests();
            CurrentUser = users.First(u => u.Name == inputArguments["-u"].ToString());
            CurrentUser.IsLoggedIn = LoginStatus.LoggedIn;

            string message = $"Seja bem vindo, {CurrentUser.Name}.";
            message.WriteSuccessMessage();

            return success;
        }

        #endregion

    }

}
