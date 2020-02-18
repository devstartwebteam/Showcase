using Showcase.DataContexts;
using Showcase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Showcase.Interfaces;

namespace Showcase.Controllers
{
    public class BlogController : Controller
    {
        private BlogDb db = new BlogDb();
        private readonly IBlogPostRepo blogPostRepo;

        public BlogController(IBlogPostRepo blogPostRepo)
        {
            this.blogPostRepo = blogPostRepo;
        }

        // GET: Blog
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Post(string title)
        {
            Post vm = new Post();
            vm = blogPostRepo.GetBlogPost(title);

            if (vm == null)
            {
                ModelState.AddModelError("NullPost", "No post exists with that title");
                return RedirectToActionPermanent("NotFound", "Blog", null);
            }

            return View(vm);
        }

        [HttpGet]
        public ActionResult NotFound()
        {
            return View();
        }
    }
}