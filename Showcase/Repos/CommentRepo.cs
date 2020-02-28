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
                comments = db.Comments.Include(a => a.Author).Where(a => a.Post.PostId == postId).ToList();
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

        public Comment GetNewComment(int postId, int authorId)
        {
            Comment comment = new Comment();

            try
            {
                comment.PostId = postId;
                comment.Author = db.Authors.FirstOrDefault(a => a.AuthorId == authorId);
            }
            catch (Exception e)
            {
                Logger.Error("Error getting new comment for post", e);
            }
            finally
            {
                db.Dispose();
            }

            return comment;

        }

        public Comment GetNewReply(int postId, int authorId, int parentId)
        {
            Comment comment = new Comment();

            try
            {
                comment.PostId = postId;
                comment.ParentCommentId = parentId;
                comment.Author = db.Authors.FirstOrDefault(a => a.AuthorId == authorId);
            }
            catch (Exception e)
            {
                Logger.Error("Error getting new reply for post", e);
            }
            finally
            {
                db.Dispose();
            }

            return comment;

        }

        public bool CreatePostComment(Comment comment)
        {
            bool isCreated = false;
            try
            {
                comment.Author = db.Authors.First(a => a.AuthorId == comment.AuthorId);
                comment.Created = DateTime.Now;
                comment.LastUpdated = DateTime.Now;

                Post post = db.Posts.First(a => a.PostId == comment.PostId);
                post.Comments.Add(comment);

                db.SaveChanges();

                isCreated = true;

            }
            catch (Exception e)
            {
                Logger.Error("Error created comment for post", e);
            }
            finally
            {
                db.Dispose();
            }

            return isCreated;
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