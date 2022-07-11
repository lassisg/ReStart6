using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D02_EF6_CF
{

    internal class Program
    {

        static void Main(string[] args)
        {

            using (var db = new BlogContext())
            {

                // Create and save a new Blog
                Console.Write("Digite o nome do novo blog: ");
                var name = Console.ReadLine();

                var blog = new Blog();

                blog.Name = name;

                db.Blog.Add(blog);
                
                db.SaveChanges();

                // Display all blgs from teh database
                var query = db.Blog.Select(b => b).OrderBy(b => b.Name);

                Console.WriteLine("\n\n------------------------------\nTodos os blogs\n------------------------------");

                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.ReadLine();

            }

        }

    }

}
