using System;

namespace D03_EF6_CF_Migrations_Books_Client
{

    class Program
    {

        static void Main(string[] args)
        {

            for (int i = 0; i < 3; i++)
            {
                PublisherRepository.CreatePublisher();
            }
            BookRepository.CreateBook();

            Utility.WriteTitle("CREATE", "", "\n");
            PublisherRepository.ReadPublisher();
            BookRepository.ReadBook();

            Utility.WriteTitle("UPDATE", "\n\n\n", "\n");
            PublisherRepository.UpdatePublisher();
            PublisherRepository.ReadPublisher();
            BookRepository.ReadBook();

            Utility.WriteTitle("DELETE", "\n\n\n", "\n");
            PublisherRepository.DeletePublisher();
            PublisherRepository.ReadPublisher();
            BookRepository.ReadBook();

            Console.ReadKey();

        }

    }

}
