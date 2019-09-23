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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Post(int id)
        {
            Post vm = new Post();
            vm = db.Posts.FirstOrDefault(a => a.PostId == id);

            return View(vm);
        }
    }
}