using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSGymLibrary;

namespace RSGymConsoleUI
{

    internal class Program
    {

        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;

            List<IBaseCommand> Commands = CommandProcessor.GetCommands();

            IBaseCommand currentCommand = new GeneralCommand(new GuestUser());
            IUser currentUser = currentCommand.CurrentUser;

            Console.Title = "RSGymPT";

            bool exitApplication = false;
            do
            {
                Console.Write($"{currentUser.Name.ToLower()}> ");
                string userInput = Console.ReadLine();

                try
                {
                    currentCommand = Commands.FirstOrDefault(c => c.Name == userInput.Split()[0]) ?? new GeneralCommand(new GuestUser());
                    currentCommand.CurrentUser = currentUser;

                    currentCommand.HasValidSession()
                                  .HasValidCommandPattern(userInput)
                                  .HasValidArgumentsPattern(userInput)
                                  .LoadArgumentValues(userInput, out Dictionary<string, string> inputArguments)
                                  .ExecuteCommand(inputArguments, out exitApplication)
                                  .LogoutOnExit(exitApplication)
                                  .UpdateUserInfo(currentUser, out currentUser)
                                  .UpdateUsers()
                                  .UpdateRequests();
                }
                catch (Exception ex)
                {
                    ex.Message.WriteErrorMessage();
                }

            } while (!exitApplication);
            

            Console.ReadLine();

        }
    }
}
