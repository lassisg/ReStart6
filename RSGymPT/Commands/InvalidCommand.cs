using System;

namespace RSGymPT
{
    internal class InvalidCommand : Command
    {

        public InvalidCommand() : base()
        {
            Name = string.Empty;
            HelpText = string.Empty;
            IsPrivileged = false;
            Arguments = null;
        }

        public override bool Execute(string args)
        {
            Console.Clear();
            bool success = true;

            if (args.Length > 0)
            {
                Console.WriteLine("\nParâmetros inválidos. Por favor verifique o comando executado.\n");
                success = false;
            }

            return success;
        }

        public override string GetHelp()
        {
            return string.Empty;
        }
    }
}