using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class Photo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhotoId { get; set; }
        public string PhotoName { get; set; }
        public string PhotoURL { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdated { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase PhotoUpload { get; set; }
    }
}