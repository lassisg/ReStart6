using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT
{
    internal class CommandExecuter : IExecuter
    {

        #region Parameters

        public ICommand Command { get; set; }
        
        public string InputCommand { get; set; }

        #endregion

        #region Constructors

        internal CommandExecuter(ICommand command, string inputCommand)
        {
            Command = command;
            InputCommand = inputCommand;
        }

        #endregion

        #region Methods

        public CommandExecuter ValidateCommandStructure()
        {
            Command.IsValid = Command.ValidateStructure(InputCommand);
            return this;
        }

        public CommandExecuter ValidateArgumentValues()
        {
            bool hasValidArguments = Command.ValidateArguments(InputCommand);
            return this;
        }

        public CommandExecuter ExecuteCommand()
        {
            bool success = Command.Execute();
            return this;
        }

        public bool IsExitCommand()
        {
            bool isExit = Command.GetType() == typeof(ExitCommand);
            return isExit;
        }

        #endregion

    }

}
