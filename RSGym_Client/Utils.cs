using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

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

        internal static void PrintHeader(string title, string newLines = "", bool clearConsole = true)
        {

            string border = new string('-', 70);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(border);
            sb.AppendLine(title.ToUpper());
            sb.AppendLine(border);
            sb.Append(newLines);

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

        public static IBaseAction ExecuteAction(this IBaseAction appAction, IMenu menu, out bool isExit)
        {
            appAction.Execute(out isExit);
            
            if (!appAction.Success)
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
                //foreach (var ve in validationException.ValidationErrors)
                //{
                //    paramLength = Math.Max(paramLength, validationException.ValidationErrors.Max(v => v.PropertyName).Length);
                //    inputLength = Math.Max(inputLength, validationException.Entry.CurrentValues.GetValue<object>(ve.PropertyName).ToString().Length);
                //}

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

        internal static string GetHeader(this List<Request> requests, out int trainerLength, out int statusLength, out int messageLength)
        {

            string requestIdHeader = "Nº";
            string dateHourHeader = "Data e hora";
            string trainerHeader = "Personal Trainer";
            string statusHeader = "Status";
            string messageHeader = "Mensagem";

            int requestIdLength = requestIdHeader.Length;
            int dateHourLength = 16;
            trainerLength = requests.Select(r => r.Trainer).ToList().Select(x => x.Name.Length).Max() + 8;
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

    }

}
