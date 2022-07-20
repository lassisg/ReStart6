using D03_EF6_CF_Migrations_Books_DAL;
using System;
using System.Linq;

namespace D03_EF6_CF_Migrations_Books_Client
{

    // -------
    // CRUD
    // -------

    static class PublisherRepository
    {

        public static void CreatePublisher()
        {

            var publisher = new Publisher
            {
                Name = "New publisher"
            };

            using (var context = new BooksDBContext())
            {
                context.Publisher.Add(publisher);
                context.SaveChanges();

            }

        }

        public static void ReadPublisher()
        {

            using (var context = new BooksDBContext())
            {

                var query = context.Publisher.Select(p => p).OrderBy(p => p.PublisherID);

                Utility.WriteSubtitle("Publishers", "\n", "\n-----------------------");

                query.ToList().ForEach(p => Console.WriteLine($"{p.PublisherID} - {p.Name}"));

            }

        }

        public static void UpdatePublisher()
        {

            using (var context = new BooksDBContext())
            {

                var result = context.Publisher.SingleOrDefault(p => p.PublisherID == 2);

                if (result != null)
                {
                    result.Name = "Updated publisher";
                    context.SaveChanges();
                }

            }

        }

        public static void DeletePublisher()
        {

            using (var context = new BooksDBContext())
            {

                var result = context.Publisher.SingleOrDefault(p => p.PublisherID == 3);

                if (result != null)
                {
                    context.Publisher.Remove(result);   // Eliminação em cascata: de 1 para n
                    context.SaveChanges();
                }

            }

        }

    }

}