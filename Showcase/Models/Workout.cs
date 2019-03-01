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
        public string WorkoutTitle { get; set; }
        public string WorkoutDescription { get; set; }
        DateTime WorkoutDate { get; set; }
        public string WorkoutTpe { get; set; }
        public string WorkoutLength { get; set; }
    }
}