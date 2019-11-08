using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }
        public string TagName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string TagDescription { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<PostLocation> PostLocations { get; set; }

        public Tag()
        {
            Posts = new HashSet<Post>();
            Projects = new HashSet<Project>();
            PostLocations = new HashSet<PostLocation>();
        }
    }
}