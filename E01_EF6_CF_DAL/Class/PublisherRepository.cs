using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01_EF6_CF_DAL
{

    public static class PublisherRepository
    {

        #region CRUD Methods

        public static Publisher Create(this Publisher publisher)
        {

            using (var db = new LibraryContext())
            {
                db.Publisher.Add(publisher);

                db.SaveChanges();
            }

            return publisher;
        }

        public static Publisher GetPublisherById(int publisherId)
        {
            var publisher = GetAllPublishers().FirstOrDefault(p => p.PublisherId == publisherId);

            return publisher;
        }

        public static List<Publisher> GetAllPublishers()
        {

            var allPublishers = new List<Publisher>();

            using (var db = new LibraryContext())
            {
                allPublishers = db.Publisher.Select(p => p).ToList();
            }

            return allPublishers;

        }

        #endregion

        #region Utility methods

        public static string GetFormattedPublisher(this Publisher publisher)
        {
            string formattedPublisher = $"{publisher.PublisherId} - {publisher.Name}";

            return formattedPublisher;
        }

        #endregion

        #region Validation methods

        public static Publisher ValidatePublisher(this Publisher publisher)
        {

            if (!(publisher.Name.Length > 0 && publisher.Name.Length <= 100))
                throw new InvalidOperationException("Limite de 100 caracteres.");

            return publisher;

        }

        #endregion

    }

}
