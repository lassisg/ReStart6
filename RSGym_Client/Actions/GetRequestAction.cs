using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{
    class GetRequestAction : IBaseAction
    {

        #region Properties

        public char Code { get; set; }

        public string Name { get; set; }

        public IUser User { get; set; }

        public MenuType MenuType { get; set; }

        public bool Success { get; set; }

        #endregion

        #region Contructor

        public GetRequestAction()
        {
            Code = '5';
            Name = "Get request";
            User = new GuestUser();
            MenuType = MenuType.Restricted;
        }

        #endregion

        #region Methods

        public void Execute(out bool isExit)
        {
            isExit = false;

            // ToDo: Add validation
            Console.Write("\nDigite o nº do pedido que deseja consultar: ");
            string requestID = this.ReadUserInput();

            var request = RequestRepository.GetRequestById(int.Parse(requestID));
            Success = true;

            Console.Clear();

            Utils.PrintSubHeader($"Informações sobre o pedido nº {requestID}");

            List<Request> requests = new List<Request>
            {
                request
            };

            string requestHeader = requests.GetHeader(out int trainerLength, out int statusLength, out int messageLength);

            Console.WriteLine(requestHeader);
            requests.ForEach(r => Console.WriteLine(r.ToString(trainerLength, statusLength, messageLength)));

            Console.WriteLine();
            
        }

        #endregion

    }
}
