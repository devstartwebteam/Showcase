using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class Template
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TemplateId { get; set; }
        [Required]
        public string TemplateName { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }

        public Template()
        {
            Posts = new HashSet<Post>();
        }
    }
}