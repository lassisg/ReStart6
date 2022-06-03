using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RSGymPT
{

    internal class CLI
    {


        #region Structs

        internal struct Command
        {
            internal string TheCommand;     // help, exit, clear, login, request, cancel, finish, message, myrequest, requests
            internal string Description;    // Command description for help
            internal List<CommandOption> Options;
            internal string Example;        // Example of the command use
        }

        internal struct CommandOption
        {
            internal char Option;           // u, p, n, d, h, r, s, a
            internal string Description;    // username, password, name, day, hour, request nº, subject
            internal string Value;          // Reads from command input
        }

        #endregion

        #region Properties

        internal List<Command> Commands { get; set; }
        internal bool Session { get; set; }
        internal User ActiveUser { get; set; }

        #endregion

        #region Constructors & related

        internal CLI()
        {
            Session = false;
            Commands = BuildCommands();
        }

        private List<Command> BuildCommands()
        {

            List<CommandOption> commandOptions = BuildCommandOptions();

            List<Command> commands = new List<Command>(){
                new Command(){
                    TheCommand = "help",
                    Description = "Lista os comandos disponíveis na CLI.",
                    Options = new List<CommandOption>(),
                    Example = "help"
                },
                new Command(){
                    TheCommand = "exit",
                    Description = "Sai da aplicação.",
                    Options = new List<CommandOption>(),
                    Example= "exit"
                },
                new Command(){
                    TheCommand = "clear",
                    Description = "Limpa a consola.",
                    Options = new List<CommandOption>(),
                    Example = "clear"
                },
                new Command(){
                    TheCommand = "login",
                    Description = "Faz o login na aplicação.",
                    Options = new List<CommandOption>{
                        commandOptions.Find(c => c.Option == 'u'),
                        commandOptions.Find(c => c.Option == 'p')
                    },
                    Example = "login -u {username} -p {password}"
                },
                new Command(){
                    TheCommand = "logout",
                    Description = "Faz o login da aplicação.",
                    Options = new List<CommandOption>(),
                    Example = "logout"
                },
                new Command(){
                    TheCommand = "request",
                    Description = "Faz o pedido do PT indicando: nome, data e hora. Não pode haver pedidos duplicados.",
                    Options = new List<CommandOption>{
                        commandOptions.Find(c => c.Option == 'n'),
                        commandOptions.Find(c => c.Option == 'd'),
                        commandOptions.Find(c => c.Option == 'h')
                    },
                    Example = "request -n {nome} -d {data} -h {hora}"
                },
                new Command(){
                    TheCommand = "cancel",
                    Description = "Anula o pedido.",
                    Options = new List<CommandOption>{
                        commandOptions.Find(c => c.Option == 'n')
                    },
                    Example = "cancel -r {nº pedido}"
                },
                new Command(){
                    TheCommand = "finish",
                    Description = "Mensagem automática com estado 'aula concluída', data e horas automáticas.",
                    Options = new List<CommandOption>{
                        commandOptions.Find(c => c.Option == 'n')
                    },
                    Example = "finish -r {nº pedido}"
                },
                new Command(){
                    TheCommand = "message",
                    Description = "Mensagem a informar o motivo, data e horas automáticas.",
                    Options = new List<CommandOption>{
                        commandOptions.Find(c => c.Option == 'n'),
                        commandOptions.Find(c => c.Option == 's')
                    },
                    Example = "message -r {nº pedido} -s {assunto}"
                },
                new Command(){
                    TheCommand = "myrequest",
                    Description = "Lista o pedido efetuado. Validar a existência do pedido.",
                    Options = new List<CommandOption>{
                        commandOptions.Find(c => c.Option == 'n')
                    },
                    Example = "myrequest -r {nº pedido}"
                },
                new Command(){
                    TheCommand = "requests",
                    Description = "Lista todos os pedidos efetuados.",
                    Options = new List<CommandOption>{
                        commandOptions.Find(c => c.Option == 'a')
                    },
                    Example = "requests -a"
                }
            };

            return commands;

        }

        private List<CommandOption> BuildCommandOptions()
        {

            return new List<CommandOption> {
                new CommandOption {
                    Option = 'u',
                    Description = "Utilzador",
                    Value = string.Empty
                },
                new CommandOption {
                    Option = 'p',
                    Description = "Palavra passe",
                    Value = string.Empty
                },
                new CommandOption {
                    Option = 'n',
                    Description = "Nome",
                    Value = string.Empty
                },
                new CommandOption {
                    Option = 'd',
                    Description = "Data",
                    Value = string.Empty
                },
                new CommandOption {
                    Option = 'h',
                    Description = "hora",
                    Value = string.Empty
                },
                new CommandOption {
                    Option = 'r',
                    Description = "nº pedido",
                    Value = string.Empty
                },
                new CommandOption {
                    Option = 's',
                    Description = "Assunto",
                    Value = string.Empty
                },
                new CommandOption {
                    Option = 'a',
                    Description = "Todos",
                    Value = string.Empty
                }
            };

        }

        #endregion

        #region Methods

        private List<User> GetUsers()
        {
            // TODO: Change values
            List<User> users = new List<User>
            {
                new User("1", "1"),
                new User("2", "2")
            };

            return users;

        }

        internal bool Run(string[] args)
        {
            bool commandExists = ValidateCommand(args[0]);
            bool isExit = false;

            if (!commandExists)
                throw new NotSupportedException("Comando inválido!");

            switch (args[0])
            {
                case "help":
                    Help();
                    break;

                case "exit":
                    isExit = true;
                    break;

                case "clear":
                    Clear();
                    break;

                case "login":
                    if (!ValidateArguments(args))
                        throw new ArgumentException("Parâmetros do comando incorretos.");
                    
                    Login(args);
                    break;

                case "logout":
                    if (!SessionActive())
                        throw new UnauthorizedAccessException("Não há utilizador com sessão ativa.");

                    Logout();
                    break;

                case "request":
                    if (!SessionActive())
                        throw new UnauthorizedAccessException();
                    
                    if (!ValidateArguments(args))
                        throw new ArgumentException("Parâmetros do comando incorretos.");

                    AddRequest(args);
                    
                    break;

                case "cancel":
                    if (!SessionActive())
                        throw new UnauthorizedAccessException();

                    if (!ValidateArguments(args))
                        throw new ArgumentException("Parâmetros do comando incorretos.");

                    // TODO: Code cancel
                    Console.WriteLine("CancelRequest();");
                    
                    break;

                case "finish":
                    if (!SessionActive())
                        throw new UnauthorizedAccessException();

                    if (!ValidateArguments(args))
                        throw new ArgumentException("Parâmetros do comando incorretos.");

                    // TODO: Code finish
                    Console.WriteLine("FinishRequest();");
                    
                    break;

                case "message":
                    if (!SessionActive())
                        throw new UnauthorizedAccessException();

                    if (!ValidateArguments(args))
                        throw new ArgumentException("Parâmetros do comando incorretos.");

                    // TODO: Code message
                    Console.WriteLine("AddMessage();");
                    
                    break;

                case "myrequest":
                    if (!SessionActive())
                        throw new UnauthorizedAccessException();

                    if (!ValidateArguments(args))
                        throw new ArgumentException("Parâmetros do comando incorretos.");

                    // TODO: Code myrequest
                    Console.WriteLine("GetRequest();");
                    
                    break;

                case "requests":
                    if (!SessionActive())
                        throw new UnauthorizedAccessException();

                    if (!ValidateArguments(args))
                        throw new ArgumentException("Parâmetros do comando incorretos.");

                    // TODO: Code requests
                    Console.WriteLine("ListRequests();");
                    
                    break;

                default:
                    break;
            }

            return isExit;

        }

        private void AddRequest(string[] args)
        {
            bool hasError = false;
            string errorMessage = string.Empty;
            StringBuilder sb = new StringBuilder();

            string name = args[1]
                .Split(new[] { ' ' }, 2)[1]
                .Replace("\"", "");

            string patternName = "[^\"]*[a-zA-Z]+[^\"]*$";
            Regex rgName = new Regex(patternName);
            Match nameMatch = rgName.Match(name);
            if (!nameMatch.Success)
            {
                errorMessage = "Formato do nome inválido.";
                sb.AppendLine(errorMessage);
                hasError = true;
            }

            string eventDate = args[2].Split()[1];
            string patternDate = @"^(0[1-9]|[12][0-9]|3[01])([ /.])(0[1-9]|1[012])([ /.])(19|20)\d\d$";
            Regex rgDate = new Regex(patternDate);
            Match dateMatch = rgDate.Match(eventDate);
            if (!dateMatch.Success)
            {
                errorMessage = "Formato da data inválido.";
                sb.AppendLine(errorMessage);
                hasError = true;
            }

            string eventHour = args[3].Split()[1];
            string patternHour = @"^([0-1][0-9]|2[0-3]):[0-5][0-9]$";
            Regex rgHour = new Regex(patternHour);
            Match hourMatch = rgHour.Match(eventHour);
            if (!hourMatch.Success)
            {
                errorMessage = "Formato da hora inválido.";
                sb.AppendLine(errorMessage);
                hasError = true;
            }

            if (hasError)
                throw new FormatException(sb.ToString());

            Console.WriteLine(name);
            Console.WriteLine(eventDate);
            Console.WriteLine(eventHour);

        }

        private bool SessionActive()
        {
            if (ActiveUser == null)
                return false;

            return true;
        }

        private void Logout()
        {
            ActiveUser = null;
            Session = false;
        }

        private void Login(string[] args)
        {
            User currentUser = new User();
            currentUser.UserName = args[1].Split()[1];
            currentUser.Password = args[2].Split()[1];

            if (!ValidateCredentials(currentUser))
                throw new UnauthorizedAccessException("Utilizador ou palavra passe errado. Verfique os dados de login.");

            if (SessionActive())
                throw new UnauthorizedAccessException("Não foi possível efetuar o login. Já há um utilizador com sessão ativa.");

            ActiveUser = currentUser;
            Session = true;
        }

        private bool ValidateCredentials(User user)
        {
            List<User> users = GetUsers();
            bool validCredentials = users.Exists(u => u.UserName == user.UserName && u.Password == user.Password);

            return validCredentials;
        }

        private bool ValidateCommand(string command)
        {
            Command currentCommand = Commands.Find(c => c.TheCommand == command);
            bool isValid = (currentCommand.TheCommand == null) ? false : true;

            return isValid;
        }

        private bool ValidateArguments(string[] commandArgs)
        {
            CommandOption currentOption = new CommandOption();
            bool hasAllArguments;
            bool isValidArgument = false;

            if (commandArgs.Length == 1)
                return isValidArgument;
            
            int currentCommandArguments = Commands.Find(c => c.TheCommand == commandArgs[0]).Options.Count;
            hasAllArguments = commandArgs.Length - 1 == currentCommandArguments;

            if (!hasAllArguments)
                return isValidArgument;

            for (int i = 1; i < commandArgs.Length; i++)
            {
                currentOption.Option = char.Parse(commandArgs[i].Split(' ')[0]);
                isValidArgument = Commands.Find(c => c.TheCommand == commandArgs[0])
                    .Options.Find(o => o.Option == currentOption.Option).Option != 0;

                if (!isValidArgument)
                    return isValidArgument;
            
            }
            
            return isValidArgument;
        }

        private void Clear()
        {
            Console.Clear();
        }

        private void Help()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            foreach (var command in Commands)
            {
                sb.Append($"{command.TheCommand}".PadRight(12));
                sb.AppendLine($"{command.Description}");

                if (command.Options.Count > 0)
                {

                    sb.AppendLine();
                    sb.Append("".PadRight(12));
                    sb.AppendLine("Parâmetros:");

                    foreach (var option in command.Options)
                    {
                        sb.Append("".PadRight(12));
                        sb.Append($"  -{option.Option}".PadRight(7));
                        sb.AppendLine($"{option.Description}");
                    }
                }

                sb.AppendLine();
                sb.Append("".PadRight(12));
                sb.AppendLine("Examplo de uso:");
                sb.Append("".PadRight(12));
                sb.AppendLine($"  {command.Example}\n");
            }

            Console.WriteLine(sb.ToString());

        }

        #endregion

    }

}
