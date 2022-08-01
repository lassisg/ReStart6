using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{
    class AddRequestAction : IBaseAction
    {

        #region Properties

        public char Code { get; set; }

        public string Name { get; set; }

        public IUser User { get; set; }

        public MenuType MenuType { get; set; }

        public bool Success { get; set; }

        #endregion

        #region Contructor

        public AddRequestAction()
        {
            Code = '4';
            Name = "Add request";
            User = new GuestUser();
            MenuType = MenuType.Restricted;
        }

        #endregion

        #region Methods

        public void Execute(out bool isExit)
        {
            isExit = false;

            Console.Write("\nDigite a data desejada (no formato dd/MM/aaaa): ");
            string requestDate = this.ReadUserInput();

            Console.Write("\nDigite a hora desejada (no formato HH:mm): ");
            string requestHour = this.ReadUserInput();

            var trainers = TrainerRepository.GetAllTrainers();

            Console.WriteLine("\nSelecione o treinador:");
            trainers.ForEach(t => Console.WriteLine(t.ToString()));

            Console.Write("\nOpção selecionada: ");
            string trainerID = this.ReadUserInput();

            // ToDo: Validar data e hora (formatos e períodos)

            // ToDo: Simular resposta do ginásio


            var t1 = DateTime.Parse($"{requestDate:d}").Date;

            Request newRequest = new Request
            {
                TrainerID = int.Parse(trainerID),
                UserID = this.User.UserID,
                RequestDate = DateTime.Parse($"{requestDate:d}"),
                RequestHour = TimeSpan.Parse($"{requestHour:t}"),
                CreatedAt = DateTime.Now,
                Status = RequestStatus.Agendado
            };

            RequestRepository.Create(newRequest);
            Success = true;

            Console.Clear();

            var sb = new StringBuilder();
            sb.AppendLine("Novo pedido registado:");
            sb.Append(newRequest.ToString());

            Communicator.WriteSuccessMessage(sb.ToString());
        }

        #endregion

    }
}
