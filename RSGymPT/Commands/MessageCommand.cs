using System;
using System.Collections.Generic;
using System.Linq;

namespace RSGymPT
{
    internal class MessageCommand : Command
    {

        public MessageCommand() : base()
        {
            Name = "message";
            HelpText = "Mensagem a informar o motivo, data e horas automáticas.";
            IsPrivileged = true;
            Arguments = new Dictionary<string, string>()
            {
                { "-r", "request number" },
                { "-s", "subject" },
            };
            Pattern = @"^login\s{1}-r\s{1}(?<request number>\w{1})\s{1}-s\s{1}(?<subject>\w+)$";
        }

        public bool Execute(string args, List<Request> requests, out Request requestToMessage)
        {
            Console.Clear();
            string request = args.Split()[2];
            string subject = args.Split()[4];

            bool isValidRequestNumber = int.TryParse(request, out int requestId);

            requestToMessage = requests.Find(r => r.Id == requestId);

            bool success = !(requestToMessage is null || requestToMessage.RequestStatus != Request.EnumStatus.Agendado);

            if (success)
                requests.First(r => r.Id == requestId).Cancel();

            return success;
        }

    }

}