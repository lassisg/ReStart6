using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace RSGym_Client
{

    class Program
    {

        static void Main(string[] args)
        {

            Utils.SetUTF8Encoding();

            Utils.PrintHeader("ReStart Gym, O recomeço da sua saúde física!", linesAfter: "\n");

            IMenu menu;
            IUser currentUser = new GuestUser();
            IBaseAction currentAction = new BasicAction();
            char userOption = '0';
            bool exitApp = false;

            do
            {

                try
                {

                    Console.Title = $"RSGymPT | {currentUser.Username}";

                    menu = MenuRepository.GetMenu(currentUser, currentAction);
                    menu.Show();

                    currentAction = currentAction
                        .UpdateParameters(menu, userOption, currentUser)
                        .ReadUserInput()
                        .ValidateInputFormat(out userOption)
                        .ValidateInputOption(menu)
                        .UpdateUserInfo(currentUser, out currentUser)
                        .ExecuteAction(out exitApp)
                        .UpdateUserInfo(currentUser, out currentUser)
                        .SaveCurrentAction(userOption)
                        .WriteFeedbackMessage();

                }
                catch (DbEntityValidationException e)
                {

                    string paramHeader = "Dado de entrada";
                    string inputHeader = "Valor inserido";
                    string errorHeader = "Erro";

                    e.GetDbExeptionColumnLengths(out int paramLength, out int inputLength);
                    paramLength = Math.Max(paramLength, paramHeader.Length);
                    inputLength = Math.Max(inputLength, inputHeader.Length);
                    
                    List<string> formattedError = e.GetFormattedDbExeption(paramLength, inputLength)
                        .Split(Environment.NewLine.ToCharArray())
                        .Where(x => x != string.Empty).ToList();

                    int formattedErrorLength = formattedError.Max(x => x.Split('|')[2].Trim().Length);

                    StringBuilder errors = new StringBuilder();

                    errors.AppendLine($"Erro na validação dos dados:\n");
                    errors.AppendLine($"{paramHeader.PadRight(paramLength)} | {inputHeader.PadRight(inputLength)} | {errorHeader}");
                    errors.Append($"{new string('-', paramLength)} | {new string('-', inputLength)} | {new string ('-', formattedErrorLength)}");

                    formattedError.ForEach(x => errors.Append($"\n{x}"));

                    errors.ToString().WriteErrorMessage();

                }
                catch (InvalidOperationException e)
                {
                    string errorMessage = $"Verifique a opção selecionada.\n({e.Message})";
                    errorMessage.WriteErrorMessage();
                }
                catch (ApplicationException e)
                {
                    e.Message.WriteWarningMessage();
                }
                catch (Exception e)
                {
                    e.Message.WriteErrorMessage();
                }

            } while (!exitApp);

            Utils.PrintHeader("Aguardamos seu breve retorno! Recomece conosco!");
            Console.ReadKey();

        }

    }

}
