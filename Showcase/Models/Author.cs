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
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Alias")]
        public string NickName { get; set; }
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Display(Name = "Date Created")]
        public DateTime? Created { get; set; }
        [Display(Name = "Last Modified")]
        public DateTime? LastModified { get; set; }
        public int Age { get; set; }
        public byte[] ProfileImage { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        [NotMapped]
        [Display(Name = "Profile Image")]
        public HttpPostedFileBase ProfileImageUpload { get; set; }

        public Author()
        {
            Posts = new HashSet<Post>();
            Comments = new HashSet<Comment>();
        }

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