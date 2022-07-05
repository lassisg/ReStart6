using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RSGymLibrary
{
    public static class Validator
    {

        #region Command validations

        public static IBaseCommand HasValidSession(this IBaseCommand command)
        {
            bool isGuest = command.CurrentUser.IsLoggedIn == LoginStatus.NotLoggedIn;
            bool isLoginCommand = command.GetType() == typeof(LoginCommand);
            bool isRestrictedCommand = command.IsRestricted;

            bool hasValidSession = (isGuest && !isRestrictedCommand) || (!isGuest && !isLoginCommand);

            if (!hasValidSession)
                throw new UnauthorizedAccessException("Erro na validação da sessão.");

            return command;
        }

        public static IBaseCommand HasValidCommandPattern(this IBaseCommand appCommand, string inputCommand)
        {
            bool isValid = Regex.IsMatch(inputCommand, appCommand.Pattern);
            appCommand.IsValid = isValid;

            appCommand = isValid ? appCommand : CommandProcessor.GetHelpCommand(appCommand);

            return appCommand;
        }

        public static IBaseCommand HasValidArgumentsPattern(this IBaseCommand appCommand, string inputCommand)
        {
            bool isHelpCommand = appCommand is HelpCommand;
            bool isValid = appCommand.ValidateArguments(inputCommand) || isHelpCommand;
            appCommand.IsValid = isValid;

            if (!isValid)
                throw new ArgumentException("Erro na validação do comando.");

            return appCommand;
        }

        public static IBaseCommand LoadArgumentValues(this IBaseCommand appCommand, string inputCommand, out Dictionary<string, string> inputArguments)
        {
            inputArguments = new Dictionary<string, string>();

            if (appCommand is IArgumentCommand argumentCommand)
                inputArguments = argumentCommand.ParseInputValues(inputCommand);
            

            return appCommand;
        }

        #endregion

        #region Pattern validations

        internal static bool HasValidUsernamePattern(this string inputUsername)
        {
            // ToDo: Testing values
#if DEBUG
            string usernamePattern = @"^[\w]+$";
#else
            string usernamePattern = @"^[a-zA-Z][a-zA-Z ']{2,70}$";
#endif
            bool success = Regex.IsMatch(inputUsername, usernamePattern);

            return success;
        }

        internal static string GetValueFromPatternMatch(string inputValue, string pattern, string patternGroup)
        {
            // Gets group values from structure pattern
            MatchCollection matches = Regex.Matches(inputValue, pattern);
            string outputValue = matches[0].Groups[patternGroup].Captures.Cast<Capture>().ElementAt(0).ToString();

            return outputValue;
        }

        internal static bool HasValidPasswordPattern(this string password)
        {
            // ToDo: Testing values
#if DEBUG
            string passwordPattern = @"^[\w.]+$";
#else
            string passwordPattern = @"^[\w.#$%&@]{2,50}$";
#endif
            bool success = Regex.IsMatch(password, passwordPattern);

            if (!success)
                throw new FormatException("Formato da palavra passe inválido.");

            return success;
        }

        internal static bool HasValidNamePattern(this string name)
        {
            string namePattern = @"^[\p{L} ]{2,70}$";
            bool success = Regex.IsMatch(name, namePattern);

            if (!success)
                throw new FormatException("Formato do nome inválido.");

            return success;
        }

        internal static bool HasValidDatePattern(this string date)
        {
            string datePattern = String.Join(string.Empty,
                                             @"^(0?[1-9]|[12][0-9]|3[01])([ /.])",  // Day
                                             @"(0?[1-9]|1[012])([ /.])",            // Month
                                             @"(19|20)\d\d$");                      // Year
            bool success = Regex.IsMatch(date, datePattern);

            if (!success)
                throw new FormatException("Formato da data inválido.");

            return success;
        }

        internal static bool HasValidHourPattern(this string hour)
        {
            string hourPattern = @"^([0-1][0-9]|2[0-3]):[0-5][0-9]$";

            bool success = Regex.IsMatch(hour, hourPattern);

            if (!success)
                throw new FormatException("Formato da hora inválido.");

            return success;
        }

        internal static bool HasValidRequestPattern(this string request)
        {
            string requestPattern = @"^\d{1,7}$";

            bool success = Regex.IsMatch(request, requestPattern);

            if (!success)
                throw new FormatException("Formato do nº do pedido inválido.");

            return success;
        }

        internal static bool HasValidMessagePattern(this string message)
        {
            string messagePattern = @"^[\w\d-.\s']+$";
            bool success = Regex.IsMatch(message, messagePattern);

            if (!success)
                throw new FormatException("Formato da mensagem inválido.");

            return success;
        }

        #endregion

        #region Other validations

        public static IBaseCommand UpdateUserInfo(this IBaseCommand currentCommand, IUser previousUser, out IUser currentUser)
        {
            bool changedSession = currentCommand is LoginCommand || currentCommand is LogoutCommand;
            currentUser = changedSession ? currentCommand.CurrentUser : previousUser;
            return currentCommand;
        }

        public static IBaseCommand LogoutOnExit(this IBaseCommand currentCommand, bool isExit)
        {
            if (isExit && currentCommand.CurrentUser is RegisteredUser user)
                user.Logout();

            return currentCommand;
        }

        public static IBaseCommand UpdateUsers(this IBaseCommand currentCommand)
        {
            bool usersChanged = currentCommand is ExitCommand ||
                                currentCommand is LoginCommand ||
                                currentCommand is LogoutCommand ||
                                currentCommand is RequestCommand;

            if (usersChanged)
                currentCommand.CurrentUser.SaveToUsersFile();

            return currentCommand;
        }

        public static void UpdateRequests(this IBaseCommand currentCommand)
        {
            bool requestsChanged = currentCommand is CancelCommand ||
                                   currentCommand is FinishCommand ||
                                   currentCommand is MessageCommand ||
                                   currentCommand is RequestCommand;

            if (requestsChanged)
                currentCommand.CurrentUser.Requests.SaveToRequestsFile();
        }

        #endregion
    }

}
