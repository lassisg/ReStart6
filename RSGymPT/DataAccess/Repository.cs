using System.Collections.Generic;
using System.Linq;

namespace RSGymPT
{

    internal static class Repository
    {

        internal static List<User> GetAllUsers()
        {
            List<User> users = new List<User>
            {
                new User(1, "1", "1", new List<Request>(), User.EnumLogin.NotLoggedIn),
                new User(2, "2", "2", new List<Request>(), User.EnumLogin.NotLoggedIn)
            };

            return users;
        }

        internal static List<Request> GetAllRequests()
        {
            List<Request> requests = new List<Request>();

            return requests;
        }

        internal static List<Command> GetCommands()
        {
            List<Command> commands = new List<Command>()
            {
                new HelpCommand(),
                new ExitCommand(),
                new ClearCommand(),
                new LoginCommand(),
                new LogoutCommand(),
                new RequestCommand(),
                new CancelCommand(),
                new FinishCommand(),
                new MessageCommand(),
                new MyRequestCommand(),
                new RequestsCommand()
            };

            return commands;
        }

    }

}
