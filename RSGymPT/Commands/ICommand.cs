using System.Collections.Generic;

namespace RSGymPT
{

    internal interface ICommand
    {
        string Name { get; }

        string HelpText { get; }

        bool IsPrivileged { get; }

        Dictionary<string, string> Arguments { get; }
        
        string Pattern { get; }

        bool Execute(string args);
        
        bool IsValid(string args);

        string GetHelp();

    }

}
