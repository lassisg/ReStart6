using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT
{

    internal interface IExecuter
    {

        #region Parameters

        ICommand Command { get; set; }

        string InputCommand { get; set; }

        #endregion

        #region Methods

        CommandExecuter ValidateCommandStructure();

        CommandExecuter ValidateArgumentValues();

        CommandExecuter ExecuteCommand();

        #endregion

    }

}
