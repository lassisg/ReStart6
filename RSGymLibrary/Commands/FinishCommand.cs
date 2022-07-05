using System;
using System.Collections.Generic;
using System.Linq;

namespace RSGymLibrary
{

    public class FinishCommand : IBaseCommand, IArgumentCommand
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

        public FinishCommand()
        {
            Name = "finish";
            HelpText = "Envia mensagem automática com estado 'aula concluída', data e horas automáticas.";
            Arguments = new Dictionary<string, string>()
            {
                { "-r", "request" },
            };
            Pattern = String.Join(
                string.Empty,
                $@"^{Name}\s{{1}}",
                $@"{Arguments.ElementAt(0).Key}\s{{1}}(?<{Arguments.ElementAt(0).Value}>\w{{1}})$");
            IsValid = false;
            IsRestricted = true;
        }

        #endregion

        #region Methods

        public bool ValidateArguments(string inputCommand)
        {
            string requestValue = Validator.GetValueFromPatternMatch(inputCommand, Pattern, Arguments.First(a => a.Key == "-r").Value);
            
            bool isValid = requestValue.HasValidRequestPattern();

            if (!isValid)
                throw new FormatException("Formato do nº do pedido inválido.");


            return isValid;
        }

        public Dictionary<string, string> ParseInputValues(string inputCommand)
        {
            Dictionary<string, string> result = Arguments.GetArgumentValues(inputCommand, Pattern);
            _ = int.TryParse(result["-r"].ToString(), out int requestId);

            // 1. Valido se o pedido está na lista de requests do utilizador
            IRequest requestToFinish = CurrentUser.Requests.Find(r => r.Id == requestId);

            // 2. Valido se o pedido possui status 'Agendado'
            bool isFinishable = !(requestToFinish is null) && requestToFinish.RequestStatus == RequestStatus.Agendado;

            if (!isFinishable)
                throw new ApplicationException("Não foi possível concluir o pedido. Verifique se ele está agendado.");

            return result;
        }

        public bool Execute(Dictionary<string, string> inputArguments, out bool isExit)
        {
            isExit = false;
            Console.Clear();

            int requestId = int.Parse(inputArguments["-r"]);
            CurrentUser.Requests.First(r => r.Id == requestId).Finish();

            bool success = CurrentUser.Requests.First(r => r.Id == requestId).RequestStatus == RequestStatus.Finalizado;
            return success;
        }

        #endregion
    }

}
