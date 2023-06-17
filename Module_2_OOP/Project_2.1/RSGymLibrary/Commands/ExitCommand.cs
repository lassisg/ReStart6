using System;
using System.Collections.Generic;
using System.Linq;

namespace RSGymLibrary
{

    public class ExitCommand : IBaseCommand
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

        public ExitCommand()
        {
            Name = "exit";
            HelpText = "Sai da aplicação.";
            Arguments = new Dictionary<string, string>();
            Pattern = @"^exit$";
            IsValid = false;
            IsRestricted = false;
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
            Console.WriteLine("Muito obrigado por usar a nossa aplicação.");
            Console.WriteLine("Esperamos que tenha gostado.");

            isExit = true;
            bool success = true;
            return success;
        }

        #endregion

    }

}
