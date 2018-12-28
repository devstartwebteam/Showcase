using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Showcase.Models;
using Showcase.Helpers;
using System.Threading.Tasks;
using Showcase.ViewModels;
using Showcase.DataContexts;

namespace Showcase.Controllers
{
    public class PostsController : Controller
    {
        private BlogDb db = new BlogDb();

        // GET: Posts
        public ActionResult Index()
        {
            return View(db.Posts.Include(p => p.Categories).ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,PostName,PostUrl,PostContent,ViewCount,InActive,Active")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,PostName,PostUrl,PostContent,ViewCount,InActive,Active")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Returns Posts for a given category
        public async Task<ActionResult> GetCategoryPosts(int Id)
        {
            DbHelper helper = new DbHelper();
            JsonResult posts = await helper.GetCategoryPostsAsync(Id);

            PostsViewModel model = new PostsViewModel()
            {
                postJson = posts
            };
            
            return View(model);
        }

        //Returns Posts for a given author
        public async Task<ActionResult> GetAuthorPosts(int Id)
        {
            DbHelper helper = new DbHelper();
            JsonResult posts = await helper.GetAuthorPostsAsync(Id);

            return View(posts);
        }

        //Returns Single Post Details
        public async Task<ActionResult> GetPostContent(int Id)
        {
            DbHelper helper = new DbHelper();
            JsonResult post = await helper.GetPostAsync(Id);

            return View(post);
        }

        //Get Categories for a given post
        public async Task<ActionResult> GetPostCategories(int Id)
        {
            DbHelper helper = new DbHelper();
            JsonResult categories = await helper.GetPostCategoriesAsync(Id);

            return View(categories);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
