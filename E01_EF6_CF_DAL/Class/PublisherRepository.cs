using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01_EF6_CF_DAL
{

    public static class PublisherRepository
    {

        #region Extended Methods

        public static void Create(this Publisher publisher)
        {

            using (var db = new LibraryContext())
            {
                db.Publisher.Add(publisher);

                db.SaveChanges();
            }

        }

        public static Publisher GetPublisherById(int publisherId)
        {
            var publisher = ListAll().FirstOrDefault(p => p.PublisherId == publisherId);

            return publisher;
        }

        public static List<Publisher> ListAll()
        {

            var allPublishers = new List<Publisher>();

            using (var db = new LibraryContext())
            {
                allPublishers = db.Publisher.Select(p => p).ToList();
            }

            return allPublishers;

        }

        #endregion

    }

}
