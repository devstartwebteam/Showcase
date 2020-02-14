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
        List<Comment> GetPostComments(int postId);
        bool DeleteComment(int commentId);
        void CreatePostComment(Comment comment);
    }
}
