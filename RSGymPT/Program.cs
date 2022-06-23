using System;
using System.Collections.Generic;
using System.Linq;

namespace RSGymPT
{

    internal class Program
    {

        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            CLI myApp = new CLI();
            bool exitApplication;

            Console.Title = "RSGymPT";

            do
            {
                string loggedUser = (myApp.ActiveUser is null) ? "guest" : myApp.ActiveUser.UserName.ToLower();
                
                Console.Write($"{loggedUser}> ");
                string userInput = Console.ReadLine();

                try
                {
                    // Fiz split no '-' porque me permite separar o comando no índice 0
                    //   - As opções estarão nos índices seguintes (quando houver)
                    string[] appCommands = userInput
                        .Split('-')
                        .Select(c => c.Trim())
                        .ToArray();

                    switch (appCommands[0])
                    {
                        case "help":
                            exitApplication = RunCommandWithoutArgs(myApp.Help);
                            break;

                        case "exit":
                            exitApplication = RunCommandWithoutArgs(myApp.Exit);
                            break;

                        case "clear":
                            exitApplication = RunCommandWithoutArgs(myApp.Clear);
                            break;

                        case "login":
                            //exitApplication = RunCommandWithArgs(arguments, argumentId, myApp.Login);
                            exitApplication = myApp.Login(appCommands);
                            break;

                        case "logout":
                            exitApplication = RunCommandWithoutArgs(myApp.Logout);
                            break;

                        case "request":
                            exitApplication = RunCommandWithArgs(appCommands, myApp.CreateRequest);
                            break;

                        case "cancel":
                            exitApplication = RunCommandWithArgs(appCommands, myApp.CancelRequest);
                            break;

                        case "finish":
                            exitApplication = RunCommandWithArgs(appCommands, myApp.FinishRequest);
                            break;

                        case "message":
                            exitApplication = RunCommandWithArgs(appCommands, myApp.SendMessage);
                            break;

                        case "myrequest":
                            exitApplication = RunCommandWithArgs(appCommands, myApp.GetRequest);
                            Console.WriteLine();
                            break;

                        case "requests":
                            exitApplication = RunCommandWithArgs(appCommands, myApp.ListRequests);
                            Console.WriteLine();
                            break;

                        default:
                            exitApplication = RunCommandWithoutArgs(myApp.Help);
                            break;
                    }

                }
                catch (UnauthorizedAccessException e)
                {
                    WriteErrorMessage(e.Message);
                    exitApplication = false;
                }
                catch (ArgumentException e)
                {
                    WriteErrorMessage(e.Message);
                    exitApplication = false;
                }
                catch (ApplicationException e)
                {
                    WriteErrorMessage(e.Message);
                    exitApplication = false;
                }
                catch (Exception e)
                {
                    WriteErrorMessage(e.Message);
                    exitApplication = false;
                }

            } while (!exitApplication);

        }

        public delegate bool RunTheCommandWithArgs(string[] args);

        public delegate bool RunTheCommandWithoutArgs();

        public static bool RunCommandWithArgs(string[] args, RunTheCommandWithArgs operation)
        {
            bool result = operation(args);

            return result;
        }

        public static bool RunCommandWithoutArgs(RunTheCommandWithoutArgs operation)
        {
            bool result = operation();

            return result;
        }

        //internal static bool Run(CLI app, string[] args)
        //{
        //    bool isExit = false;
        //    Dictionary<CLI.EnumArgumentType, string> arguments = new Dictionary<CLI.EnumArgumentType, string>();

        //    switch (args[0])
        //    {
        //        case "help":
        //            app.Help();
        //            break;

        //        case "exit":
        //            isExit = app.Exit(); ;
        //            break;

        //        case "clear":
        //            app.Clear();
        //            break;

        //        case "login":
        //            app.Login(args);
        //            break;

        //        case "logout":
        //            app.Logout();
        //            break;

        //        case "request":
        //            app.CreateRequest(arguments);
        //            break;

        //        case "cancel":
        //            app.CancelRequest(arguments);
        //            break;

        //        case "finish":
        //            app.FinishRequest(arguments);
        //            break;

        //        case "message":
        //            app.SendMessage(arguments);
        //            break;

        //        case "myrequest":
        //            app.GetRequest(arguments, int.Parse(arguments.Values.ElementAt(0)));
        //            Console.WriteLine();
        //            break;

        //        case "requests":
        //            app.ListRequests(arguments);
        //            Console.WriteLine();
        //            break;

        //        default:
        //            app.Help();
        //            break;
        //    }

        //    return isExit;
        //}

        private static void WriteErrorMessage(string message)
        {
            string separator = new String('-', 7);

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\nERRO:");
            
            Console.ResetColor();
            
            Console.WriteLine(message);
            
            Console.WriteLine($"{separator}\n");
        }

    }

}
