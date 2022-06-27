using System;
using System.Collections.Generic;

namespace RSGymPT
{

    internal class ClearCommand : Command
    {

        public ClearCommand() : base()
        {
            Name = "clear";
            HelpText = "Limpa a consola.";
            IsPrivileged = false;
            Arguments = new Dictionary<string, string>();
            Pattern = @"^clear$";
        }

        public override bool Execute(string _)
        {
            Console.Clear();

            bool success = true;
            return success;
        }

    }

}
