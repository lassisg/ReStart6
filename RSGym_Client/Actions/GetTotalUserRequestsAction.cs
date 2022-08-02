using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{
    class GetTotalUserRequestsAction : IBaseAction
    {

        #region Properties

        public char Code { get; set; }

        public string Name { get; set; }

        public IUser User { get; set; }

        public MenuType MenuType { get; set; }

        public bool Success { get; set; }

        #endregion

        #region Contructor

        public GetTotalUserRequestsAction()
        {
            Code = '1';
            Name = "Get request count for current user";
            User = new GuestUser();
            MenuType = MenuType.Statistical;
        }

        #endregion

        #region Methods

        public void Execute(out bool isExit)
        {
            isExit = false;

            var requests = RequestRepository.GetTotalRequestsByUserID(this.User.UserID);

            Success = true;

            Console.Clear();

            Utils.PrintSubHeader($"Total de pedidos realizados");

            Console.Write($"\nO total de pedidos em seu nome é: {requests}\n");
            
            Console.WriteLine();
            
        }

        #endregion

    }
}
