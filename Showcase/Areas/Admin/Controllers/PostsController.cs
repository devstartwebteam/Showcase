using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Showcase.Models;
using Showcase.Helpers;
using System.Threading.Tasks;
using Showcase.ViewModels;
using Showcase.DataContexts;
using Showcase.Interfaces;
using ShowcaseResources;

namespace Showcase.Areas.Admin.Controllers
{
    [Authorize]
    [RouteArea("Admin", AreaPrefix = "Admin")]
    public class PostsController : Controller
    {
        private readonly IBlogAdminRepo blogAdminRepo;
        private BlogDb db = new BlogDb();

        public PostsController(IBlogAdminRepo blogAdminRepo)
        {
            this.blogAdminRepo = blogAdminRepo;
        }

        // GET: Posts
        [HttpGet]
        public ActionResult Index()
        {
            List<Post> posts = blogAdminRepo.GetAllPosts();

            if (!posts.Any())
            {
                ModelState.AddModelError("", Resources.GetAllPostsFailed);
                return View();
            }

            return View(posts);
        }

        // GET: Posts/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Post post = blogAdminRepo.GetPostDetails(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        [HttpGet]
        public ActionResult Create()
        {
            Post post = new Post();
            post = blogAdminRepo.GetNewPost(post);

            if (post == null)
            {
                ModelState.AddModelError(string.Empty, Resources.GetPostFailed);
            }

            return View(post);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,PostName,PostUrl,PostImageUpload,PostContent,ViewCount,Active,AuthorId,SelectedCategoryIds,SelectedLocationIds")] Post vm)
        {
            if (ModelState.IsValid)
            {
                bool success = blogAdminRepo.CreateNewPost(vm);

                if (success)
                {
                    TempData["StatusType"] = Resources.StatusSuccess;
                    TempData["StatusMessage"] = Resources.CreatePostSuccess;

                    return RedirectToAction("Index");
                }

                TempData["StatusType"] = Resources.StatusFailed;
                TempData["StatusMessage"] = Resources.CreatePostFailed;

                return View();
            }

            ModelState.AddModelError(string.Empty, Resources.CreatePostFailed);
            return View(vm);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Post post = db.Posts.Include(a => a.Author).FirstOrDefault(a => a.PostId == id);
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
                post.GetImageBytes(post.PostImageUpload);
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
