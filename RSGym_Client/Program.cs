using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{

    class Program
    {

        static void Main(string[] args)
        {

            Utils.SetUTF8Encoding();

            Utils.PrintHeader("ReStart Gym, O recomeço da sua saúde física!", "\n");

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
                        .UpdateParameters(menu, userOption, currentUser) // retorna IBaseAction
                        .ReadUserInput()                                 // retorna string do input
                        .ValidateInputFormat(out userOption)             // retorna char convertido do input
                        .ValidateInputOption(menu)                       // retorna IBaseAction, consoante char do método anterior
                        .UpdateUserInfo(currentUser, out currentUser)    // retorna IBaseAction
                        .ExecuteAction(out exitApp)                      // retorna IBaseAction
                        .UpdateUserInfo(currentUser, out currentUser)    // retorna IBaseAction
                        .SaveCurrentAction(userOption)                   // retorna IBaseAction
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

                    StringBuilder errors = new StringBuilder();

                    errors.AppendLine($"Erro na validação dos dados:\n");
                    errors.AppendLine($"{paramHeader.PadRight(paramLength)} | {inputHeader.PadRight(inputLength)} | {errorHeader}");
                    errors.AppendLine(e.GetFormattedDbExeption(paramLength, inputLength));

                    errors.ToString().WriteErrorMessage();

                }
                catch (InvalidOperationException e)
                {
                    string errorMessage = $"Verifique a opção selecionada.\n({e.Message})";
                    errorMessage.WriteErrorMessage();
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
