using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RSGymPT
{

    internal static class Utils
    {

        internal static bool SessionActive()
        {
            bool isActiveSession = false;
            List<User> users = Repository.GetAllUsers();
            isActiveSession = users.Any(u => u.IsLoggedIn == User.EnumLogin.LoggedIn);

            return isActiveSession;
        }

        internal static Command GetCommandByName(this List<Command> commands, string commandName)
        {
            Command command = commands.FirstOrDefault(c => c.Name == commandName);

            if (command is null)
                command = new InvalidCommand();

            return command;
        }

        internal static void WriteSuccessMessage(string message)
        {
            string separator = new String('-', 7);

            Console.WriteLine(message);

            Console.WriteLine($"{separator}\n");
        }

        internal static void WriteWarningMessage(string message)
        {
            string separator = new String('-', 7);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nAVISO:");
            Console.ResetColor();

            Console.WriteLine(message);

            Console.WriteLine($"{separator}\n");
        }

        internal static void WriteErrorMessage(string message)
        {
            string separator = new String('-', 7);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nERRO:");
            Console.ResetColor();

            Console.WriteLine(message);

            Console.WriteLine($"{separator}\n");
        }

        internal static void WriteFeedbackMessage(this Request request, bool success)
        {
            StringBuilder message = new StringBuilder();

            if (!success)
            {
                message.Append("Pedido não foi aprovado pelo ginásio.");
                message.Append("Tente outro período ou ");
                message.AppendLine("entre em contacto por telefone ou email para fazer seu pedido.");
                Utils.WriteWarningMessage(message.ToString());
            }
            else
            {
                message.Append($"Pedido {request.Id} ");
                message.Append($"criado para {request.RequestDate:dd/MM/yyyy HH:mm} ");
                message.Append($"com o treinador {request.TrainerName}.");
                Utils.WriteSuccessMessage(message.ToString());
            }
        }

        internal static bool IsValidDate(this DateTime date, List<Request> requests)
        {

            if (date <= DateTime.Now)
                throw new ApplicationException("O pedido não pode ser solicitado para data no passado.");

            DateTime startDate = date;
            DateTime finishDate = startDate.AddHours(1);

            // Validação feita tendo em conta cada aula com duração de 1 hora
            Request conflictedRequest = requests.Find(r =>
                (startDate >= r.RequestDate && startDate <= r.RequestDate.AddHours(1)) ||
                (finishDate >= r.RequestDate && finishDate <= r.RequestDate.AddHours(1)));

            if (conflictedRequest != null)
                throw new ApplicationException("Não é possível agendar pedidos para este período devido a conflitos de horário.");

            return true;
        }

        internal static bool IsValidDay(this string inputDay)
        {
            string datePattern = @"^(0?[1-9]|[12][0-9]|3[01])([ /.])(0?[1-9]|1[012])([ /.])(19|20)\d\d$";
            Regex rgDate = new Regex(datePattern);
            Match dateMatch = rgDate.Match(inputDay);

            if (dateMatch.Success)
                throw new FormatException("Formato da data inválido.");

            return dateMatch.Success;
        }

        internal static bool IsValidHour(this string inputHour)
        {
            string hourPattern = @"^([0-1][0-9]|2[0-3]):[0-5][0-9]$";
            Regex rgHour = new Regex(hourPattern);
            Match hourMatch = rgHour.Match(inputHour);

            if (!hourMatch.Success)
                throw new FormatException("Formato da hora inválido.");

            return hourMatch.Success;
        }

        internal static bool IsValidRequest(this string inputRequest)
        {
            string requestPattern = @"^\d{1,7}$";
            Regex rgRequest = new Regex(requestPattern);
            Match requestMatch = rgRequest.Match(inputRequest);

            if (!requestMatch.Success)
                throw new FormatException("Formato do nº do pedido inválido.");

            return requestMatch.Success;
        }

    }

}
