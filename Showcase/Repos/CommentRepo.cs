using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using log4net;
using Showcase.DataContexts;
using Showcase.Interfaces;
using Showcase.Models;

namespace Showcase.Repos
{
    public class CommentRepo : ICommentRepo
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(PostLocation));
        private BlogDb db = new BlogDb();

        public List<Comment> GetPostComments(int postId)
        {
            List<Comment> comments = new List<Comment>();

            try
            {
                comments = db.Comments.Where(a => a.Post.PostId == postId).ToList();
            }
            catch (Exception e)
            {
                Logger.Error("Error getting comments for post", e);
            }
            finally
            {
                db.Dispose();
            }

            return comments;
        }

        public void CreatePostComment(Comment comment)
        {
            bool isCreated = false;
            try
            {
                Post post = db.Posts.FirstOrDefault(a => a.PostId == comment.PostId);
                Author author = db.Authors.FirstOrDefault(a => a.AuthorId == comment.AuthorId);
                comment.Created = DateTime.Now;
                comment.LastUpdated = DateTime.Now;
                comment.Author = author;
                post.Comments.Add(comment);

                db.SaveChanges();

            }
            catch (Exception e)
            {
                Logger.Error("Error created comment for post", e);
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool DeleteComment(int commentId)
        {
            bool isDeleted = false;
            Comment comment = new Comment();
            try
            {
                 comment = db.Comments.Find(commentId);
                 db.Comments.Remove(comment);
                 db.SaveChanges();

                 isDeleted = true;
            }
            catch (Exception e)
            {
                Logger.Error("Error deleting comment in CommentRepo", e);
            }

            return isDeleted;
        }
    }
}