using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Showcase.Models;

namespace Showcase.Interfaces
{
    public interface ICommentRepo
    {
        Comment GetNewReply(int postId, int parentId, int authorId);
        List<Comment> GetPostComments(int postId);
        Comment GetNewComment(int postId, int authorId);
        bool DeleteComment(int commentId);
        bool CreatePostComment(Comment comment);
    }
}
