using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D02_EF6_CF
{

    internal static class BlogController
    {

        #region Methods

        public static void Create(this Blog blog)
        {

            using (var db = new BlogContext())
            {
                db.Blog.Add(blog);

                db.SaveChanges();
            }

        }

        public static List<Blog> ListAll()
        {

            var allBlogs = new List<Blog>();

            using (var db = new BlogContext())
            {
                allBlogs = db.Blog
                    .Select(b => b)
                    .OrderBy(b => b.Name)
                    .ToList();
            }

            return allBlogs;

        }

        #endregion

    }

}
