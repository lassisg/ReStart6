using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RSGymLibrary
{

    public static class CommandProcessor
    {

        public static IBaseCommand ExecuteCommand(this IBaseCommand appCommand, Dictionary<string, string> inputArguments, out bool isExit)
        {
            bool success = appCommand.Execute(inputArguments, out isExit);
            if (!success)
                Communicator.WriteErrorMessage("Algo não correu bem. Por favor reveja o comando executado.");
            
            return appCommand;
        }

        public static Dictionary<string, string> GetArgumentValues(this Dictionary<string, string> commandArguments, string inputCommand, string commandPattern)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            string argValue;
            foreach (KeyValuePair<string, string> arg in commandArguments)
            {
                argValue = Validator.GetValueFromPatternMatch(inputCommand, commandPattern, commandArguments.First(a => a.Key == arg.Key).Value);
                result.Add(arg.Key, argValue);
            }

            return result;
        }

        public static string GetHelp(this IBaseCommand command)
        {
            StringBuilder helpString = new StringBuilder();

            string example = Regex.Replace(command.Pattern, @"\^|\$|\(|\)|\?|\\w|\{|1|5|0|\}|\+|\\d|\/|:|\.|\[|\]", string.Empty);
            
            example = example.Replace("\\s", " ")
                             .Replace("\\-\\", "")
                             .Replace('<', '{')
                             .Replace('>', '}');
            
            helpString.AppendLine($"{command.Name,-12}{command.HelpText}");
            
            string arguments;
            if (command.Arguments.Count() > 0)
            {
                arguments = $"{command.Arguments.Aggregate(new StringBuilder(), (a, b) => a.Append($"{b.Key} {b.Value} ")).ToString().Trim()}";
                helpString.AppendLine($"{string.Empty,-12}{"Parâmetros:",-12}{arguments}");
            }

            helpString.AppendLine($"{string.Empty,-12}{"Exemplo:",-12}{example}");

            return helpString.ToString();
        }

        public static List<IBaseCommand> GetCommands()
        {
            List<IBaseCommand> commands = new List<IBaseCommand>()
            {
                new HelpCommand(),
                new ExitCommand(),
                new ClearCommand(),
                new LoginCommand(),
                new LogoutCommand(),
                new RequestCommand(),
                new CancelCommand(),
                new FinishCommand(),
                new MessageCommand(),
                new MyRequestCommand(),
                new RequestsCommand()
            };

            return commands;
        }

        public static IBaseCommand GetHelpCommand(IBaseCommand appCommand)
        {
            IBaseCommand helpCommand = new HelpCommand
            {
                CurrentUser = appCommand.CurrentUser,
                IsValid = true
            };

            return helpCommand;
        }

    }

}
