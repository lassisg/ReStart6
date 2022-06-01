using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
        public List<User> ActiveUsers { get; set; }

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
            {
                // TODO: Print error message
                Console.WriteLine("Comando inválido!\n");
                return false;
            }

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

                case "request":
                    if (!SessionActive())
                        throw new UnauthorizedAccessException();
                    
                    if (!ValidateArguments(args))
                        throw new ArgumentException("Parâmetros do comando incorretos.");

                    Console.WriteLine("AddRequest();");
                    
                    break;

                case "cancel":
                    if (!SessionActive())
                        throw new UnauthorizedAccessException();

                    if (!ValidateArguments(args))
                        throw new ArgumentException("Parâmetros do comando incorretos.");

                    Console.WriteLine("CancelRequest();");
                    
                    break;

                case "finish":
                    if (!SessionActive())
                        throw new UnauthorizedAccessException();

                    if (!ValidateArguments(args))
                        throw new ArgumentException("Parâmetros do comando incorretos.");

                    Console.WriteLine("FinishRequest();");
                    
                    break;

                case "message":
                    if (!SessionActive())
                        throw new UnauthorizedAccessException();

                    if (!ValidateArguments(args))
                        throw new ArgumentException("Parâmetros do comando incorretos.");

                    Console.WriteLine("AddRequest();");
                    
                    break;

                case "myrequest":
                    if (!SessionActive())
                        throw new UnauthorizedAccessException();

                    if (!ValidateArguments(args))
                        throw new ArgumentException("Parâmetros do comando incorretos.");

                    Console.WriteLine("GetRequest();");
                    
                    break;

                case "requests":
                    if (!SessionActive())
                        throw new UnauthorizedAccessException();

                    if (!ValidateArguments(args))
                        throw new ArgumentException("Parâmetros do comando incorretos.");

                    Console.WriteLine("ListRequests();");
                    
                    break;

                default:
                    break;
            }

            return isExit;

        }

        private bool SessionActive()
        {
            if (ActiveUsers == null)
                return false;

            return true;
        }

        private void Login(string[] args)
        {
            if (UserExists(args))
            {
                Console.WriteLine("existe");
            }
            else
            {
                throw new UnauthorizedAccessException("Utilizador não localizado. Verfique os dados de login.");
            }
        }

        private bool UserExists(string[] args)
        {
            // TODO: Add validation
            List<User> users = GetUsers();

            return true;
        }

        private bool ValidateCommand(string command)
        {
            Command currentCommand = Commands.Find(c => c.TheCommand == command);
            bool isValid = (currentCommand.TheCommand == null) ? false : true;

            return isValid;
        }

        private bool ValidateArguments(string[] commandArgs)
        {
            if (commandArgs.Length == 1)
            {
                return false;
            }
            else
            {
                // TODO: Validate arguments
                Console.WriteLine("Há argumentos...");
            }
            return true;
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
