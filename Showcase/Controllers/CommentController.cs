﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Showcase.Attributes;
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
            Comment comment = commentRepo.GetNewComment(postId, authorId);

            return View(comment);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [AjaxOnly]
        [RateLimit(MilliSeconds = 5000)]
        public void CreateComment(Comment comment)
        {
            bool isCreated = false;

            if (ModelState.IsValid)
            {
                isCreated = commentRepo.CreatePostComment(comment);
            }
        }

        [HttpGet]
        [RateLimit(MilliSeconds = 1000)]
        public ActionResult _NewReply(int postId, int parentId, int authorId)
        {
            Comment comment = commentRepo.GetNewReply(postId, authorId, parentId);

            return View(comment);
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