using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using log4net;
using Showcase.DataContexts;
using Showcase.Interfaces;
using Showcase.Models;

namespace Showcase.Repos
{
    public class BlogPostRepo : IBlogPostRepo
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Post));
        private BlogDb db = new BlogDb();

        public Post GetBlogPost(string title)
        {
            Post post = new Post();
            List<Post> posts = new List<Post>();
            try
            {
                posts = db.Posts.Include(a => a.Comments).ToList();
                post = posts.FirstOrDefault(a => a.PostUrl.ToLower() == title);

            }
            catch (Exception e)
            {
                Logger.Error("Error getting post for home location", e);
            }
            finally
            {
                db.Dispose();
            }

            return post;

        }

        /*private Comment RecursiveLoad(Comment comment)
        {
            var ParentFromDatabase = _context.Entry(parent).Collection(d => d.Children);//Children are loaded, we can loop them now

            foreach (var child in parent.Children)
            {
                _context.Entry(child).Reference(d => d.OtherProperty).Load();
                RecursiveLoad(child);
            }
            return ParentFromDatabase;
        }*/
    }
}