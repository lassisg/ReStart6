using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{
    class ListRequestAction : IBaseAction
    {

        #region Properties

        public char Code { get; set; }

        public string Name { get; set; }

        public IUser User { get; set; }

        public MenuType MenuType { get; set; }

        public bool Success { get; set; }

        #endregion

        #region Contructor

        public ListRequestAction()
        {
            Code = '9';
            Name = "List all requests";
            User = new GuestUser();
            MenuType = MenuType.Restricted;
        }

        #endregion

        #region Methods

        public void Execute(out bool isExit)
        {
            isExit = false;

            Console.Clear();
            Utils.PrintSubHeader("Lista de pedidos realizados");

            List<Request> requests = RequestRepository.GetRequestsByUserID(this.User.UserID);

            string dateHourHeader = "Data e hora";
            int dateHourLength = 16;

            string trainerHeader = "Personal Trainer";
            int trainerLength = requests.Select(r => r.Trainer).ToList().Select(x => x.Name.Length).Max() + 8;

            string statusHeader = "Status";
            int statusLength = requests.Select(r => r.Status.ToString().Length).Max();
            statusLength += requests.Any(r => r.Status == RequestStatus.Concluido) ? 33 : 0;

            bool hasMessage = requests.Any(r => r.Message != null);
            string messageHeader = "Mensagem";
            int messageLength = 0;

            StringBuilder header = new StringBuilder();
            StringBuilder headerLine = new StringBuilder();

            header.Append("\nNº | ");
            header.Append($"{dateHourHeader.PadRight(dateHourLength)} | ");
            header.Append($"{trainerHeader.PadRight(trainerLength)} | ");
            header.Append($"{statusHeader.PadRight(statusLength)}");

            headerLine.Append("---+-");
            headerLine.Append($"{new String('-', dateHourLength)}-+-");
            headerLine.Append($"{new String('-', trainerLength)}-+-");
            headerLine.Append($"{new String('-', statusLength)}");

            if (hasMessage) 
            { 
                messageLength = requests.Where(r => r.Message != null).Select(r => r.Message.Length).Max();
                header.Append($" | {messageHeader.PadRight(messageLength)}");
                headerLine.Append($"-+-{new String('-', messageLength)}");
            }
            
            Console.WriteLine(header.ToString());
            Console.WriteLine(headerLine.ToString());

            requests.ForEach(r => Console.WriteLine(r.ToString(trainerLength, statusLength, messageLength)));

            Console.WriteLine();

            Success = true;
        }

        #endregion

    }
}
