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
            

            ICommand currentCommand;
            User activeUser = null;
            bool exitApplication = false;
            bool success = false;
            bool isValidCommand = false;
            string message = string.Empty;

            Console.Title = "RSGymPT";

            do
            {
                string loggedUser = (activeUser is null) ? "guest" : activeUser.Name.ToLower();

                Console.Write($"{loggedUser}> ");
                string userInput = Console.ReadLine();

                try
                {

                    currentCommand = Commands.GetCommandByName(userInput.Split()[0]);

                    switch (currentCommand)
                    {
                        case HelpCommand helpCommand:
                            isValidCommand = helpCommand.IsValid(userInput);
                            bool showRestricted = activeUser != null;
                            success = isValidCommand && helpCommand.Execute(userInput, Commands, showRestricted);
                            break;

                        case ExitCommand exitCommand:
                            isValidCommand = exitCommand.IsValid(userInput);
                            success = isValidCommand && exitCommand.Execute(userInput, out exitApplication);
                            break;

                        case LoginCommand login:
                            isValidCommand = login.IsValid(userInput);
                            if (!isValidCommand)
                                throw new ArgumentException("Parâmetros do comando incorretos.");

                            if (activeUser != null)
                                throw new UnauthorizedAccessException("Não foi possível efetuar o login. Já há um utilizador com sessão ativa.");

                            success = login.Execute(userInput, out activeUser);

                            if (!success)
                                throw new UnauthorizedAccessException("Utilizador ou palavra passe errado. Verifique os dados de login.");
                                
                            Utils.WriteSuccessMessage($"Seja bem vindo, {activeUser.Name}.");

                            break;

                        case RequestCommand request:
                            isValidCommand = request.IsValid(userInput);
                            if (!isValidCommand)
                                throw new ArgumentException("Parâmetros do comando incorretos.");

                            success = request.Execute(userInput, Requests, activeUser);

                            int lastId = Requests.Count();
                            Requests.FirstOrDefault(r => r.Id == lastId).WriteFeedbackMessage(success);

                            break;

                        case CancelCommand cancelCommand:
                            isValidCommand = cancelCommand.IsValid(userInput);
                            if (!isValidCommand)
                                throw new ArgumentException("Parâmetros do comando incorretos.");

                            Request requestToCancel = new Request();
                            success = isValidCommand && cancelCommand.Execute(userInput, activeUser.Requests, out requestToCancel);

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
                            isValidCommand = finishCommand.IsValid(userInput);
                            if (!isValidCommand)
                                throw new ArgumentException("Parâmetros do comando incorretos.");

                            Request requestToFinish = new Request();
                            success = isValidCommand && finishCommand.Execute(userInput, activeUser.Requests, out requestToCancel);

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
                            isValidCommand = messageCommand.IsValid(userInput);
                            if (!isValidCommand)
                                throw new ArgumentException("Parâmetros do comando incorretos.");

                            Request requestToMessage = new Request();
                            success = isValidCommand && messageCommand.Execute(userInput, activeUser.Requests, out requestToMessage);

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
                            isValidCommand = myRequestCommand.IsValid(userInput);
                            if (!isValidCommand)
                                throw new ArgumentException("Parâmetros do comando incorretos.");

                            Request requestToShow = new Request();
                            success = isValidCommand && myRequestCommand.Execute(userInput, activeUser.Requests);

                            if (!success)
                            {
                                message = "O pedido não foi localizado na sua lista de pedidos.";
                                Utils.WriteWarningMessage(message);
                            }

                            break;

                        case RequestsCommand requestsCommand:
                            isValidCommand = requestsCommand.IsValid(userInput);
                            if (!isValidCommand)
                                throw new ArgumentException("Parâmetros do comando incorretos.");

                            success = isValidCommand && requestsCommand.Execute(userInput, activeUser.Requests);

                            if (!success)
                            {
                                message = "O pedido não foi localizado na sua lista de pedidos.";
                                Utils.WriteWarningMessage(message);
                            }

                            break;

                        case LogoutCommand logoutCommand:
                            isValidCommand = logoutCommand.IsValid(userInput);
                            success = isValidCommand && logoutCommand.Execute(userInput);
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
                            isValidCommand = currentCommand.IsValid(userInput);
                            success = isValidCommand && currentCommand.Execute(userInput);
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
                    currentCommand = null;
                    message = string.Empty;
                }

            } while (!exitApplication);

        }
        
    }

}
