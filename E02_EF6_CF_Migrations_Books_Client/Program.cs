using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E02_EF6_CF_Migrations_Books_Client
{

    class Program
    {

        static void Main(string[] args)
        {

            PublishersDBClient.CreatePublisher();
            BooksDBClient.CreateBook();

            Console.WriteLine("Data entered successfully.");

            Console.ReadKey();

        }

    }

}
