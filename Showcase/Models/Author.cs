using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Location { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }
        public int Age { get; set; }

        [NotMapped]
        [Display(Name = "Profile Image")]
        public HttpPostedFileBase ProfileImageUpload { get; set; }
        public byte[] ProfileImage { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string LinkedInUrl { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

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

            this.ProfileImage = data;
        }
    }
}