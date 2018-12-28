using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string PostName { get; set; }
        public string PostUrl { get; set; }
        public string PostContent { get; set; }
        public int ViewCount { get; set; }
        public Boolean InActive { get; set; }
        public Boolean Active { get; set; }
        DateTime Created { get; set; }
        public virtual Template Template { get; set; }
        public Author Author { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<MetaSEO> MetaSEO { get; set; }

    }
}