using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RSGymPT
{
    internal class LogoutCommand : Command
    {

        public LogoutCommand() : base()
        {
            Name = "logout";
            HelpText = "Faz o logout na aplicação.";
            IsPrivileged = true;
            Arguments = new Dictionary<string, string>();
            Pattern = @"^logout$";
        }

        public override bool Execute(string args)
        {
            Console.Clear();
            bool success = true;
            return success;
        }

        public override bool IsValid(string args)
        {
            Regex rx = new Regex(@"^logout$");
            bool isValid = rx.IsMatch(args);

            return isValid;
        }

        public override string GetHelp()
        {
            StringBuilder helpString = new StringBuilder();

            helpString.AppendLine($"{Name,-12}{HelpText}");
            helpString.AppendLine($"{string.Empty,-12}{"Exemplo:",-12}{Name}");

            return helpString.ToString();
        }
    }

}