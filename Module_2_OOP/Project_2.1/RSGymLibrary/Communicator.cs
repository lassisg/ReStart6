using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RSGymLibrary
{

    public static class Communicator
    {

        public static void WriteSuccessMessage(this string message)
        {
            string separator = new String('-', 9);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{"SUCESSO:", -9}");
            Console.ResetColor();

            Console.WriteLine(message);

            Console.WriteLine($"{separator}\n");
        }

        public static void WriteWarningMessage(this string message)
        {
            string separator = new String('-', 7);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{"AVISO:", -7}");
            Console.ResetColor();

            Console.WriteLine(message);

            Console.WriteLine($"{separator}\n");
        }

        public static void WriteErrorMessage(this string message)
        {
            string separator = new String('-', 6);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{"ERRO:",-6}");
            Console.ResetColor();

            Console.WriteLine($"Não foi possível executar a operação solicitada.\n{"",-6}{message}");

            Console.WriteLine($"{separator}\n");
        }

        public static void WriteFeedbackMessage(this IRequest request, bool success)
        {
            StringBuilder message = new StringBuilder();

            if (!success)
            {
                message.Append("Pedido não foi aprovado pelo ginásio.");
                message.Append("Tente outro período ou ");
                message.AppendLine("entre em contacto por telefone ou email para fazer seu pedido.");
                message.ToString().WriteSuccessMessage();
            }
            else
            {
                message.Append($"Pedido {request.Id} ");
                message.Append($"criado para {request.RequestDate:dd/MM/yyyy HH:mm} ");
                message.Append($"com o treinador {request.TrainerName}.");
                message.ToString().WriteSuccessMessage();
            }
        }

    }

}
