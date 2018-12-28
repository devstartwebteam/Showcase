using Showcase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Showcase.ViewModels
{
    public class PostsViewModel
    {
        public int PostId { get; set; }
        public string PostName { get; set; }
        public string PostContent { get; set; }
        public int ViewCount { get; set; }
        public string AuthorName { get; set; }

        public List<Category> Categories { get; set; }
        public List<Tag> Tags { get; set; }
        public MetaSEO SEO { get; set; }

        public JsonResult postJson { get; set; }
    }
}