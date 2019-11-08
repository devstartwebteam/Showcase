using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class ToDoList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        [Required]
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskMessage { get; set; }
        public bool Active { get; set; }
        DateTime Created { get; set; }
        public Project Project { get; set; }
    }
}