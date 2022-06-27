using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RSGymPT
{
    internal class RequestsCommand : Command
    {

        public RequestsCommand() : base()
        {
            Name = "requests";
            HelpText = "Lista todos os pedidos efetuados.";
            IsPrivileged = true;
            Arguments = new Dictionary<string, string>()
            {
                { "-a", "all requests" }
            };
            Pattern = @"^requests\s{1}-a$";
        }

        public bool Execute(string _, List<Request> requests)
        {
            Console.Clear();
            bool success = requests.Count() > 0;

            if (success)
                requests.ForEach(r => r.Write());

            return success;
        }

        public override string GetHelp()
        {
            StringBuilder helpString = new StringBuilder();

            string example = Regex.Replace(Pattern, @"\^|\$|\(|\)|\?|\\w|\{|[1]|\}|\+", string.Empty);
            example = example.Replace("\\s", " ").Replace('<', '{').Replace('>', '}');
            helpString.AppendLine($"{Name,-12}{HelpText}");

            string arguments;
            if (Arguments.Count() > 0)
            {
                arguments = $"{Arguments.Aggregate(new StringBuilder(), (a, b) => a.Append($"{b.Key}")).ToString().Trim()}";
                helpString.AppendLine($"{string.Empty,-12}{"Parâmetros:",-12}{arguments}");
            }

            helpString.AppendLine($"{string.Empty,-12}{"Exemplo:",-12}{example}");

            return helpString.ToString();
        }

    }

}