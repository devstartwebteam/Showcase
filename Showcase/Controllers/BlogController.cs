using Showcase.DataContexts;
using Showcase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Showcase.Interfaces;
using Showcase.ViewModels;

namespace Showcase.Controllers
{
    public class BlogController : Controller
    {
        private BlogDb db = new BlogDb();
        private readonly IBlogPostRepo blogPostRepo;
        private readonly IInstagramRepo instagramRepo;

        public BlogController(IBlogPostRepo blogPostRepo, IInstagramRepo instagramRepo)
        {
            this.blogPostRepo = blogPostRepo;
            this.instagramRepo = instagramRepo;
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
        [OutputCache(Duration = 10000)]
        public ActionResult _InstagramPartial()
        {
            List<InstagramImage> images = new List<InstagramImage>();
            images = instagramRepo.GetInstagramImages();
            return View(images);
        }

        [HttpGet]
        public ActionResult NotFound()
        {
            return View();
        }
    }
}