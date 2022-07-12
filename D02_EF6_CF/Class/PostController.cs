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

        public static Post GetPost(int postId)
        {

            var post = new Post();

            using (var db = new BlogContext())
            {
                post = db.Post
                    .FirstOrDefault(p => p.PostId == postId);
            }

            return post;

        }

        public static List<Post> ListAllByBlogId(int blogId)
        {

            var blogPosts = new List<Post>();

            using (var db = new BlogContext())
            {
                Blog blog = db.Blog.FirstOrDefault(b => b.BlogId == blogId);
                
                blogPosts = db.Post
                    .Select(p => p)
                    .Where(p => p.BlogId == blog.BlogId)
                    .OrderBy(p => p.Title)
                    .ToList();
            }
            
            return blogPosts;

        }

        public static List<Post> ListAll()
        {

            var allPosts = new List<Post>();

            using (var db = new BlogContext())
            {
                allPosts = db.Post
                    .Select(p => p)
                    .OrderBy(p => p.Title)
                    .ToList();
            }

            return allPosts;

        }

        #endregion

    }

}
