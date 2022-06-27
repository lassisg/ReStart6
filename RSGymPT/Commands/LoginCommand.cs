using System;
using System.Collections.Generic;
using System.Linq;

namespace RSGymPT
{

    internal class LoginCommand : Command
    {

        public LoginCommand() : base()
        {
            Name = "login";
            HelpText = "Faz o login na aplicação.";
            IsPrivileged = false;
            Arguments = new Dictionary<string, string>()
            {
                { "-u", "username" },
                { "-p", "password" },
            };
            Pattern = @"^login\s{1}-u\s{1}(?<username>\w{1})\s{1}-p\s{1}(?<password>\w{1})$";
        }

        public bool Execute(string args, out User currentUser)
        {
            Console.Clear();
            string userName = args.Split()[2];
            string password = args.Split()[4];
            
            // 1. Valido se existe user
            currentUser = Repository
                .GetAllUsers()
                .FirstOrDefault(u => u.Name == userName && u.Password == password);

            currentUser.IsLoggedIn = User.EnumLogin.LoggedIn;

            // 2. Valido se Login foi bem sucedido
            bool success = !(currentUser is null);

            return success;
        }

    }

}
