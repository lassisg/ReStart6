using System.Collections.Generic;
using System.Linq;

namespace RSGym_DAL
{

    public static class UserRepository
    {

        public static User CreateUser(this User user)
        {

            using (var context = new GymDbContext())
            {
                context.User.Add(user);

                context.SaveChanges();
            }

            return user;
        }

        public static User GetUserById(int userId)
        {

            User user;

            using (var context = new GymDbContext())
            {
                user = context.User.FirstOrDefault(u => u.UserID == userId);
            }

            return user;

        }

        public static List<User> GetAllUsers()
        {

            var allUsers = new List<User>();

            using (var context = new GymDbContext())
            {
                allUsers = context.User.Select(u => u).ToList();
            }

            return allUsers;

        }

    }

}
