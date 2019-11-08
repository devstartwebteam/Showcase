using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<PostLocation> PostLocations { get; set; }

        public Category()
        {
            Posts = new HashSet<Post>();
            Projects = new HashSet<Project>();
            PostLocations = new HashSet<PostLocation>();
        }
    }
}