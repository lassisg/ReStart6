using System;

namespace RSGym_Client
{

    public static class Communicator
    {

        public static void WriteSuccessMessage(this string message)
        {
            if (message != string.Empty)
            {
                string separator = new String('-', 9);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{"SUCESSO:",-9}");
                Console.ResetColor();

                Console.WriteLine("Operação realizada com sucesso.\n");

                string[] messageLines = message.Replace("\r\n", "\n").Split(Environment.NewLine.ToCharArray());
                for (int i = 0; i < messageLines.Length; i++)
                {
                    Console.WriteLine($"{"",-9}{messageLines[i]}");
                }

                Console.WriteLine($"{separator}\n"); 
            }
        }

        public static void WriteWarningMessage(this string message)
        {
            string separator = new String('-', 7);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{"AVISO:",-7}");
            Console.ResetColor();

            Console.WriteLine("Não foi possível executar a operação solicitada.\n");

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

            Console.WriteLine("Não foi possível executar a operação solicitada.\n");

            string[] messageLines = message.Replace("\r\n", "\n").Split(Environment.NewLine.ToCharArray());
            for (int i = 0; i < messageLines.Length; i++)
            {
                Console.WriteLine($"{"",-6}{messageLines[i]}");
            }

            Console.WriteLine($"{separator}\n");
        }

        public static IBaseAction WriteFeedbackMessage(this IBaseAction currentAction)
        {

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
