using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class PostLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostLocationId { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }
        public string PostLocationName { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public int PostCount { get; set; }

        public PostLocation()
        {
            Posts = new HashSet<Post>();
            Categories = new HashSet<Category>();
            Tags = new HashSet<Tag>();
        }
    }
}