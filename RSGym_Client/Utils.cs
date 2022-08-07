using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RSGym_Client
{
    public enum MenuType
    {
        All,        // 0
        Guest,      // 1
        Restricted, // 2
        Statistical // 3
    }

    internal static class Utils
    {

        internal static void SetUTF8Encoding()
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

        }

        internal static void PrintHeader(string title, string linesBefore = "", string linesAfter = "", bool clearConsole = true)
        {

            string border = new string('-', 70);
            StringBuilder sb = new StringBuilder();

            sb.Append(linesBefore);
            sb.AppendLine(border);
            sb.AppendLine(title.ToUpper());
            sb.AppendLine(border);
            sb.Append(linesAfter);

            if (clearConsole)
            {
                Console.Clear();
            }

            Console.Write(sb.ToString());

        }

        internal static void PrintSubHeader(string subTitle)
        {

            Console.WriteLine($"{subTitle}");
            Console.WriteLine(new string('-', 43));

        }

        internal static List<IBaseAction> GetActions()
        {
            var actions = new List<IBaseAction>()
            {
                new AddPTAction(),
                new ListPTAction(),
                new UpdatePTAction(),
                new AddRequestAction(),
                new GetRequestAction(),
                new UpdateRequestAction(),
                new FinishRequestAction(),
                new DeleteRequestAction(),
                new ListRequestAction(),
                new GetTotalUserRequestsAction(),
                new GetRequestsByStatusAction(),
                new GetRequestsByPTAction(),
                new GetTopPTAction(),
                new LoginAction(),
                new LogoutAction(),
                new ExitAction()
            };

            return actions;
        }

        internal static IBaseAction UpdateParameters(this IBaseAction appAction, IMenu menu, char userOption, IUser currentUser)
        {

            appAction = Utils.GetActions()
                .FirstOrDefault(a => a.MenuType == menu.Type && a.Code == userOption) ?? new BasicAction();

            appAction.MenuType = menu.Type;
            appAction.User = currentUser;
            appAction.Code = userOption;

            return appAction;

        }

        internal static string ReadUserInput(this IBaseAction appAction)
        {

            string userInput = Console.ReadLine();
            return userInput;

        }

        internal static void CleanConsole()
        {

            Console.ReadLine();
            Console.Clear();

        }

        internal static char ValidateInputFormat(this string menuOption, out char userOption)
        {
            bool isValidCommand = char.TryParse(menuOption, out userOption);

            if (!isValidCommand)
                throw new ApplicationException("Por favor selecione uma opção válida.");

            return userOption;
        }

        internal static IBaseAction ValidateInputOption(this char menuOption, IMenu menu)
        {
            var currentAction = GetActions()
                .Where(a => a.MenuType == menu.Type || a.MenuType == MenuType.All)
                .FirstOrDefault(c => c.Code == Char.ToUpper(menuOption));

            currentAction = currentAction is null ? new BasicAction() : currentAction;
            
            bool isValidOption = menu.MenuItems.Any(i => i.Code == char.ToUpper(menuOption));

            if (!isValidOption)
                throw new ApplicationException("Por favor selecione uma opção válida.");

            return currentAction;
        }

        public static IBaseAction ExecuteAction(this IBaseAction appAction, out bool isExit)
        {
            appAction.Execute(out isExit);

            // ToDo: check if is needed

            // GuestMenu
            // '1', "Fazer login":              ok (error and success)
            // 'X', "Sair da aplicação":        ok (success)
            // Wrong option:                    ok (error)

            // RestrictedMenu
            // '1', "Registar PT":              ok (error and success)
            // '2', "Listar PTs":               ok (success)
            // '3', "Atualizar PT":             ok (error and success)
            // '4', "Registar pedido":          ok (error and success)
            // '5', "Consultar pedido":         ok (error and success)
            // '6', "Atualizar pedido":         
            // '7', "Conlcuir pedido":          ok (error and success)
            // '8', "Cancelar/Eliminar pedido": ok (error and success)
            // '9', "Listar pedidos":           ok (success)
            // '+', "Estatísticas...":          ok (success)
            // '0', "Logout":                   ok (success)
            // 'X', "Sair da aplicação":        ok (success)
            // Wrong option:                    ok (error)

            // StatisticalMenu
            // '1', "Meu total de pedidos":     ok (success)
            // '2', "Pedidos (por estado)":     ok (success)
            // '3', "Pedidos (por PT)":         ok (success)
            // '4', "PT mais solicitado":       ok (success)
            // '0', "Voltar ao menu anterior":  ok (success)
            // 'X', "Sair da aplicação":        ok (success)
            // Wrong option:                    ok (error)


            if (!appAction.Success && appAction.FeedbackMessage == string.Empty)
                Communicator.WriteErrorMessage("Algo não correu bem. Por favor reveja os dados inseridos.");

            return appAction;
        }

        public static IBaseAction UpdateUserInfo(this IBaseAction currentAction, IUser previousUser, out IUser currentUser)
        {
            bool changedSession = currentAction is LoginAction || currentAction is LogoutAction;
            currentUser = changedSession ? currentAction.User : previousUser;
            currentAction.User = currentUser;
            return currentAction;
        }

        public static IBaseAction SaveCurrentAction(this IBaseAction currentAction, char currentOption)
        {
            currentAction.Code = currentOption;
            return currentAction;
        }

        internal static void GetDbExeptionColumnLengths(this DbEntityValidationException dbException, out int paramLength, out int inputLength)
        {

            paramLength = 0;
            inputLength = 0;

            foreach (var validationException in dbException.EntityValidationErrors)
            {

                (paramLength, inputLength) = validationException.ValidationErrors
                    .Select(t => new { t.PropertyName, t.ErrorMessage })
                    .ToList()
                    .Select(x => new
                    {
                        PropertyNameLength = x.PropertyName.Length,
                        PropertyValueLength = validationException.Entry.CurrentValues.GetValue<object>(x.PropertyName).ToString().Length
                    })
                    .ToList()
                    .Max(p => (p.PropertyNameLength, p.PropertyValueLength));

            }

        }

        internal static string GetFormattedDbExeption(this DbEntityValidationException dbException, int paramLength, int inputLength)
        {

            StringBuilder errors = new StringBuilder();

            foreach (DbEntityValidationResult validationException in dbException.EntityValidationErrors)
            {

                validationException.ValidationErrors
                    .Select(t => new { t.PropertyName, t.ErrorMessage })
                    .ToList()
                    .Select(x => new
                    {
                        PropertyName = x.PropertyName,
                        PropertyValue = validationException.Entry.CurrentValues.GetValue<object>(x.PropertyName).ToString(),
                        ErrorMessage = x.ErrorMessage
                    })
                    .ToList()
                    .ForEach(z => errors.AppendLine($"{z.PropertyName.PadRight(paramLength)} | {z.PropertyValue.PadRight(inputLength)} | {z.ErrorMessage}"));

            }

            return errors.ToString();

        }

        internal static string GetRequestHeader(this List<Request> requests, out int trainerLength, out int statusLength, out int messageLength)
        {

            string requestIdHeader = "Nº";
            string dateHourHeader = "Data e hora";
            string trainerHeader = "Personal Trainer";
            string statusHeader = "Status";
            string messageHeader = "Mensagem";

            int requestIdLength = requestIdHeader.Length;
            int dateHourLength = 16;
            trainerLength = requests.Select(r => r.Trainer).ToList().Select(x => x.Name.Length).Max() + 8;
            trainerLength = Math.Max(trainerLength, trainerHeader.Length);
            statusLength = requests.Select(r => r.Status.ToString().Length).Max();
            statusLength += requests.Any(r => r.Status == RequestStatus.Concluido) ? 33 : 0;
            messageLength = 0;

            StringBuilder header = new StringBuilder();
            header.Append($"\n{requestIdHeader.PadRight(requestIdLength)} | ");
            header.Append($"{dateHourHeader.PadRight(dateHourLength)} | ");
            header.Append($"{trainerHeader.PadRight(trainerLength)} | ");
            header.Append($"{statusHeader.PadRight(statusLength)}");

            StringBuilder headerLine = new StringBuilder();
            headerLine.Append("---+-");
            headerLine.Append($"{new String('-', dateHourLength)}-+-");
            headerLine.Append($"{new String('-', trainerLength)}-+-");
            headerLine.Append($"{new String('-', statusLength)}");

            bool hasMessage = requests.Any(r => r.Message != null);
            if (hasMessage)
            {
                messageLength = requests.Where(r => r.Message != null).Select(r => r.Message.Length).Max();
                header.Append($" | {messageHeader.PadRight(messageLength)}");
                headerLine.Append($"-+-{new String('-', messageLength)}");
            }

            string fullHeader = $"{header}\n{headerLine}";

            return fullHeader;
        }

        internal static string GetFormattedRequestError(this List<(string, string)> errors, string inputValues)
        {
            var sb = new StringBuilder();

            var values = inputValues.Split(',')
                    .Zip(errors, (e, p) => new { Parameter = p.Item1, UserInput = e, Error = p.Item2 })
                    .ToList();

            string paramHeader = "Dado de entrada";
            string inputHeader = "Valor inserido";
            string errorHeader = "Erro";

            int paramLength = values.Max(x => x.Parameter.Length);
            paramLength = Math.Max(paramHeader.Length, paramLength);
            var inputLength = values.Max(x => x.UserInput.Length);
            inputLength = Math.Max(inputHeader.Length, inputLength);
            int errorLength = values.Max(x => x.Error.Length);

            sb.AppendLine("Erro na criação do pedido. Verifique os dados.\n");
            sb.AppendLine($"{paramHeader.PadRight(paramLength)} | {inputHeader.PadRight(inputLength)} | {errorHeader}");
            sb.Append($"{new string('-', paramLength)} | {new string('-', inputLength)} | {new string('-', errorLength)}");
            values.ForEach(x => sb.Append($"\n{x.Parameter.PadRight(paramLength)} | {x.UserInput.PadRight(inputLength)} | {x.Error.PadRight(errorLength)}"));
            
            return sb.ToString();
        }

        internal static string GetSimpleHeader(string simpleHeader)
        {
            simpleHeader = $"{simpleHeader}\n{new string('-', 43)}";
            return simpleHeader;
        }

        internal static bool HasValidDatePattern(this string date)
        {
            string datePattern = String.Join(string.Empty,
                                             @"^(0?[1-9]|[12][0-9]|3[01])([ /.])",  // Day
                                             @"(0?[1-9]|1[012])([ /.])",            // Month
                                             @"(19|20)\d\d$");                      // Year
            bool success = Regex.IsMatch(date, datePattern);

            return success;
        }

        internal static bool HasValidHourPattern(this string hour)
        {
            string hourPattern = @"^([0-1][0-9]|2[0-3]):[0-5][0-9]$";
            bool success = Regex.IsMatch(hour, hourPattern);

            return success;
        }
        
        internal static bool ApproveRequest()
        {
            Random rnd = new Random();
            // Usei 3 com a intenção de receber mais sucesso
            bool isApproved = rnd.Next(0, 3) != 0;

            return isApproved;
        }

    }

}
