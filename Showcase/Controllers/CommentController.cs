using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Showcase.Interfaces;
using Showcase.Models;

namespace Showcase.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepo commentRepo;

        public CommentController(ICommentRepo commentRepo)
        {
            this.commentRepo = commentRepo;
        }

        [HttpGet]
        public ActionResult _CommentBox(int postId)
        {
            List<Comment> comments = commentRepo.GetPostComments(postId);
            return View(comments);
        }

        [HttpGet]
        public ActionResult _NewComment(int postId, int authorId)
        {
            Comment comment = new Comment()
            {
                PostId = postId,
                AuthorId = authorId
            };

            return View(comment);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public void CreateComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                 commentRepo.CreatePostComment(comment);
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public bool DeleteComment(int commentId)
        {
            bool isDeleted = false;
            if (ModelState.IsValid)
            {
                isDeleted = commentRepo.DeleteComment(commentId);
            }

            return isDeleted;
        }
    }
}