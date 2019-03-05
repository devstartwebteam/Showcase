using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class Workout
    {
        [Key]     
        public int WorkoutId { get; set; }
        [Display(Name = "Title")]
        public string WorkoutTitle { get; set; }
        [Display(Name = "Description")]
        public string WorkoutDescription { get; set; }
        [Display(Name = "Date")]
        public DateTime WorkoutDate { get; set; }
        [Display(Name = "Type")]
        public string WorkoutType { get; set; }
        [Display(Name = "Duration")]
        public string WorkoutLength { get; set; }
    }
}