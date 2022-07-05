using System.Collections.Generic;

namespace RSGymLibrary
{

    public class GeneralCommand : IBaseCommand
    {

        #region Properties

        public string Name { get; set; }

        public string HelpText { get; set; }

        public Dictionary<string, string> Arguments { get; set; }

        public string Pattern { get; set; }

        public bool IsValid { get; set; }
        
        public IUser CurrentUser { get; set; }

        public bool IsRestricted { get; }

        #endregion

        #region Constructors

        public GeneralCommand(IGuestUser currentUser)
        {
            CurrentUser = currentUser;
            Name = string.Empty;
            HelpText = string.Empty;
            Arguments = null;
            Pattern = @"^$";
            IsValid = true;
            IsRestricted = false;
        }

        #endregion

        #region Methods

        public bool ValidateArguments(string inputCommand)
        {
            bool isValid = inputCommand == string.Empty;
            return isValid;
        }

        public bool Execute(Dictionary<string, string> inputArguments, out bool isExit)
        {
            isExit = false;
            bool success = true;
            return success;
        }

        #endregion

    }

}
