namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewModels : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CategoryPosts", newName: "PostCategories");
            DropPrimaryKey("dbo.PostCategories");
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        AlbumName = c.String(),
                        Project_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId)
                .Index(t => t.Project_ProjectId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        PhotoName = c.String(),
                        PhotoURL = c.String(),
                        Album_AlbumId = c.Int(),
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumId)
                .Index(t => t.Album_AlbumId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        ProjectDescription = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        WorkoutId = c.Int(nullable: false, identity: true),
                        WorkoutTitle = c.String(),
                        WorkoutDescription = c.String(),
                        WorkoutTpe = c.String(),
                        WorkoutLength = c.String(),
                    })
                .PrimaryKey(t => t.WorkoutId);
            
            CreateTable(
                "dbo.TagProjects",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Project_ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Project_ProjectId })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Project_ProjectId);
            
            CreateTable(
                "dbo.CategoryProjects",
                c => new
                    {
                        Category_CategoryId = c.Int(nullable: false),
                        Project_ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_CategoryId, t.Project_ProjectId })
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId, cascadeDelete: true)
                .Index(t => t.Category_CategoryId)
                .Index(t => t.Project_ProjectId);
            
            AddPrimaryKey("dbo.PostCategories", new[] { "Post_PostId", "Category_CategoryId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryProjects", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.CategoryProjects", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.TagProjects", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.TagProjects", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.Albums", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Photos", "Album_AlbumId", "dbo.Albums");
            DropIndex("dbo.CategoryProjects", new[] { "Project_ProjectId" });
            DropIndex("dbo.CategoryProjects", new[] { "Category_CategoryId" });
            DropIndex("dbo.TagProjects", new[] { "Project_ProjectId" });
            DropIndex("dbo.TagProjects", new[] { "Tag_TagId" });
            DropIndex("dbo.Photos", new[] { "Album_AlbumId" });
            DropIndex("dbo.Albums", new[] { "Project_ProjectId" });
            DropPrimaryKey("dbo.PostCategories");
            DropTable("dbo.CategoryProjects");
            DropTable("dbo.TagProjects");
            DropTable("dbo.Workouts");
            DropTable("dbo.Projects");
            DropTable("dbo.Photos");
            DropTable("dbo.Albums");
            AddPrimaryKey("dbo.PostCategories", new[] { "Category_CategoryId", "Post_PostId" });
            RenameTable(name: "dbo.PostCategories", newName: "CategoryPosts");
        }
    }
}
