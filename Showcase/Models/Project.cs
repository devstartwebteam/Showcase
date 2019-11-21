using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        DateTime? Created { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<ToDoList> Tasks { get; set; }

        public Project()
        {
            Albums = new HashSet<Album>();
            Categories = new HashSet<Category>();
            Tags = new HashSet<Tag>();
            Tasks = new HashSet<ToDoList>();
        }
    }
}