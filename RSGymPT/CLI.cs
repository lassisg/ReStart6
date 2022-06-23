﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RSGymPT
{

    internal class CLI
    {

        internal List<User> Users;
        internal List<Request> Requests;

        #region Enums

        internal enum EnumArgumentType
        {
            None,
            Text,
            Date,
            Hour,
            Request
        }
        
        #endregion

        #region Properties

        internal List<IRunnable> Commands { get; set; }
        internal User ActiveUser { get; set; }

        #endregion

        #region Constructors & related

        internal CLI()
        {
            Commands = BuildCommands();
            LoadData();
        }

        private List<IRunnable> BuildCommands()
        {

            List<IRunnable> commands = new List<IRunnable>()
            {
                new RSGymPT.Command(
                    "help",
                    "Lista os comandos disponíveis na CLI.",
                    new Dictionary<string, string>()),

                new RSGymPT.Command(
                    "exit",
                    "Sai da aplicação.",
                    new Dictionary<string, string>()),

                new RSGymPT.Command(
                    "clear",
                    "Limpa a consola.",
                    new Dictionary<string, string>()),

                new RSGymPT.Command(
                    "login",
                    "Faz o login na aplicação.",
                    new Dictionary<string, string>(){
                        { "-u", "username" },
                        { "-p", "password" } }),

                new RSGymPT.Command(
                    "logout",
                    "Faz o logout da aplicação.",
                    new Dictionary<string, string>()),

                new RSGymPT.Command(
                    "request",
                    "Faz o pedido do PT indicando: nome, data e hora. Não pode haver pedidos duplicados.",
                    new Dictionary<string, string>() {
                        { "-n", "PTname" },
                        { "-d", "date" },
                        { "-h", "hour" } }),

                new RSGymPT.Command(
                    "cancel",
                    "Anula o pedido.",
                    new Dictionary<string, string>() {
                        { "-r", "request number" } }),

                new RSGymPT.Command(
                    "finish",
                    "Mensagem automática com estado 'aula concluída', data e horas automáticas.",
                    new Dictionary<string, string>() {
                        { "-r", "request number" } }),

                new RSGymPT.Command(
                    "message",
                    "Mensagem a informar o motivo, data e horas automáticas.",
                    new Dictionary<string, string>() {
                        { "-r", "request number" },
                        { "-s", "subject" } }),

                new RSGymPT.Command(
                    "myrequest",
                    "Lista o pedido efetuado. Validar a existência do pedido.",
                    new Dictionary<string, string>() {
                        { "-r", "request number" } }),

                new RSGymPT.Command(
                    "requests",
                    "Lista todos os pedidos efetuados.",
                    new Dictionary<string, string>() {
                        { "-a", "" } })
            };

            return commands;

        }

        #endregion

        #region General Methods

        private void LoadData()
        {
            LoadUsers();
            LoadRequests();
        }

        private void LoadUsers()
        {
            // Valores utilizados para os utilizadores foram simplificados para agilizar os testes
            Users = new List<User>
            {
                new User(1, "1", "1", new List<Request>()),
                new User(2, "2", "2", new List<Request>())
            };
        }

        private void LoadRequests()
        {
            Requests = new List<Request>();
        }

        //internal bool Run(string[] args)
        //{
        //    bool isExit = false;
        //    string errorMessage;
        //    Dictionary<EnumArgumentType, string> arguments = new Dictionary<EnumArgumentType, string>();

        //    switch (args[0])
        //    {
        //        case "help":
        //            Help();
        //            break;

        //        case "exit":
        //            isExit = true;
        //            break;

        //        case "clear":
        //            Clear();
        //            break;

        //        case "login":
        //            if (SessionActive())
        //                throw new UnauthorizedAccessException("Não foi possível efetuar o login. Já há um utilizador com sessão ativa.");

        //            if (!ValidateArguments(args))
        //                throw new ArgumentException("Parâmetros do comando incorretos.");

        //            User currentUser = Users.Find(u => u.UserName == args[1].Split()[1]);
        //            bool loginSuccess = false;

        //            if (currentUser != null)
        //            {
        //                string userName = args[1].Split()[1];
        //                string password = args[2].Split()[1];
        //                loginSuccess = currentUser.Login(userName, password);
        //            }

        //            if (!loginSuccess) 
        //                throw new UnauthorizedAccessException("Utilizador ou palavra passe errado. Verfique os dados de login."); 

        //            ActiveUser = currentUser; 

        //            break;

        //        case "logout":
        //            if (!SessionActive())
        //                throw new UnauthorizedAccessException("Não há utilizador com sessão ativa.");

        //            Logout();
        //            break;

        //        case "request":
        //            if (!SessionActive())
        //                throw new UnauthorizedAccessException();

        //            if (!ValidateArguments(args))
        //                throw new ArgumentException("Parâmetros do comando incorretos.");

        //            arguments.Add(EnumArgumentType.Text, args[1].Split(new[] { ' ' }, 2)[1].Replace("\"", ""));
        //            arguments.Add(EnumArgumentType.Date, args[2].Split()[1]);
        //            arguments.Add(EnumArgumentType.Hour, args[3].Split()[1]);

        //            errorMessage = HasValidArgumentValues(arguments);
        //            if (errorMessage != string.Empty)
        //                throw new ArgumentException();

        //            CreateRequest(arguments);

        //            break;

        //        case "cancel":
        //            if (!SessionActive())
        //                throw new UnauthorizedAccessException();

        //            if (!ValidateArguments(args))
        //                throw new ArgumentException("Parâmetros do comando incorretos.");

        //            arguments.Add(EnumArgumentType.Request, args[1].Split()[1]);

        //            errorMessage = HasValidArgumentValues(arguments);
        //            if (errorMessage != string.Empty)
        //                throw new ArgumentException();

        //            CancelRequest(arguments);

        //            break;

        //        case "finish":
        //            if (!SessionActive())
        //                throw new UnauthorizedAccessException();

        //            if (!ValidateArguments(args))
        //                throw new ArgumentException("Parâmetros do comando incorretos.");

        //            arguments.Add(EnumArgumentType.Request, args[1].Split()[1]);

        //            errorMessage = HasValidArgumentValues(arguments);
        //            if (errorMessage != string.Empty)
        //                throw new ArgumentException();

        //            FinishRequest(arguments);

        //            break;

        //        case "message":
        //            if (!SessionActive())
        //                throw new UnauthorizedAccessException();

        //            if (!ValidateArguments(args))
        //                throw new ArgumentException("Parâmetros do comando incorretos.");

        //            arguments.Add(EnumArgumentType.Request, args[1].Split()[1]);
        //            arguments.Add(EnumArgumentType.Text, args[2].Split(new[] { ' ' }, 2)[1].Replace("\"", ""));

        //            errorMessage = HasValidArgumentValues(arguments);
        //            if (errorMessage != string.Empty)
        //                throw new ArgumentException();

        //            SendMessage(arguments);

        //            break;

        //        case "myrequest":
        //            if (!SessionActive())
        //                throw new UnauthorizedAccessException();

        //            if (!ValidateArguments(args))
        //                throw new ArgumentException("Parâmetros do comando incorretos.");

        //            arguments.Add(EnumArgumentType.Request, args[1].Split()[1]);

        //            errorMessage = HasValidArgumentValues(arguments);
        //            if (errorMessage != string.Empty)
        //                throw new ArgumentException();

        //            GetRequest(int.Parse(arguments.Values.ElementAt(0)));
        //            Console.WriteLine();

        //            break;

        //        case "requests":
        //            if (!SessionActive())
        //                throw new UnauthorizedAccessException();

        //            if (!ValidateArguments(args))
        //                throw new ArgumentException("Parâmetros do comando incorretos.");

        //            ListRequests();
        //            Console.WriteLine();

        //            break;

        //        default:
        //            Help();
        //            break;
        //    }

        //    return isExit;
        //}

        #endregion

        #region Command methods

        internal bool Help()
        {
            bool isExitApp = false;

            Clear();
            Commands.ForEach(command => Console.WriteLine(command.Help()));

            return isExitApp;
        }

        internal bool Clear()
        {
            bool isExitApp = false;

            Console.Clear();

            return isExitApp;
        }

        internal bool Exit()
        {
            bool isExitApp = true;

            Console.WriteLine("A encerrar a aplicação...");
            Console.ReadKey();

            return isExitApp;
        }

        internal bool Login(string[] args)
        {
            bool isExitApp = false;

            if (SessionActive())
                throw new UnauthorizedAccessException("Não foi possível efetuar o login. Já há um utilizador com sessão ativa.");

            if (!ValidateArguments(args))
                throw new ArgumentException("Parâmetros do comando incorretos.");

            User currentUser = Users.Find(u => u.UserName == args[1].Split()[1]);
            bool loginSuccess = false;

            if (currentUser != null)
            {
                string userName = args[1].Split()[1];
                string password = args[2].Split()[1];
                loginSuccess = currentUser.Login(userName, password);
            }

            if (!loginSuccess)
                throw new UnauthorizedAccessException("Utilizador ou palavra passe errado. Verifique os dados de login.");

            ActiveUser = currentUser;

            return isExitApp;
        }

        internal bool Logout()
        {
            bool isExitApp = false;

            if (!SessionActive())
                throw new UnauthorizedAccessException("Não há utilizador com sessão ativa.");

            ActiveUser = null;

            return isExitApp;
        }

        internal bool CreateRequest(string[] args)
        {

            bool isExitApp = false;


            if (!SessionActive())
                throw new UnauthorizedAccessException();

            Dictionary<CLI.EnumArgumentType, string> arguments = new Dictionary<CLI.EnumArgumentType, string>();
            if (!ValidateArguments(args))
                throw new ArgumentException("Parâmetros do comando incorretos.");

            arguments.Add(EnumArgumentType.Text, args[1].Split(new[] { ' ' }, 2)[1].Replace("\"", ""));
            arguments.Add(EnumArgumentType.Date, args[2].Split()[1]);
            arguments.Add(EnumArgumentType.Hour, args[3].Split()[1]);

            string errorMessage = HasValidArgumentValues(arguments);
            if (errorMessage != string.Empty)
                throw new ArgumentException(errorMessage);

            string name = arguments.Values.ElementAt(0);
            string date = arguments.Values.ElementAt(1);
            string hour = arguments.Values.ElementAt(2);
            DateTime requestDate = DateTime.Parse($"{date} {hour}");

            bool isValidDate = ValidateRequestDate(requestDate);
            if (!isValidDate)
                throw new ApplicationException("Período do pedido inválido.");

            Request newRequest = new Request
            {
                Id = Requests.Count() == 0 ? 1 : Requests.Max(r => r.Id) + 1,
                TrainerName = name,
                RequestDate = requestDate,
                RequestStatus = Request.EnumStatus.Agendado
            };

            StringBuilder message = new StringBuilder();

            // Classe Backend simula resposta do serviço de agendamento do ginásio
            if (!Backend.ApproveRequest())
            {
                message.AppendLine("Pedido não foi aprovado pelo ginásio.");
                message.Append("Tente outro período ou ");
                message.AppendLine("entre em contacto por telefone ou email para fazer seu pedido.");
            }
            else
            {
                Requests.Add(newRequest);
                ActiveUser.Requests.Add(newRequest);
            
                message.Append($"Pedido {newRequest.Id} ");
                message.Append($"criado para {newRequest.RequestDate:dd/MM/yyyy HH:mm} ");
                message.AppendLine($"com o treinador {newRequest.TrainerName}.");
            }

            Console.WriteLine(message.ToString());

            return isExitApp;
        }

        internal bool CancelRequest(string[] args)
        {

            bool isExitApp = false;

            if (!SessionActive())
                throw new UnauthorizedAccessException();

            Dictionary<CLI.EnumArgumentType, string> arguments = new Dictionary<CLI.EnumArgumentType, string>();
            if (!ValidateArguments(args))
                throw new ArgumentException("Parâmetros do comando incorretos.");

            arguments.Add(EnumArgumentType.Request, args[1].Split()[1]);

            string errorMessage = HasValidArgumentValues(arguments);
            if (errorMessage != string.Empty)
                throw new ArgumentException(errorMessage);


            string message;
            int requestId = int.Parse(arguments.Values.ElementAt(0));

            Request requestToCancel = ActiveUser.Requests.Find(r => r.Id == requestId);
            if (requestToCancel is null)
            {
                message = $"O pedido {requestId} não foi localizado na sua lista de pedidos.";
            }
            else if (requestToCancel.RequestStatus != Request.EnumStatus.Agendado)
            {
                message = $"O pedido {requestToCancel.Id} não pôde ser cancelado porque não está ativo.";
            }
            else
            {
                message = requestToCancel.Cancel();
            }

            Console.WriteLine(message);

            return isExitApp;
        }

        internal bool FinishRequest(string[] args)
        {

            bool isExitApp = false;

            if (!SessionActive())
                throw new UnauthorizedAccessException();

            Dictionary<CLI.EnumArgumentType, string> arguments = new Dictionary<CLI.EnumArgumentType, string>();
            if (!ValidateArguments(args))
                throw new ArgumentException("Parâmetros do comando incorretos.");

            arguments.Add(EnumArgumentType.Request, args[1].Split()[1]);

            string errorMessage = HasValidArgumentValues(arguments);
            if (errorMessage != string.Empty)
                throw new ArgumentException(errorMessage);

            string message;
            int requestId = int.Parse(arguments.Values.ElementAt(0));

            Request requestToComplete = ActiveUser.Requests.Find(r => r.Id == requestId);
            if (requestToComplete is null)
            {
                message = $"O pedido {requestId} não foi localizado na sua lista de pedidos.";
            }
            else if (requestToComplete.RequestStatus != Request.EnumStatus.Agendado)
            {
                message = $"O pedido {requestToComplete.Id} não pôde ser finalizado porque não está ativo.";
            }
            else
            {
                message = requestToComplete.Finish();
            }

            Console.WriteLine(message);

            return isExitApp;
        }

        internal bool SendMessage(string[] args)
        {

            bool isExitApp = false;

            if (!SessionActive())
                throw new UnauthorizedAccessException();

            Dictionary<CLI.EnumArgumentType, string> arguments = new Dictionary<CLI.EnumArgumentType, string>();
            if (!ValidateArguments(args))
                throw new ArgumentException("Parâmetros do comando incorretos.");

            arguments.Add(EnumArgumentType.Request, args[1].Split()[1]);
            arguments.Add(EnumArgumentType.Text, args[2].Split(new[] { ' ' }, 2)[1].Replace("\"", ""));

            string errorMessage = HasValidArgumentValues(arguments);
            if (errorMessage != string.Empty)
                throw new ArgumentException(errorMessage);


            string message;
            int requestId = int.Parse(arguments.Values.ElementAt(0));
            string subject = arguments.Values.ElementAt(1);

            Request requestToCommunicate = ActiveUser.Requests.Find(r => r.Id == requestId);
            if (requestToCommunicate is null)
            {
                message = $"O pedido {requestId} não foi localizado na sua lista de pedidos.";
            }
            else if (requestToCommunicate.RequestStatus != Request.EnumStatus.Agendado)
            {
                message = $"Não foi possível comunicar falta para o pedido {requestToCommunicate.Id} porque ele não está ativo.";
            }
            else
            {
                message = requestToCommunicate.CommunicateAbsence(subject);
            }

            Console.WriteLine(message);

            return isExitApp;
        }

        internal bool GetRequest(string[] args)
        {

            bool isExitApp = false;


            if (!SessionActive())
                throw new UnauthorizedAccessException();

            Dictionary<CLI.EnumArgumentType, string> arguments = new Dictionary<CLI.EnumArgumentType, string>();
            if (!ValidateArguments(args))
                throw new ArgumentException("Parâmetros do comando incorretos.");

            arguments.Add(EnumArgumentType.Request, args[1].Split()[1]);

            string errorMessage = HasValidArgumentValues(arguments);
            if (errorMessage != string.Empty)
                throw new ArgumentException(errorMessage);

            string message;
            int requestId = int.Parse(arguments.Values.ElementAt(0));

            Request requestToShow = ActiveUser.Requests.Find(r => r.Id == requestId);
            if (requestToShow is null)
            {
                message = $"O pedido {requestId} não foi localizado na sua lista de pedidos.";
            }
            else
            {
                message = requestToShow.Get();
            }

            Console.WriteLine(message);
            Console.WriteLine();

            return isExitApp;
        }

        internal bool ListRequests(string[] args)
        {

            bool isExitApp = false;

            if (!SessionActive())
                throw new UnauthorizedAccessException();

            if (!ValidateArguments(args))
                throw new ArgumentException("Parâmetros do comando incorretos.");

            if (ActiveUser.Requests.Count == 0)
                throw new ArgumentException("Não há pedidos para listar.");

            ActiveUser.Requests.ForEach(r => Console.WriteLine($"{r.Get()}\n"));

            return isExitApp;
        }

        #endregion

        #region Validation methods

        private string HasValidArgumentValues(Dictionary<EnumArgumentType, string> arguments)
        {
            StringBuilder errorMessage = new StringBuilder();

            foreach (KeyValuePair<EnumArgumentType, string> argument in arguments)
            {
                switch (argument.Key)
                {
                    case EnumArgumentType.None:
                        break;

                    case EnumArgumentType.Text:
                        if (!IsValidText(argument.Value))
                            errorMessage.AppendLine("Formato do nome inválido.");
                        break;

                    case EnumArgumentType.Date:
                        if (!IsValidDate(argument.Value))
                            errorMessage.AppendLine("Formato da data inválido.");
                        break;

                    case EnumArgumentType.Hour:
                        if (!IsValidHour(argument.Value))
                            errorMessage.AppendLine("Formato da hora inválido.");
                        break;

                    case EnumArgumentType.Request:
                        if (!IsValidRequest(argument.Value))
                            errorMessage.AppendLine("Formato do nº do pedido inválido.");
                        break;

                    default:
                        break;
                }
            }

            return errorMessage.ToString();
        }

        private bool IsValidText(string inputText)
        {
            string textPattern = "[^\"]*[a-zA-Z]+[^\"]*$";
            Regex rgText = new Regex(textPattern);
            Match textMatch = rgText.Match(inputText);

            return textMatch.Success;
        }

        private bool IsValidDate(string inputDate)
        {
            string datePattern = @"^(0?[1-9]|[12][0-9]|3[01])([ /.])(0?[1-9]|1[012])([ /.])(19|20)\d\d$";
            Regex rgDate = new Regex(datePattern);
            Match dateMatch = rgDate.Match(inputDate);
            
            return dateMatch.Success;
        }

        private bool IsValidHour(string inputHour)
        {
            string hourPattern = @"^([0-1][0-9]|2[0-3]):[0-5][0-9]$";
            Regex rgHour = new Regex(hourPattern);
            Match hourMatch = rgHour.Match(inputHour);

            return hourMatch.Success;
        }

        private bool IsValidRequest(string inputRequest)
        {
            string requestPattern = @"^\d{1,7}$";
            Regex rgRequest = new Regex(requestPattern);
            Match requestMatch = rgRequest.Match(inputRequest);

            return requestMatch.Success;
        }

        private bool SessionActive()
        {
            bool isActiveSession = (ActiveUser != null);
            return isActiveSession;
        }

        private bool ValidateArguments(string[] commandArgs)
        {
            IRunnable currentCommand = Commands.Find(c => c.Name == commandArgs[0]);

            // TODO: Use Verbatim string literal to validate full command
            // Ex: login -u username -p password  -> @"login -u \w{1} -p \w{1}"
            
            char currentOption;
            bool hasAllArguments;
            bool isValidArgument = false;

            // Verifica se o apenas o comando existe, sem os parâmetros
            if (commandArgs.Length == 1)
                throw new ArgumentException("Parâmetros inválidos. Por favor verifique o comando executado.");

            // Verifica se possui a quantidade correta de parâmetros
            int currentCommandArguments = currentCommand.Parameters.Count;
            hasAllArguments = commandArgs.Length - 1 == currentCommandArguments;

            if (!hasAllArguments)
                throw new ArgumentException("Parâmetros inválidos. Por favor verifique o comando executado.");

            for (int i = 1; i < commandArgs.Length; i++)
            {
                // Verifica se os parâmetros utilizados correspondem aos parâmetros esperados
                currentOption = char.Parse(commandArgs[i].Split(' ')[0]);
                isValidArgument = currentCommand.Parameters.ContainsKey($"-{currentOption}");

                if (!isValidArgument)
                    throw new ArgumentException("Parâmetros inválidos. Por favor verifique o comando executado.");

                // Verifica se os parâmetros utilizados possuem valor associado
                char providedOption = commandArgs[i].Split()[0].ToCharArray()[0];
                bool needsValue = currentCommand.Parameters.ContainsKey($"-{providedOption}") && currentCommand.Parameters.TryGetValue($"-{providedOption}", out string result);

                if (needsValue)
                {
                    isValidArgument = commandArgs[i].Split().Length > 1;
                }
                else
                {
                    isValidArgument = commandArgs[i].Split().Length == 1;
                }

                if (!isValidArgument)
                    throw new ArgumentException("Parâmetros inválidos. Por favor verifique o comando executado.");
            }
            
            return isValidArgument;
        }

        private bool ValidateRequestDate(DateTime requestDate)
        {
            if (requestDate <= DateTime.Now)
                throw new ApplicationException("O pedido não pode ser solicitado para data no passado.");

            DateTime startDate = requestDate;
            DateTime finishDate = startDate.AddHours(1);
            
            // Validação feita tendo em conta cada aula com duração de 1 hora
            Request conflictedRequest = Requests.Find(r => 
                (startDate >= r.RequestDate && startDate <= r.RequestDate.AddHours(1)) || 
                (finishDate >= r.RequestDate && finishDate <= r.RequestDate.AddHours(1)));

            if (conflictedRequest != null)
                throw new ApplicationException("Não é possível agendar pedidos para este período devido a conflitos de horário.");

            return true;
        }

        #endregion

    }

}
