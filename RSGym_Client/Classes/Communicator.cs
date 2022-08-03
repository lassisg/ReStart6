using RSGym_DAL;
using System;
using System.Text;

namespace RSGym_Client
{

    public static class Communicator
    {

        public static void WriteSuccessMessage(this string message)
        {
            string separator = new String('-', 9);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{"SUCESSO:",-9}");
            Console.ResetColor();

            Console.WriteLine($"Operação realizada com sucesso.");

            string[] messageLines = message.Replace("\r\n", "\n").Split(Environment.NewLine.ToCharArray());
            for (int i = 0; i < messageLines.Length; i++)
            {
                Console.WriteLine($"{"",-9}{messageLines[i]}");
            }

            Console.WriteLine($"{separator}\n");
        }

        public static void WriteWarningMessage(this string message)
        {
            string separator = new String('-', 7);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{"AVISO:",-7}");
            Console.ResetColor();

            Console.WriteLine($"{"",-7}{message}");

            string[] messageLines = message.Replace("\r\n", "\n").Split(Environment.NewLine.ToCharArray());
            for (int i = 0; i < messageLines.Length; i++)
            {
                Console.WriteLine($"{"",-7}{messageLines[i]}");
            }

            Console.WriteLine($"{separator}\n");
        }

        public static void WriteErrorMessage(this string message)
        {
            string separator = new String('-', 6);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{"ERRO:",-6}");
            Console.ResetColor();

            Console.WriteLine($"Não foi possível executar a operação solicitada.");

            string[] messageLines = message.Replace("\r\n", "\n").Split(Environment.NewLine.ToCharArray());
            for (int i = 0; i < messageLines.Length; i++)
            {
                Console.WriteLine($"{"",-6}{messageLines[i]}");
            }

            Console.WriteLine($"{separator}\n");
        }

        public static IBaseAction WriteFeedbackMessage(this IBaseAction currentAction)
        {
            //StringBuilder message = new StringBuilder();

            //if (!success)
            //{
            //    message.Append("Pedido não foi aprovado pelo ginásio.");
            //    message.Append("Tente outro período ou ");
            //    message.AppendLine("entre em contacto por telefone ou email para fazer seu pedido.");
            //    message.ToString().WriteSuccessMessage();
            //}
            //else
            //{
            //    message.Append($"Pedido {request.RequestID} ");
            //    message.Append($"criado para {request.RequestDate:dd/MM/yyyy HH:mm} ");
            //    message.Append($"com o treinador {request.Trainer.Name}.");
            //    message.ToString().WriteSuccessMessage();
            //}
            if (currentAction.Success)
            {
                WriteSuccessMessage(currentAction.FeedbackMessage);
            }
            else
            {
                WriteErrorMessage(currentAction.FeedbackMessage);
            }

            return currentAction;

        }

    }

}
