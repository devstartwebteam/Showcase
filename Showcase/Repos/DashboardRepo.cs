using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using Showcase.DataContexts;
using Showcase.Interfaces;
using Showcase.Models;

namespace Showcase.Repos
{
    public class DashboardRepo : IDashboardRepo
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Post));
        private BlogDb db = new BlogDb();
    }
}