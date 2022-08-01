using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{
    class GetRequestsByStatusAction : IBaseAction
    {

        #region Properties

        public char Code { get; set; }

        public string Name { get; set; }

        public IUser User { get; set; }

        public MenuType MenuType { get; set; }

        public bool Success { get; set; }

        #endregion

        #region Contructor

        public GetRequestsByStatusAction()
        {
            Code = '2';
            Name = "Get request count grouped by status";
            User = new GuestUser();
            MenuType = MenuType.Statistical;
        }

        #endregion

        #region Methods

        public void Execute(out bool isExit)
        {
            isExit = false;

            var requests = RequestRepository.GetRequestsByStatus();

            Success = true;

            Console.Clear();

            Utils.PrintSubHeader("Lista de pedidos agrupados por estado");
            int statusLength = requests.ToList().Select(r => r.Key.Length).Max();

            Console.WriteLine($"\n{"Status".PadRight(statusLength)} | Nº de pedidos");
            Console.WriteLine($"{new String('-', statusLength)}-+--------------");
            requests.ToList().ForEach(s => Console.WriteLine($"{s.Key.PadRight(statusLength)} | {s.Value}"));

            Console.WriteLine();
            
        }

        #endregion

    }
}
