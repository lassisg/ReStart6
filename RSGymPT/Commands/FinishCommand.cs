using System;
using System.Collections.Generic;
using System.Linq;

namespace RSGymPT
{
    internal class FinishCommand : Command
    {

        public FinishCommand() : base()
        {
            Name = "finish";
            HelpText = "Mensagem automática com estado 'aula concluída', data e horas automáticas.";
            IsPrivileged = true;
            Arguments = new Dictionary<string, string>()
            {
                { "-r", "request" }
            };
            Pattern = @"^cancel\s{1}-r\s{1}(?<request>\w{1})$";
        }

        public bool Execute(string args, List<Request> requests, out Request requestToFinish)
        {

            Console.Clear();
            string request = args.Split()[2];

            bool isValidRequestNumber = int.TryParse(request, out int requestId);

            requestToFinish = requests.Find(r => r.Id == requestId);

            bool success = requestToFinish is null;

            if (success)
                requests.First(r => r.Id == requestId).Cancel();

            return success;
        }
    }
}