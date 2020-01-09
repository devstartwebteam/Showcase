using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class DashboardViewModel
    {
        public List<Post> Posts { get; set; }
        public List<Workout> Workouts { get; set; }
        public List<ToDoList> ToDoList { get; set; }
    }
}