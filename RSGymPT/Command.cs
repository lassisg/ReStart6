using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT
{
    internal class Command : IRunnable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public string Use { get; }

        internal Command()
        {
            Name = string.Empty;
            Description = string.Empty;
            Parameters = new Dictionary<string, string>();
        }

        internal Command(string name, string description, Dictionary<string,string> parameters)
        {
            Name = name;
            Description = description;
            Parameters = parameters;
            Use = BuildUse();
        }
        
        private string BuildUse()
        {
            string commandString = Name;
            string parametersString = Parameters.Aggregate(new StringBuilder(), (a, b) => a.Append($"{b.Key} {{{b.Value}}} ")).ToString();
            string useString = string.Join(" ", commandString, parametersString).Replace(" {}", "").Trim();

            return useString;
        }

        public bool HasValidParameters()
        {
            throw new NotImplementedException();
        }

        public bool Run()
        {
            throw new NotImplementedException();
        }

        public string Help()
        {
            StringBuilder helpString = new StringBuilder();

            helpString.AppendLine($"{Name,-12}{Description}");
            if (Parameters.Count() > 0)
            {
                helpString.Append($"{string.Empty,-12}{"Parâmetros:",-12}");
                helpString.AppendLine(Parameters.Aggregate(new StringBuilder(), (a, b) => a.Append($"{b.Key} {b.Value} ")).ToString().Trim());
            }
            helpString.AppendLine($"{string.Empty,-12}{"Exemplo:",-12}{Use}");

            return helpString.ToString();
        }
    }
}
