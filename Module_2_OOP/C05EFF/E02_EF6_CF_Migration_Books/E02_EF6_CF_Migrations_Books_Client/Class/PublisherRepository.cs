using E02_EF6_CF_Migrations_Books_DAL;

namespace E02_EF6_CF_Migrations_Books_Client
{

    static class PublishersDBClient
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



    }

}
