using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class Workout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkoutId { get; set; }
        [Display(Name = "Title")]
        [Required]
        public string WorkoutTitle { get; set; }
        [Display(Name = "Description")]
        public string WorkoutDescription { get; set; }
        [Display(Name = "Date")]
        [Required]
        public DateTime WorkoutDate { get; set; }
        [Display(Name = "Type")]
        public string WorkoutType { get; set; }
        [Display(Name = "Duration")]
        public string WorkoutLength { get; set; }
        [Display(Name = "Miles")]
        public decimal WorkoutDistance { get; set; }
    }
}