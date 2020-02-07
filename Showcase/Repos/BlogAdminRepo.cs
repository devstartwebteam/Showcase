using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.ModelBinding;
using log4net;
using log4net.Repository.Hierarchy;
using Showcase.DataContexts;
using Showcase.Interfaces;
using Showcase.Models;
using WebGrease.Css.Extensions;

namespace Showcase.Repos
{
    public class BlogAdminRepo : IBlogAdminRepo
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Post));
        private readonly BlogDb db = new BlogDb();

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
                Logger.Error("Error setting up a new post in blog admin repo", e);
            }
            finally
            {
                db.Dispose();
            }

            return post;
        }

        public Post GetPost(int? id)
        {
            Post post = new Post();
            try
            {
                post = db.Posts.Find(id);
            }
            catch (Exception e)
            {
                Logger.Error("Could not get post in blog admin repo", e);
            }

            return post;
        }

        public bool DeletePost(int id)
        {
            bool deleted = false;

            try
            {
                Post post = db.Posts.Include(a => a.PostImages).First(a => a.PostId == id);

                db.Posts.Remove(post);
                db.SaveChanges();

                deleted = true;
            }
            catch (Exception e)
            {
                Logger.Error("Error deleting post in blog admin repo", e);
            }

            return deleted;
        }

        public Post EditPost(int? id)
        {
            Post post = new Post();
            try
            {
                post = db.Posts.Include(a => a.Author)
                    .Include(a => a.Categories)
                    .Include(a => a.PostLocations)
                    .Include(a => a.Tags)
                    .FirstOrDefault(a => a.PostId == id);

                post.AuthorId = post.Author.AuthorId;

                if (post != null)
                {
                    int[] categoryIds = null;
                    int[] tagIds = null;
                    int[] locationIds = null;

                    if (post.Categories.Any())
                        categoryIds = post.Categories.Select(a => a.CategoryId).ToArray();

                    if (post.Tags.Any())
                        tagIds = post.Tags.Select(a => a.TagId).ToArray();

                    if (post.PostLocations.Any())
                        locationIds = post.PostLocations.Select(a => a.PostLocationId).ToArray();
                    
                    post.AuthorList = db.Authors.ToDictionary(a => a.AuthorId, a => a.UserName);
                    post.CategoryMultiSelectList = post.GetCategoryMultiSelectList(db.Categories.ToList(), categoryIds);
                    post.TagMultiSelectList = post.GetTagMultiSelectList(db.Tags.ToList(), tagIds);
                    post.LocationMultiSelectList = post.GetLocationMultiSelectList(db.PostLocations.ToList(), locationIds);
                }

                return post;
            }
            catch (Exception e)
            {
                Logger.Error("Error editing post", e);
            }
            finally
            {
                db.Dispose();
            }

            return post;
        }

        public bool UpdatePost(Post post)
        {
            bool isUpdated = false;
            try
            {
                List<Category> categories = new List<Category>();
                List<PostLocation> locations = new List<PostLocation>();
                List<Tag> tags = new List<Tag>();

                Post oldPost = db.Posts
                    .Include(a => a.PostImages)
                    .Include(a => a.Author)
                    .Include(a => a.Categories)
                    .Include(a => a.Tags)
                    .Include(a => a.PostLocations)
                    .First(a => a.PostId == post.PostId);

                if (post.PostImageUpload != null)
                {
                    oldPost.PostImages = new PostImage();
                    post.GetImageBytes(post.PostImageUpload);
                    oldPost.PostImages = GeneratePostImages(post);
                    oldPost.PostImage = post.PostImage;
                }
                else
                {
                    post.PostImage = oldPost.PostImage;
                }

                if (post.SelectedCategoryIds != null && post.SelectedCategoryIds.Any())
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
                    oldPost.Categories = post.Categories;
                }
                else
                {
                    oldPost.Categories.Clear();
                }

                if (post.SelectedLocationIds != null && post.SelectedLocationIds.Any())
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
                    oldPost.PostLocations = post.PostLocations;
                }
                else
                {
                    oldPost.PostLocations.Clear();
                }

                if (post.Tags != null && post.Tags.Any())
                {
                    foreach (var id in post.Tags)
                    {
                        Tag tag = db.Tags.Find(id);
                        if (tag != null)
                        {
                            tags.Add(tag);
                        }
                    }
                    post.Tags = tags;
                    oldPost.Tags = post.Tags;
                }
                else
                {
                    oldPost.Tags.Clear();
                }

                post.LastModified = DateTime.Now;
                post.Created = oldPost.Created;
                isUpdated = true;

                db.Entry(oldPost).CurrentValues.SetValues(post);
                db.Entry(oldPost).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Logger.Error("Error updating post", e);
            }
            finally
            {
                db.Dispose();
            }

            return isUpdated;
        }

        public bool CreateNewPost(Post post)
        {
            bool success = false;

            try
            {
                List<Category> categories = new List<Category>();
                List<PostLocation> locations = new List<PostLocation>();
                PostImage postImages = new PostImage();
                post.Author = db.Authors.Find(post.AuthorId);

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

                if (post.PostImageUpload != null)
                {
                    post.GetImageBytes(post.PostImageUpload);
                }
                
                if (post.PostImage != null)
                {
                    post.PostImages = GeneratePostImages(post);
                }

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

        public PostImage GeneratePostImages(Post post)
        {
            PostImage postImages = new PostImage
            {
                PageBanner = ResizePostImage(post.PostImage, "banner"),
                PageBody = ResizePostImage(post.PostImage, "body"),
                Slider = ResizePostImage(post.PostImage, "slider"),
                Thumbnail = ResizePostImage(post.PostImage, "thumbnail")
            };

            return postImages;

        }

        public byte[] ResizePostImage(byte[] resizeImage, string type)
        {
            using (MemoryStream stream = new MemoryStream(resizeImage, 0, resizeImage.Length))
            {
                using (Image adjustImage = Image.FromStream(stream))
                {
                    int newHeight = 0;
                    int newWidth = 0;
                    int horizontal = 0;
                    int vertical = 0;

                    switch (type.ToLower())
                    {
                        case "banner":
                            newHeight = 800;
                            newWidth = 1920;
                            horizontal = 0;
                            vertical = 0;
                            break;
                        case "body":
                            newHeight = 530;
                            newWidth = 360;
                            horizontal = 780;
                            vertical = 300;
                            break;
                        case "slider":
                            newHeight = 630;
                            newWidth = 640;
                            horizontal = 340;
                            vertical = 200;
                            break;
                        case "thumbnail":
                            newHeight = 80;
                            newWidth = 100;
                            break;
                    }

                    if (type.ToLower() == "thumbnail")
                    {
                        float aspectRatio = (float)adjustImage.Size.Width / (float)adjustImage.Size.Height;
                        newWidth = Convert.ToInt32(aspectRatio * newHeight);
                    }

                    Bitmap thumbBitmap = new Bitmap(newWidth, newHeight);
                    Graphics thumbGraph = Graphics.FromImage(thumbBitmap);

                    thumbGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    thumbGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    thumbGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                    if( type.ToLower() == "thumbnail" || type.ToLower() == "banner" )
                    {
                        var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                        thumbGraph.DrawImage(adjustImage, imageRectangle);
                    }

                    else
                    {
                        Rectangle imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                        Rectangle cropRect = new Rectangle(horizontal, vertical, newWidth, newHeight);
                        thumbGraph.DrawImage(adjustImage, imageRectangle, cropRect, GraphicsUnit.Pixel);
                    }

                    using (var newBitmap = new Bitmap(thumbBitmap))
                    {
                        using (MemoryStream mstream = new MemoryStream())
                        {
                            newBitmap.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            resizeImage = mstream.ToArray();
                        }
                    }

                    thumbGraph.Dispose();
                    thumbBitmap.Dispose();

                    return resizeImage;
                }
            }
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