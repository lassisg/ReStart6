using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D02_EF6_CF
{
    internal static class PostController
    {

        #region Methods

        public static void Create(this Post post)
        {

            using (var db = new BlogContext())
            { 
                db.Post.Add(post);

                db.SaveChanges();
            }

        }

        public static List<Post> ListAllByBlogId(int blogId)
        {

            var blogPosts = new List<Post>();

            // Display all posts from a given blog in the database
            using (var db = new BlogContext())
            {
                Blog blog = db.Blog.FirstOrDefault(b => b.BlogId == blogId);
                
                Console.WriteLine($"\n\n------------------------------\nTodos os Posts do blog {blog.Name}\n------------------------------");
                blogPosts = db.Post
                    .Select(p => p)
                    .Where(p => p.BlogId == blog.BlogId)
                    .OrderBy(p => p.Title)
                    .ToList();
            }
            
            return blogPosts;

        }

        public static void ListAll()
        {

            // Display all posts from the database
            Console.WriteLine("\n\n------------------------------\nTodos os Posts\n------------------------------");
            using (var db = new BlogContext())
            {
                db.Post
                    .Select(p => p)
                    .OrderBy(p => p.Title)
                    .ToList()
                    .ForEach(p => Console.WriteLine($"{p.Title}\n{p.Content}"));
            }

        }

        #endregion

    }

}
