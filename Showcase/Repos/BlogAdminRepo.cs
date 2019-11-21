using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using log4net;
using log4net.Repository.Hierarchy;
using Showcase.DataContexts;
using Showcase.Interfaces;
using Showcase.Models;

namespace Showcase.Repos
{
    public class BlogAdminRepo : IBlogAdminRepo
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Post));
        private BlogDb db = new BlogDb();

        public Post GetNewPost(Post post)
        {
            try
            {
                post.AuthorList = db.Authors.ToDictionary(a => a.AuthorId, a => a.UserName);
                post.CategoryMultiSelectList = post.GetCategoryMultiSelectList(db.Categories.ToList());
                post.TagMultiSelectList = post.GetTagMultiSelectList(db.Tags.ToList());
                post.LocationMultiSelectList = post.GetLocationMultiSelectList(db.PostLocations.ToList());
            }
            catch(Exception e)
            {
                Logger.Error("Error setting up a new post", e);
            }
            finally
            {
                db.Dispose();
            }

            return post;
        }

        public bool CreateNewPost(Post post)
        {
            bool success = false;

            try
            {
                List<Category> categories = new List<Category>();
                List<PostLocation> locations = new List<PostLocation>();

                Author author = db.Authors.Find(post.AuthorId);

                if(author != null)
                    post.Author = author;

                if (post.SelectedCategoryIds.Any())
                {
                    foreach (var id in post.SelectedCategoryIds)
                    {
                        Category category = db.Categories.Find(id);
                        if (category != null)
                        {
                            categories.Add(category);
                        }
                    }
                    post.Categories = categories;
                }

                if (post.SelectedLocationIds.Any())
                {
                    foreach (var id in post.SelectedLocationIds)
                    {
                        PostLocation location = db.PostLocations.Find(id);
                        if (location != null)
                        {
                            locations.Add(location);
                        }
                    }
                    post.PostLocations = locations;
                }

                post.PostUrl = post.PostUrl.ToLower();
                post.GetImageBytes(post.PostImageUpload);
                post.Created = DateTime.Now;
                post.LastModified = DateTime.Now;

                db.Posts.Add(post);
                db.SaveChanges();

                success = true;
            }
            catch (Exception e)
            {
                Logger.Error("Error creating new post", e);
            }
            finally
            {
                db.Dispose();
            }

            return success;
        }

        public Post GetPostDetails(int? id)
        {

            Post post = new Post();
            try
            {
                post = db.Posts.Find(id);
            }
            catch (Exception e)
            {
                Logger.Error("Error getting post details", e);
            }
            finally
            {
                db.Dispose();
            }

            return post;
        }

        public List<Post> GetAllPosts()
        {
            List<Post> posts = new List<Post>();
            try
            {
                posts = db.Posts.Include(a => a.Categories).ToList();
            }
            catch (Exception e)
            {
                Logger.Error("Error getting all posts", e);
            }
            finally
            {
                db.Dispose();
            }

            return posts;
        }
    }
}