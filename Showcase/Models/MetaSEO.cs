using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class MetaSEO
    {
        [Key, ForeignKey("Post")]
        public int MetaPostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string KeyWords { get; set; }
        public string OpenGraphImageUrl { get; set; }
        public string PageUrl { get; set; }
        public Post Post { get; set; }
    }
}