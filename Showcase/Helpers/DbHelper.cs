using Showcase.DataContexts;
using Showcase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Showcase.Helpers
{
    public class DbHelper : Controller
    {
        private BlogDb PostDb = new BlogDb();
        public async Task<JsonResult> GetCategoryPostsAsync(int catId)
        {
            var postQuery = (from p in PostDb.Posts
                             where p.Categories.Any(c => c.CategoryId == catId)
                             select p);

            var posts = await postQuery.ToListAsync();
            return Json(posts, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetAuthorPostsAsync(int authId)
        {
            var authorQuery = (from p in PostDb.Posts
                             where p.Author.AuthorId == authId
                             select p);

            var posts = await authorQuery.ToListAsync();
            return Json(posts, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetPostCategoriesAsync(int postId)
        {
            var catQuery = (from c in PostDb.Categories
                             where c.CategoryId == postId
                             select c);

            List<Category> categories = await catQuery.ToListAsync();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetPostAsync(int? postId)
        {
            var postQuery = (from p in PostDb.Posts
                             where p.PostId == postId
                             select p);

            Post post = await postQuery.FirstOrDefaultAsync();
            return Json(post, JsonRequestBehavior.AllowGet);
        }
    }
}