using Showcase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Showcase.ViewModels
{
    public class PostVm
    {
        public PostVm()
        {
            AuthorList = new Dictionary<int, string>();
        }

        [NotMapped]
        [Display(Name = "Featured Image")]
        public HttpPostedFileBase PostImageUpload { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please assign an Author")]
        public int AuthorId { get; set; }

        [NotMapped]
        [Display(Name = "Assign Author")]
        public Dictionary<int, string> AuthorList { get; set; }


        [NotMapped]
        public MultiSelectList CategoryMultiSelectList { get; set; }

        [NotMapped]
        public MultiSelectList TagMultiSelectList { get; set; }

        [NotMapped]
        public MultiSelectList LocationMultiSelectList { get; set; }

        public SelectList GetAuthorList()
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