using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Showcase.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }

        [Required]
        public string CommentContent { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastUpdated { get; set; }
        public Post Post { get; set; }
        public Author Author { get; set; }

        [NotMapped]
        public int PostId { get; set; }

        [NotMapped]
        public int AuthorId { get; set; }

        public int? ParentCommentId { get; set; }

        [ForeignKey("ParentCommentId")]
        public virtual List<Comment> ChildComments { get; set; }

        public Comment()
        {
            ChildComments = new List<Comment>();
        }
    }
}