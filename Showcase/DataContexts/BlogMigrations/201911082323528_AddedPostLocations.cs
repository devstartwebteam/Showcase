namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPostLocations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostLocations",
                c => new
                    {
                        PostLocationId = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        PostLocationName = c.String(),
                    })
                .PrimaryKey(t => t.PostLocationId);
            
            CreateTable(
                "dbo.PostLocationCategories",
                c => new
                    {
                        PostLocation_PostLocationId = c.Int(nullable: false),
                        Category_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostLocation_PostLocationId, t.Category_CategoryId })
                .ForeignKey("dbo.PostLocations", t => t.PostLocation_PostLocationId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId, cascadeDelete: true)
                .Index(t => t.PostLocation_PostLocationId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.PostPostLocations",
                c => new
                    {
                        Post_PostId = c.Int(nullable: false),
                        PostLocation_PostLocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post_PostId, t.PostLocation_PostLocationId })
                .ForeignKey("dbo.Posts", t => t.Post_PostId, cascadeDelete: true)
                .ForeignKey("dbo.PostLocations", t => t.PostLocation_PostLocationId, cascadeDelete: true)
                .Index(t => t.Post_PostId)
                .Index(t => t.PostLocation_PostLocationId);
            
            CreateTable(
                "dbo.TagPostLocations",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        PostLocation_PostLocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.PostLocation_PostLocationId })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.PostLocations", t => t.PostLocation_PostLocationId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.PostLocation_PostLocationId);
            
            AddColumn("dbo.Albums", "CreateDate", c => c.DateTime());
            AddColumn("dbo.Albums", "LastUpdated", c => c.DateTime());
            AddColumn("dbo.Photos", "CreateDate", c => c.DateTime());
            AddColumn("dbo.Photos", "LastUpdated", c => c.DateTime());
            AddColumn("dbo.Categories", "Created", c => c.DateTime());
            AddColumn("dbo.Categories", "LastModified", c => c.DateTime());
            AddColumn("dbo.Tags", "CreateDate", c => c.DateTime());
            AddColumn("dbo.Tags", "LastUpdated", c => c.DateTime());
            AlterColumn("dbo.Authors", "Created", c => c.DateTime());
            AlterColumn("dbo.Authors", "LastModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagPostLocations", "PostLocation_PostLocationId", "dbo.PostLocations");
            DropForeignKey("dbo.TagPostLocations", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.PostPostLocations", "PostLocation_PostLocationId", "dbo.PostLocations");
            DropForeignKey("dbo.PostPostLocations", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.PostLocationCategories", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.PostLocationCategories", "PostLocation_PostLocationId", "dbo.PostLocations");
            DropIndex("dbo.TagPostLocations", new[] { "PostLocation_PostLocationId" });
            DropIndex("dbo.TagPostLocations", new[] { "Tag_TagId" });
            DropIndex("dbo.PostPostLocations", new[] { "PostLocation_PostLocationId" });
            DropIndex("dbo.PostPostLocations", new[] { "Post_PostId" });
            DropIndex("dbo.PostLocationCategories", new[] { "Category_CategoryId" });
            DropIndex("dbo.PostLocationCategories", new[] { "PostLocation_PostLocationId" });
            AlterColumn("dbo.Authors", "LastModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Authors", "Created", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tags", "LastUpdated");
            DropColumn("dbo.Tags", "CreateDate");
            DropColumn("dbo.Categories", "LastModified");
            DropColumn("dbo.Categories", "Created");
            DropColumn("dbo.Photos", "LastUpdated");
            DropColumn("dbo.Photos", "CreateDate");
            DropColumn("dbo.Albums", "LastUpdated");
            DropColumn("dbo.Albums", "CreateDate");
            DropTable("dbo.TagPostLocations");
            DropTable("dbo.PostPostLocations");
            DropTable("dbo.PostLocationCategories");
            DropTable("dbo.PostLocations");
        }
    }
}
