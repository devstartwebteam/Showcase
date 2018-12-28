using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class MetaSEO
    {
        [Key]
        public int MetaId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string KeyWords { get; set; }
        public string OpenGraphImageUrl { get; set; }

        public string PageUrl { get; set; }
        public virtual Post PostId { get; set; }

    }
}