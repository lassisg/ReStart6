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

            List<Command> Commands = Repository.GetCommands();
            List<User> Users = Repository.GetAllUsers();
            List<Request> Requests = Repository.GetAllRequests();
            

            ICommand currCommand;
            User activeUser = null;
            bool exitApplication = false;
            bool success = false;
            bool isValid = false;
            string message = string.Empty;

            Console.Title = "RSGymPT";

            do
            {
                string loggedUser = (activeUser is null) ? "guest" : activeUser.Name.ToLower();

                Console.Write($"{loggedUser}> ");
                string userInput = Console.ReadLine();

                try
                {

                    currCommand = Commands.GetCommandByName(userInput.Split()[0]);

                    switch (currCommand)
                    {
                        case HelpCommand helpCommand:
                            isValid = helpCommand.IsValid(userInput);
                            bool showRestricted = activeUser != null;
                            success = isValid && helpCommand.Execute(userInput, Commands, showRestricted);
                            break;

                        case ExitCommand exitCommand:
                            isValid = exitCommand.IsValid(userInput);
                            success = isValid && exitCommand.Execute(userInput, out exitApplication);
                            break;

                        case LoginCommand login:
                            isValid = login.IsValid(userInput);
                            if (!isValid)
                                throw new ArgumentException("Parâmetros do comando incorretos.");

                            if (activeUser != null)
                                throw new UnauthorizedAccessException("Não foi possível efetuar o login. Já há um utilizador com sessão ativa.");

                            success = login.Execute(userInput, out activeUser);

                            if (!success)
                                throw new UnauthorizedAccessException("Utilizador ou palavra passe errado. Verifique os dados de login.");
                                
                            Utils.WriteSuccessMessage($"Seja bem vindo, {activeUser.Name}.");

                            break;

                        case RequestCommand request:
                            isValid = request.IsValid(userInput);
                            if (!isValid)
                                throw new ArgumentException("Parâmetros do comando incorretos.");

                            success = request.Execute(userInput, Requests, activeUser);

                            int lastId = Requests.Count();
                            Requests.FirstOrDefault(r => r.Id == lastId).WriteFeedbackMessage(success);

                            break;

                        case CancelCommand cancelCommand:
                            isValid = cancelCommand.IsValid(userInput);
                            if (!isValid)
                                throw new ArgumentException("Parâmetros do comando incorretos.");

                            Request requestToCancel = new Request();
                            success = isValid && cancelCommand.Execute(userInput, activeUser.Requests, out requestToCancel);

                            if (!success)
                            {
                                message = $"O pedido não foi localizado ou não está ativo.";
                                Utils.WriteWarningMessage(message);
                            }
                            else
                            {
                                Requests.First(r => r.Id == requestToCancel.Id).Cancel();
                                message = $"O pedido {requestToCancel.Id}, de {requestToCancel.RequestDate:dd/MM/yyyy HH:mm}, foi cancelado.";
                                Utils.WriteSuccessMessage(message);
                            }

                            break;

                        case FinishCommand finishCommand:
                            isValid = finishCommand.IsValid(userInput);
                            if (!isValid)
                                throw new ArgumentException("Parâmetros do comando incorretos.");

                            Request requestToFinish = new Request();
                            success = isValid && finishCommand.Execute(userInput, activeUser.Requests, out requestToCancel);

                            if (!success)
                            {
                                message = $"O pedido não foi localizado ou não está ativo.";
                                Utils.WriteWarningMessage(message);
                            }
                            else
                            {
                                message = $"O pedido {requestToFinish.Id}, de {requestToFinish.RequestDate:dd/MM/yyyy}, ";
                                message += $"foi finalizado em {requestToFinish.CompletedAt:dd/MM/yyyy HH:mm}.";
                                Utils.WriteSuccessMessage(message);
                            }

                            break;

                        case MessageCommand messageCommand:
                            isValid = messageCommand.IsValid(userInput);
                            if (!isValid)
                                throw new ArgumentException("Parâmetros do comando incorretos.");

                            Request requestToMessage = new Request();
                            success = isValid && messageCommand.Execute(userInput, activeUser.Requests, out requestToMessage);

                            if (!success)
                            {
                                message = "O pedido não foi localizado ou não está ativo.";
                                Utils.WriteWarningMessage(message);
                            }
                            else
                            {
                                message = $"O pedido {requestToMessage.Id}, de {requestToMessage.RequestDate}, ";
                                message += $"foi marcado como {requestToMessage.RequestStatus}, ";
                                message += $"em {requestToMessage.MessageAt:dd/MM/yyyy HH:mm}, com a mensagem:\n";
                                message += $"'{requestToMessage.Message}'.";
                                Utils.WriteSuccessMessage(message);
                            }

                            break;

                        case MyRequestCommand myRequestCommand:
                            isValid = myRequestCommand.IsValid(userInput);
                            if (!isValid)
                                throw new ArgumentException("Parâmetros do comando incorretos.");

                            Request requestToShow = new Request();
                            success = isValid && myRequestCommand.Execute(userInput, activeUser.Requests);

                            if (!success)
                            {
                                message = "O pedido não foi localizado na sua lista de pedidos.";
                                Utils.WriteWarningMessage(message);
                            }

                            break;

                        case RequestsCommand requestsCommand:
                            isValid = requestsCommand.IsValid(userInput);
                            if (!isValid)
                                throw new ArgumentException("Parâmetros do comando incorretos.");

                            success = isValid && requestsCommand.Execute(userInput, activeUser.Requests);

                            if (!success)
                            {
                                message = "O pedido não foi localizado na sua lista de pedidos.";
                                Utils.WriteWarningMessage(message);
                            }

                            break;

                        case LogoutCommand logoutCommand:
                            isValid = logoutCommand.IsValid(userInput);
                            success = isValid && logoutCommand.Execute(userInput);
                            activeUser = success ? null : activeUser;

                            break;

                        //case ClearCommand clearCommand:
                        //    isValid = clearCommand.IsValid(userInput);
                        //    success = isValid && clearCommand.Execute(userInput);
                        //    break;

                        //case InvalidCommand invalidCommand:
                        //    myApp.Commands.First(c => c.Name == "clear").Execute(userInput);
                        //    success = invalidCommand.Execute(userInput);
                        //    break;

                        default:
                            isValid = currCommand.IsValid(userInput);
                            success = isValid && currCommand.Execute(userInput);
                            break;
                    }

                }
                catch (UnauthorizedAccessException e)
                {
                    Utils.WriteErrorMessage(e.Message);
                    exitApplication = false;
                }
                catch (ArgumentException e)
                {
                    Utils.WriteErrorMessage(e.Message);
                    exitApplication = false;
                }
                catch (ApplicationException e)
                {
                    Utils.WriteErrorMessage(e.Message);
                    exitApplication = false;
                }
                catch (Exception e)
                {
                    Utils.WriteErrorMessage(e.Message);
                    exitApplication = false;
                }
                finally
                {
                    success = false;
                    currCommand = null;
                    message = string.Empty;
                }

            } while (!exitApplication);

        }
        
    }

}
