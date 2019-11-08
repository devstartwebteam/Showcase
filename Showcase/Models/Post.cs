using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Showcase.DataContexts;

namespace Showcase.Models
{
    public class Post
    {
        private BlogDb db = new BlogDb();

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }

        [Display(Name = "Post Name")]
        [Required]
        public string PostName { get; set; }

        [Display(Name = "Post Url")]
        [Required]
        public string PostUrl { get; set; }

        public byte[] PostImage { get; set; }

        [NotMapped]
        [Display(Name = "Featured Image")]
        [Required]
        public HttpPostedFileBase PostImageUpload { get; set; }

        [AllowHtml]
        [Display(Name = "Post Content")]
        [Required]
        public string PostContent { get; set; }
        public int ViewCount { get; set; }
        public int Likes { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public Author Author { get; set; }

        [NotMapped]
        [Display(Name = "Assign Author")]
        public static Dictionary<int, string> AuthorList { get; set; }

        [NotMapped]
        public int[] SelectedTagIds { get; set; }

        [NotMapped]
        public int[] SelectedCategoryIds { get; set; }

        [NotMapped]
        public MultiSelectList CategoryMultiSelectList { get; set; }

        [NotMapped]
        public MultiSelectList TagMultiSelectList { get; set; }

        [NotMapped]
        public MultiSelectList LocationMultiSelectList { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<PostLocation> PostLocations { get; set; }
        public virtual Template Template { get; set; }
        public MetaSEO MetaSEO { get; set; }
        public Post()
        {
            Categories = new HashSet<Category>();
            Tags = new HashSet<Tag>();
            PostLocations = new HashSet<PostLocation>();

            AuthorList = db.Authors.ToDictionary(a => a.AuthorId, a => a.UserName);
            CategoryMultiSelectList = GetCategoryMultiSelectList(db.Categories.ToList());
            TagMultiSelectList = GetTagMultiSelectList(db.Tags.ToList());
            LocationMultiSelectList = GetLocationMultiSelectList(db.PostLocations.ToList());
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

            this.PostImage = data;
        }

        public static SelectList GetAuthorList()
        {
            return new SelectList(AuthorList, "Key", "Value");
        }

        public MultiSelectList GetCategoryMultiSelectList(List<Category> list, int[] ids = null)
        {
            Dictionary<int, string> dictionary = list.ToDictionary(a => a.CategoryId, b => b.CategoryName);
            MultiSelectList selectList = new MultiSelectList(dictionary, "Key", "Value", ids);

            return selectList;
        }

        public MultiSelectList GetTagMultiSelectList(List<Tag> list, int[] ids = null)
        {
            Dictionary<int, string> dictionary = list.ToDictionary(a => a.TagId, b => b.TagName);
            MultiSelectList selectList = new MultiSelectList(dictionary, "Key", "Value", ids);

            return selectList;
        }

        public MultiSelectList GetLocationMultiSelectList(List<PostLocation> list, int[] ids = null)
        {
            Dictionary<int, string> dictionary = list.ToDictionary(a => a.PostLocationId, b => b.PostLocationName);
            MultiSelectList selectList = new MultiSelectList(dictionary, "Key", "Value", ids);

            return selectList;
        }
    }
}