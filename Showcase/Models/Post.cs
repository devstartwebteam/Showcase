using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Showcase.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Display(Name = "Post Name")]
        public string PostName { get; set; }

        [Display(Name = "Post Url")]
        public string PostUrl { get; set; }

        public byte[] PostImage { get; set; }

        [NotMapped]
        [Display(Name = "Featured Image")]
        public HttpPostedFileBase PostImageUpload { get; set; }

        [AllowHtml]
        public string PostContent { get; set; }
        public int ViewCount { get; set; }
        public bool InActive { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public virtual Template Template { get; set; }
        public Author Author { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<MetaSEO> MetaSEO { get; set; }

        public void GetImageBytes(HttpPostedFileBase imageUpload)
        {
            byte[] data;
            using (Stream inputStream = imageUpload.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }

                data = memoryStream.ToArray();
            }

            this.PostImage = data;
        }
    }
}