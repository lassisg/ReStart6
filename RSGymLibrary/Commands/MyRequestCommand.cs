using System;
using System.Collections.Generic;
using System.Linq;

namespace RSGymLibrary
{

    public class MyRequestCommand : IBaseCommand, IArgumentCommand
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
        
        public MyRequestCommand()
        {
            Name = "myrequest";
            HelpText = "Lista o pedido efetuado.";
            Arguments = new Dictionary<string, string>()
            {
                { "-r", "request" },
            };
            Pattern = String.Join(
                string.Empty,
                $@"^{Name}\s{{1}}",
                $@"{Arguments.ElementAt(0).Key}\s{{1}}(?<{Arguments.ElementAt(0).Value}>\w{{1}})$");
            IsValid = false;
            IsRestricted = true;
        }

        #endregion

        #region Methods

        public bool ValidateArguments(string inputCommand)
        {
            string requestValue = Validator.GetValueFromPatternMatch(inputCommand, Pattern, Arguments.First(a => a.Key == "-r").Value);

            bool isValid = requestValue.HasValidRequestPattern();

            return isValid;
        }

        public Dictionary<string, string> ParseInputValues(string inputCommand)
        {
            Dictionary<string, string> result = Arguments.GetArgumentValues(inputCommand, Pattern);

            // 1. Valido se o request está na lista de requests do utilizador
            IRequest requestToShow = CurrentUser.Requests.Find(r => r.Id == int.Parse(result["-r"]));
            bool success = requestToShow != null;

            if (!success)
                throw new ApplicationException("Pedido não encontrado.");

            return result;
        }

        public bool Execute(Dictionary<string, string> inputArguments, out bool isExit)
        {
            isExit = false;
            Console.Clear();

            IRequest requestToShow = CurrentUser.Requests.First(r => r.Id == int.Parse(inputArguments["-r"]));
            bool success = !(requestToShow is null);

            if (success)
                requestToShow.Write();

            return success;
        }

        #endregion

    }

}
