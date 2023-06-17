﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RSGymPT
{
    internal class MyRequestCommand : Command
    {

        public MyRequestCommand() : base()
        {
            Name = "myrequest";
            HelpText = "Lista o pedido efetuado. Validar a existência do pedido.";
            IsPrivileged = true;
            Arguments = new Dictionary<string, string>()
            {
                { "-r", "request" }
            };
            Pattern = @"^myrequest\s{1}-r\s{1}(?<request>\w{1})$";
        }

        public bool Execute(string args, List<Request> requests)
        {
            Console.Clear();
            var matches = Regex.Matches(args, Pattern);
            string request = matches[0].Groups[Arguments.First(a => a.Key == "-r").Value].Value;
            //string request = args.Split()[2];

            bool isValidRequestNumber = int.TryParse(request, out int requestId);

            Request requestToShow = requests.Find(r => r.Id == requestId);

            bool success = !(requestToShow is null);

            if (success)
                requestToShow.Write();

            return success;
        }
    }
}