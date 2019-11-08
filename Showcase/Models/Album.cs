using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public List<Photo> Photos { get; set; }
        public Project Project { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}