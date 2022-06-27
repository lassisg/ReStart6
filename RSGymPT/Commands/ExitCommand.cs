using System;
using System.Collections.Generic;

namespace RSGymPT
{

    internal class ExitCommand : Command
    {

        public ExitCommand() : base()
        {
            Name = "exit";
            HelpText = "Sai da aplicação.";
            IsPrivileged = false;
            Arguments = new Dictionary<string, string>();
            Pattern = @"^exit$";
        }

        public bool Execute(string args, out bool exitApplication)
        {
            Console.Clear();
            Console.WriteLine("Esperamos que nos visite em breve. ;)");
            Console.ReadKey();

            exitApplication = true;
            bool success = true;
            return success;
        }

    }

}
