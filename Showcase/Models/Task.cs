using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class ToDoList
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskMessage { get; set; }
        public bool Active { get; set; }
        DateTime Created { get; set; }
        public Project Project { get; set; }
    }
}