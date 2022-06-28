using System.Collections.Generic;

namespace RSGymPT
{

    internal interface IUserCommand : IBaseCommand
    {

        bool Execute(string args);

        bool IsValid(string args);

        string GetHelp();

    }

}
