using System.Collections.Generic;
using System.Linq;

namespace RSGym_DAL
{

    public static class UserRepository
    {

        #region CRUD Methods

        public static User Create(this User user)
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

        #endregion

        #region Utility methods

        //public static string GetFormattedBook(this Book book)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine($"Id: {book.BookId}");
        //    sb.AppendLine($"Título: {book.Title}");
        //    sb.AppendLine($"ISBN: {book.ISBN}");
        //    sb.AppendLine($"Autor: {book.Author}");
        //    sb.AppendLine($"Editora: {PublisherRepository.GetPublisherById(book.PublisherId).Name}");

        //    if (book.PublishDate != null)
        //    {
        //        sb.AppendLine($"Publicado em: {book.PublishDate:MM/yyyy}");
        //    }

        //    sb.AppendLine("\n-------------------------------------------");

        //    return sb.ToString();
        //}

        #endregion

        #region Validation methods

        //public static Book ValidateBook(this Book book)
        //{

        //    if (!(book.Title.Length > 0 && book.Title.Length <= 100))
        //        throw new InvalidOperationException("Limite de 100 caracteres.");

        //    if (!(book.Author.Length > 0 && book.Author.Length <= 100))
        //        throw new InvalidOperationException("Limite de 100 caracteres.");


        //    if (!(book.ISBN.Length >= 10 && book.ISBN.Length <= 1))
        //        throw new InvalidOperationException("Limite de 13 caracteres.");

        //    if (PublisherRepository.GetPublisherById(book.PublisherId) is null)
        //        throw new InvalidOperationException("Editora incorreta.");

        //    return book;

        //}

        #endregion


    }

}
