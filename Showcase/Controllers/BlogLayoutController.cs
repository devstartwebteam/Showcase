using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Showcase.DataContexts;
using Showcase.Interfaces;
using Showcase.Models;

namespace Showcase.Controllers
{
    public class BlogLayoutController : Controller
    {
        private readonly IBlogLocationRepo blogLocationRepo;

        public BlogLayoutController(IBlogLocationRepo blogLocationRepo)
        {
            this.blogLocationRepo = blogLocationRepo;
        }

        [HttpGet]
        public ActionResult _HomeTopCarousel(string name)
        {
            PostLocation contentArea = blogLocationRepo.GetHomePostLocation(name);
            
            return View(contentArea);
        }

        [HttpGet]
        public ActionResult _HomeMainCarousel(string name)
        {
            PostLocation contentArea = blogLocationRepo.GetHomePostLocation(name);
            return View(contentArea);
        }

        [HttpGet]
        public ActionResult _HomeBottom(string name)
        {
            PostLocation contentArea = blogLocationRepo.GetHomePostLocation(name);
            return View(contentArea);
        }

        [HttpGet]
        public ActionResult _BlogSideBar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _BlogSideColumn(string name)
        {
            PostLocation contentArea = blogLocationRepo.GetHomePostLocation(name);
            return View(contentArea);
        }

        [HttpGet]
        public ActionResult _BlogSideCategories(string name)
        {
            PostLocation contentArea = blogLocationRepo.GetHomePostLocation(name);
            return View(contentArea);
        }

        [HttpGet]
        public ActionResult _BlogSideTags(string name)
        {
            PostLocation contentArea = blogLocationRepo.GetHomePostLocation(name);
            return View(contentArea);
        }


    }
}