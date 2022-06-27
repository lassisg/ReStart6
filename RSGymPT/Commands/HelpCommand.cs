using System;
using System.Collections.Generic;

namespace RSGymPT
{
    internal class HelpCommand : Command
    {

        public HelpCommand() : base()
        {
            Name = "help";
            HelpText = "Apresente ajuda sobre os comandos disponíveis";
            IsPrivileged = false;
            Arguments = new Dictionary<string, string>();
            Pattern = @"^help$";
        }

        public bool Execute(string args, List<Command> commands, bool showRestricted)
        {
            Console.Clear();
            if (showRestricted)
            {
                commands.ForEach(c => Console.WriteLine(c.GetHelp()));
            }
            else 
            {
                commands.FindAll(c1 => c1.IsPrivileged == false).ForEach(c2 => Console.WriteLine(c2.GetHelp())); 
            }

            bool success = true;
            return success;
        }

    }

}