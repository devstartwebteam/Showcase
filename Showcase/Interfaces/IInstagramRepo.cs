using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Showcase.ViewModels;

namespace Showcase.Interfaces
{
    public interface IInstagramRepo
    {
        List<InstagramImage> GetInstagramImages();
    }
}
