using System;
using System.Collections.Generic;
using System.Linq;

namespace RSGymLibrary
{

    public class MessageCommand : IBaseCommand, IArgumentCommand
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
        
        public MessageCommand()
        {
            Name = "message";
            HelpText = "Envia mensagem a informar o motivo da ausência, com data e horas automáticas.";
            Arguments = new Dictionary<string, string>()
            {
                { "-r", "request" },
                { "-s", "subject" },
            };
            Pattern = String.Join(
                string.Empty,
                $@"^{Name}\s{{1}}",
                $@"{Arguments.ElementAt(0).Key}\s{{1}}(?<{Arguments.ElementAt(0).Value}>\w{{1}})\s{{1}}",
                $@"{Arguments.ElementAt(1).Key}\s{{1}}(?<{Arguments.ElementAt(1).Value}>[\w\d\s]+)$");
            IsValid = false;
            IsRestricted = true;
        }

        #endregion

        #region Methods

        public bool ValidateArguments(string inputCommand)
        {
            string requestValue = Validator.GetValueFromPatternMatch(inputCommand, Pattern, Arguments.First(a => a.Key == "-r").Value);
            string messageValue = Validator.GetValueFromPatternMatch(inputCommand, Pattern, Arguments.First(a => a.Key == "-s").Value);

            bool isValid = requestValue.HasValidRequestPattern() && requestValue.HasValidMessagePattern();

            return isValid;
        }

        public Dictionary<string, string> ParseInputValues(string inputCommand)
        {
            Dictionary<string, string> result = Arguments.GetArgumentValues(inputCommand, Pattern);
            _ = int.TryParse(result["-r"].ToString(), out int requestId);

            // 1. Valido se o request está na lista de requests do utilizador
            IRequest requestToMessage = CurrentUser.Requests.Find(r => r.Id == requestId);

            // 2. Valido se o pedido possui status 'Agendado'
            bool isMessageable = !(requestToMessage is null) && requestToMessage.RequestStatus == RequestStatus.Agendado;

            if (!isMessageable)
                throw new ApplicationException("Não foi possível ccomunicar ausência. Verifique se o pedido está agendado.");

            return result;
        }

        public bool Execute(Dictionary<string, string> inputArguments, out bool isExit)
        {
            isExit = false;
            Console.Clear();

            int requestId = int.Parse(inputArguments["-r"]);
            CurrentUser.Requests.First(r => r.Id == requestId)
                                .CommunicateAbsence(inputArguments["-s"]);

            bool success = CurrentUser.Requests.First(r => r.Id == requestId).RequestStatus == RequestStatus.Falta;
            return success;
        }

        #endregion

    }

}
