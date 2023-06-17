using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RSGymPT
{
    internal class CancelCommand : Command
    {

        public CancelCommand() : base()
        {
            Name = "cancel";
            HelpText = "Anula o pedido.";
            IsPrivileged = true;
            Arguments = new Dictionary<string, string>()
            {
                { "-r", "request" }
            };
            Pattern = @"^cancel\s{1}-r\s{1}(?<request>\w{1})$";
        }

        public bool Execute(string args, List<Request> requests, out Request requestToCancel)
        {
            Console.Clear();
            var matches = Regex.Matches(args, Pattern);
            string request = matches[0].Groups[Arguments.First(a => a.Key == "-r").Value].Value;
            //string request = args.Split()[2];

            bool isValidRequest = request.IsValidRequest();

            int requestId = int.Parse(request);

            requestToCancel = requests.Find(r => r.Id == requestId);

            bool success = requestToCancel is null;

            if (success)
                requests.First(r => r.Id == requestId).Finish();

            return success;
        }

    }

}