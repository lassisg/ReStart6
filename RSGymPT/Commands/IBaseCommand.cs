using System.Collections.Generic;

namespace RSGymPT
{

    internal interface IBaseCommand
    {
        string Name { get; }

        string HelpText { get; }

        bool IsPrivileged { get; }

        Dictionary<string, string> Arguments { get; }

        string Pattern { get; }

    }

}
