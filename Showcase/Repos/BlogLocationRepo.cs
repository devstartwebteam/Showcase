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
    public class BlogLocationRepo : IBlogLocationRepo
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(PostLocation));
        private BlogDb db = new BlogDb();
        public PostLocation GetHomePostLocation(string name)
        {
            PostLocation location = new PostLocation();

            try
            {
                location = db.PostLocations.Where(a => a.PostLocationName.ToLower() == name.ToLower())
                    .Include(a => a.Posts.Select(b => b.PostImages))
                    .Include(a => a.Posts.Select(b => b.Author))
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                Logger.Error("Error getting post for home location", e);
            }
            finally
            {
                db.Dispose();
            }

            return location;
        }

        public PostLocation GetLocationCategories(string name)
        {
            PostLocation location = new PostLocation();

            try
            {
                location = db.PostLocations.Where(a => a.PostLocationName.ToLower() == name.ToLower())
                    .Include(a => a.Categories)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                Logger.Error("Error getting categories for location", e);
            }
            finally
            {
                db.Dispose();
            }

            return location;
        }

        public PostLocation GetLocationTags(string name)
        {
            PostLocation location = new PostLocation();

            try
            {
                location = db.PostLocations.Where(a => a.PostLocationName.ToLower() == name.ToLower())
                    .Include(a => a.Tags)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                Logger.Error("Error getting tags for location", e);
            }
            finally
            {
                db.Dispose();
            }

            return location;
        }
    }
}