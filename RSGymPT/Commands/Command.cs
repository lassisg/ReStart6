using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RSGymPT
{
    internal abstract class Command : ICommand
    {
        public string Name { get; set; }

        public string HelpText { get; set; }

        public bool IsPrivileged { get; set; }

        public Dictionary<string, string> Arguments { get; set; }
        
        public string Pattern { get; set; }

        public virtual bool Execute(string args)
        {
            throw new NotImplementedException();
        }

        public virtual string GetHelp()
        {
            StringBuilder helpString = new StringBuilder();

            string example = Regex.Replace(Pattern, @"\^|\$|\(|\)|\?|\\w|\{|[1]|\}|\+", string.Empty);
            example = example.Replace("\\s", " ").Replace('<', '{').Replace('>', '}');
            helpString.AppendLine($"{Name,-12}{HelpText}");

            string arguments;
            if (Arguments.Count() > 0)
            {
                arguments = $"{Arguments.Aggregate(new StringBuilder(), (a, b) => a.Append($"{b.Key} {b.Value} ")).ToString().Trim()}";
                helpString.AppendLine($"{string.Empty,-12}{"Parâmetros:",-12}{arguments}");
            }

            helpString.AppendLine($"{string.Empty,-12}{"Exemplo:",-12}{example}");

            return helpString.ToString();
        }

        public virtual bool IsValid(string args)
        {
            Regex rx = new Regex(Pattern);
            bool isValid = rx.IsMatch(args);

            return isValid;
        }

    }
}
