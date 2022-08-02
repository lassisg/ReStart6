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
            // ToDo: Extract code to othe method
            isExit = false;

            Console.Clear();
            Utils.PrintSubHeader("Lista de pedidos realizados");

            List<Request> requests = RequestRepository.GetRequestsByUserID(this.User.UserID);

            string requestHeader = requests.GetHeader(out int trainerLength, out int statusLength, out int messageLength);
            Console.WriteLine(requestHeader);

            requests.ForEach(r => Console.WriteLine(r.ToString(trainerLength, statusLength, messageLength)));

            Console.WriteLine();

            Success = true;
        }

        #endregion

    }
}
