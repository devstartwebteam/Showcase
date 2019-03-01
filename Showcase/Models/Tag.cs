using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public string TagName { get; set; }
        public string TagDescription { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}