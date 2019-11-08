using Showcase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Showcase.DataContexts
{
    public class BlogDb : DbContext
    {
        public BlogDb()
           : base("DefaultConnection")
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostLocation> PostLocations { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<MetaSEO> MetaSEO { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ToDoList> Tasks { get; set; }
    }
}