using System;
using System.Collections.Generic;
using System.Linq;

namespace RSGymPT
{
    internal class RequestCommand : Command
    {

        public RequestCommand() : base()
        {
            Name = "request";
            HelpText = "Faz o pedido do PT indicando: nome, data e hora. Não pode haver pedidos duplicados.";
            IsPrivileged = true;
            Arguments = new Dictionary<string, string>()
            {
                { "-n", "trainer" },
                { "-d", "date" },
                { "-h", "hour" },
            };
            Pattern = @"^request\s{1}-n\s{1}(?<trainer>\w+)\s{1}-d\s{1}(?<date>\S*)\s{1}-h\s{1}(?<hour>\S*)$";
        }

        public bool Execute(string args, List<Request> requests, User activeUser)
        {
            Console.Clear();
            string name = args.Split()[2];
            string date = args.Split()[4];
            string hour = args.Split()[6];
            
            bool isValidDay = date.IsValidDay();
            bool isValidHour = hour.IsValidHour();

            DateTime requestDate = DateTime.Parse($"{date} {hour}");
            bool isValidDate = requestDate.IsValidDate(requests);

            if (!isValidDate)
                throw new ApplicationException("Período do pedido inválido.");

            Request newRequest = new Request
            {
                Id = requests.Count() == 0 ? 1 : requests.Max(r => r.Id) + 1,
                TrainerName = name,
                RequestDate = requestDate,
                RequestStatus = Request.EnumStatus.Agendado
            };

            // Classe Backend simula resposta do serviço de agendamento do ginásio
            bool success = Backend.ApproveRequest();

            if (success)
            {
                requests.Add(newRequest);
                activeUser.Requests.Add(newRequest);
            }

            return success;
        }

    }

}