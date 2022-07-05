using System;
using System.Collections.Generic;
using System.Linq;

namespace RSGymLibrary
{

    public class HelpCommand : IBaseCommand
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

        public HelpCommand()
        {
            Name = "help";
            HelpText = "Lista os comandos disponíveis na CLI.";
            Arguments = new Dictionary<string, string>();
            Pattern = @"^help$";
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

            List<IBaseCommand> commands = CommandProcessor.GetCommands();
            bool showRestricted = CurrentUser.IsLoggedIn == LoginStatus.LoggedIn;
             
            commands.FindAll(c1 => !c1.IsRestricted || showRestricted)
                    .ForEach(c2 => Console.WriteLine(c2.GetHelp()));


            bool success = true;
            isExit = false;
            return success;
        }

        #endregion

    }

}
