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

        #region General methods

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

        internal static string ReadUserInput(this IBaseAction appAction)
        {

            string userInput = Console.ReadLine();
            return userInput;

        }

        #endregion

        #region Action methods

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

        #endregion

        #region Formatting methods

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

        internal static string GetFormattedRequestError(this List<RequestError> errors)
        {
            var sb = new StringBuilder();

            string paramHeader = "Dado de entrada";
            string inputHeader = "Valor inserido";
            string errorHeader = "Erro";

            int paramLength = errors.Max(x => x.Parameter.Length);
            paramLength = Math.Max(paramHeader.Length, paramLength);
            var inputLength = errors.Max(x => x.Input.Length);
            inputLength = Math.Max(inputHeader.Length, inputLength);
            int errorLength = errors.Max(x => x.Message.Length);

            sb.AppendLine("Erro na criação do pedido. Verifique os dados.\n");
            sb.AppendLine($"{paramHeader.PadRight(paramLength)} | {inputHeader.PadRight(inputLength)} | {errorHeader}");
            sb.Append($"{new string('-', paramLength)} | {new string('-', inputLength)} | {new string('-', errorLength)}");
            errors.ForEach(x => sb.Append($"\n{x.Parameter.PadRight(paramLength)} | {x.Input.PadRight(inputLength)} | {x.Message.PadRight(errorLength)}"));
            
            return sb.ToString();
        }

        internal static string GetSimpleHeader(string simpleHeader)
        {
            simpleHeader = $"{simpleHeader}\n{new string('-', 43)}";
            return simpleHeader;
        }

        #endregion

        #region Validation methods

        internal static bool HasValidDatePattern(this string date)
        {
            string datePattern = String.Join(string.Empty,
                                             @"^(0?[1-9]|[12][0-9]|3[01])/",  // Day
                                             @"(0?[1-9]|1[012])/",            // Month
                                             @"(19|20)\d\d$");                // Year
            bool success = Regex.IsMatch(date, datePattern);

            return success;
        }

        internal static bool HasValidHourPattern(this string hour)
        {
            string hourPattern = @"^([0-1][0-9]|2[0-3]):[0-5][0-9]$";
            bool success = Regex.IsMatch(hour, hourPattern);

            return success;
        }
        
        internal static List<RequestError> ValidateRequestDate(this string inputDate, bool allowEmpty = false)
        {
            var errors = new List<RequestError>();

            if (!allowEmpty && inputDate == string.Empty)
            {
                errors.Add(
                    new RequestError
                    {
                        Parameter = "RequestDate",
                        Input = inputDate,
                        Message = "A data do pedido é obrigatória."
                    });
            }

            bool validatePattern = inputDate != string.Empty || (!allowEmpty && inputDate == string.Empty);
            if(validatePattern && !inputDate.HasValidDatePattern())
            {
                errors.Add(
                       new RequestError
                       {
                           Parameter = "RequestDate",
                           Input = inputDate,
                           Message = "A data deve ter o formato 'dd/mm/aaaa'. Ex.: 25/11/2022."
                       });
            }

            return errors;
        }

        internal static List<RequestError> ValidateRequestHour(this string inputHour, bool allowEmpty = false)
        {
            var errors = new List<RequestError>();

            if (!allowEmpty && inputHour == string.Empty)
            {
                errors.Add(
                    new RequestError
                    {
                        Parameter = "RequestHour",
                        Input = inputHour,
                        Message = "A hora do pedido é obrigatória."
                    });
            }

            bool validatePattern = inputHour != string.Empty || (!allowEmpty && inputHour == string.Empty);
            if (validatePattern && !inputHour.HasValidHourPattern())
                if (!inputHour.HasValidHourPattern())
            {
                errors.Add(new RequestError
                {
                    Parameter = "RequestHour",
                    Input = inputHour,
                    Message = "A hora deve ter o formato 'hh:mm'. Ex.: 16:30."
                });
            }

            return errors;
        }

        internal static List<RequestError> ValidateRequestPeriod(this string inputDate, bool allowEmpty = false)
        {
            var errors = new List<RequestError>();

            string date = inputDate.Split('|')[0];
            string hour = inputDate.Split('|')[1];
            _ = DateTime.TryParse($"{date} {hour}", out DateTime requestDate);

            string sanitizedDate = (!date.HasValidDatePattern() || !hour.HasValidHourPattern()) ? "" : inputDate.Replace("|", string.Empty); ;

            bool validatePattern = sanitizedDate != string.Empty || (!allowEmpty && inputDate == string.Empty);
            if (validatePattern && requestDate <= DateTime.Now)
            {
                errors.Add(
                    new RequestError
                    {
                        Parameter = "RequestDate",
                        Input = date,
                        Message = "O pedido não pode ser solicitado para data no passado."
                    });
                errors.Add(
                    new RequestError
                    {
                        Parameter = "RequestHour",
                        Input = hour,
                        Message = "O pedido não pode ser solicitado para data no passado."
                    });
            }

            return errors;
        }

        internal static List<RequestError> ValidateRequestConflict(this string inputDate, int userID, bool allowEmpty = false)
        {
            var errors = new List<RequestError>();

            string date = inputDate.Split('|')[0];
            string hour = inputDate.Split('|')[1];
            _ = DateTime.TryParse($"{date} {hour}", out DateTime requestDate);

            // Validação feita tendo em conta cada aula com duração de 1 hora
            DateTime startDate = requestDate;
            DateTime finishDate = startDate.AddHours(1);

            IRequest conflictedRequest = RequestRepository.GetRequestsByUserID(userID).Find(r =>
                (startDate >= r.RequestDate && startDate <= r.RequestDate.AddHours(1)) ||
                (finishDate >= r.RequestDate && finishDate <= r.RequestDate.AddHours(1)));

            string sanitizedDate = (!date.HasValidDatePattern() || !hour.HasValidHourPattern()) ? "" : inputDate.Replace("|", string.Empty); ;

            bool validatePattern = sanitizedDate != string.Empty || (!allowEmpty && inputDate == string.Empty);
            if (validatePattern && conflictedRequest != null)
            {
                errors.Add(
                    new RequestError
                    {
                        Parameter = "RequestDate",
                        Input = requestDate.ToString("d"),
                        Message = "Há conflitos de horários."
                    });
                errors.Add(
                    new RequestError
                    {
                        Parameter = "RequestHour",
                        Input = requestDate.ToString("t"),
                        Message = "Há conflitos de horários."
                    });
            }

            return errors;
        }

        internal static List<RequestError> ValidateRequestTrainer(this string inputTrainerID, bool allowEmpty = false)
        {
            var errors = new List<RequestError>();

            _ = int.TryParse(inputTrainerID, out int trainerID);
            bool validTrainerID = TrainerRepository.GetAllTrainers().Any(t => t.TrainerID == trainerID);

            bool validatePattern = inputTrainerID != string.Empty || (!allowEmpty && inputTrainerID == string.Empty);
            if (validatePattern && !validTrainerID)
            {
                errors.Add(new RequestError
                {
                    Parameter = "TrainerID",
                    Input = inputTrainerID,
                    Message = "Selecione um PT da lista."
                });
            }

            return errors;
        }

        internal static bool ApproveRequest()
        {
            Random rnd = new Random();
            // Usei 3 com a intenção de receber mais sucesso
            bool isApproved = rnd.Next(0, 3) != 0;

            return isApproved;
        }

        #endregion
    }

}
