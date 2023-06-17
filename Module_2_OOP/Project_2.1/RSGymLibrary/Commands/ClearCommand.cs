using System;
using System.Collections.Generic;
using System.Linq;

namespace RSGymLibrary
{

    public class ClearCommand : IBaseCommand
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

        public ClearCommand()
        {
            Name = "clear";
            HelpText = "Limpa a consola.";
            Arguments = new Dictionary<string, string>();
            Pattern = @"^clear$";
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
            isExit = false;

            bool success = true;
            return success;
        }

        #endregion

    }

}
