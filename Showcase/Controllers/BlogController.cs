using Showcase.DataContexts;
using Showcase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Showcase.Controllers
{
    public class BlogController : Controller
    {
        private BlogDb db = new BlogDb();

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
            vm = db.Posts.FirstOrDefault(a => a.PostUrl == title.ToLower());

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