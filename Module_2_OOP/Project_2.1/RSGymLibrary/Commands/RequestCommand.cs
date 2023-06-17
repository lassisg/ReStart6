using System;
using System.Collections.Generic;
using System.Linq;

namespace RSGymLibrary
{

    public class RequestCommand : IBaseCommand, IArgumentCommand
    {

        #region Properties

        public IUser CurrentUser { get; set; }

        public string Name { get; }

        public string HelpText { get; }

        public Dictionary<string, string> Arguments { get; }

        public string Pattern { get; }

        public bool IsValid { get; set; }

        public bool IsRestricted { get; }

        #endregion

        #region Constructors

        public RequestCommand()
        {
            CurrentUser = null;
            Name = "request";
            HelpText = "Faz o pedido do PT, indicando: nome, dia (dd/MM/aaaa) e horas (hh:mm).";
            Arguments = new Dictionary<string, string>()
            {
                { "-n", "trainer" },
                { "-d", "date" },
                { "-h", "hour" },
            };
            Pattern = String.Join(
                string.Empty,
                $@"^{Name}\s{{1}}",
                $@"{Arguments.ElementAt(0).Key}\s{{1}}(?<{Arguments.ElementAt(0).Value}>[\p{{L}} ]+)\s{{1}}",
                $@"{Arguments.ElementAt(1).Key}\s{{1}}(?<{Arguments.ElementAt(1).Value}>[\d\-\/.]{{10}})\s{{1}}",
                $@"{Arguments.ElementAt(2).Key}\s{{1}}(?<{Arguments.ElementAt(2).Value}>[\d:]{{5}})$");
            IsValid = false;
            IsRestricted = true;
        }

        #endregion

        #region Methods

        public bool ValidateArguments(string inputCommand)
        {
            // 1. Valido formato dos argumentos
            string trainerValue = Validator.GetValueFromPatternMatch(inputCommand, Pattern, Arguments.First(a => a.Key == "-n").Value);
            string dateValue = Validator.GetValueFromPatternMatch(inputCommand, Pattern, Arguments.First(a => a.Key == "-d").Value);
            string hourValue = Validator.GetValueFromPatternMatch(inputCommand, Pattern, Arguments.First(a => a.Key == "-h").Value);

            bool isValid = trainerValue.HasValidNamePattern() && dateValue.HasValidDatePattern() && hourValue.HasValidHourPattern();

            if (!isValid)
                throw new ArgumentException("Período do pedido inválido.");

            // 2. Valido condições para aceitar os valores dos argumentos
            DateTime requestDate = DateTime.Parse($"{dateValue} {hourValue}");
            if (requestDate <= DateTime.Now)
                throw new ApplicationException("O pedido não pode ser solicitado para data no passado.");

            DateTime startDate = requestDate;
            DateTime finishDate = startDate.AddHours(1);

            IUser user = GlobalConfig.UsersFile
                                     .FullFilePath()
                                     .LoadFile()
                                     .ConvertToUsers()
                                     .First(u => u.IsLoggedIn == LoginStatus.LoggedIn);
            
            // Validação feita tendo em conta cada aula com duração de 1 hora
            IRequest conflictedRequest = user.Requests.Find(r =>
                (startDate >= r.RequestDate && startDate <= r.RequestDate.AddHours(1)) ||
                (finishDate >= r.RequestDate && finishDate <= r.RequestDate.AddHours(1)));

            if (conflictedRequest != null)
                throw new ApplicationException("Há conflitos de horários.");

            return isValid;
        }
        
        public Dictionary<string, string> ParseInputValues(string inputCommand)
        {
            Dictionary<string, string> result = Arguments.GetArgumentValues(inputCommand, Pattern);

            return result;
        }

        public bool Execute(Dictionary<string, string> inputArguments, out bool isExit)
        {
            isExit = false;
            Console.Clear();

            // Classe Backend simula resposta do serviço de agendamento do ginásio
            bool success = RSGymAPI.ApproveRequest();

            // Se deferido, adiciono o novo pedido à lista do user
            List<IRequest> requests = GlobalConfig.RequestsFile
                                                    .FullFilePath()
                                                    .LoadFile()
                                                    .ConvertToRequests();
            IRequest currentRequest = new Request
            {
                Id = requests.Count() == 0 ? 1 : requests.Max(r => r.Id) + 1,
                TrainerName = inputArguments["-n"].ToString(),
                RequestDate = DateTime.Parse($"{inputArguments["-d"]} {inputArguments["-h"]}"),
                RequestStatus = RequestStatus.Agendado
            };

            if (success)
                CurrentUser.Requests.Add(currentRequest);

            currentRequest.WriteFeedbackMessage(success);

            return success;
        }

        #endregion

    }

}
