using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Showcase.Models;

namespace Showcase.Interfaces
{
    public interface IBlogAdminRepo
    {
        Post GetNewPost(Post post);
        bool UpdatePost(Post post);
        Post EditPost(int? id);
        bool CreateNewPost(Post post);
        Post GetPostDetails(int? id);
        List<Post> GetAllPosts();
    }
}