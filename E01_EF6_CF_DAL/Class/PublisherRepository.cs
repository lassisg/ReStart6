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

        #endregion

        #region Methods

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

        #region User interaction methods

        public static Publisher GetNewPublisher()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------\nAdicionar editora (Enter para sair)\n----------------------------------");
            Console.Write("Digite o nome da editora: ");
            string userInput = Console.ReadLine();
            var publisher = new Publisher();
            publisher.Name = userInput;

            return publisher;
        }

        #endregion

    }

}
