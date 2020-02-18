using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Showcase.Models;

namespace Showcase.Interfaces
{
    public interface IBlogPostRepo
    {
        Post GetBlogPost(string title);
    }
}
