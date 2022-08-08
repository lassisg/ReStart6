using System.Collections.Generic;
using System.Linq;

namespace RSGym_DAL
{

    public static class UserRepository
    {

        public static List<User> GetAllUsers()
        {

            var allUsers = new List<User>();

            using (var context = new GymDbContext())
            {
                allUsers = context.User.ToList();
            }

            return allUsers;

        }

    }

}
