using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class PostImage
    {
        [Key, ForeignKey("Post")]
        public int PostImageId { get; set; }
        public byte[] Thumbnail { get; set; }
        public byte[] Slider { get; set; }
        public byte[] PageBody { get; set; }
        public byte[] PageBanner { get; set; }
        public virtual Post Post { get; set; }
    }
}