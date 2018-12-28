namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        NickName = c.String(),
                        Location = c.String(),
                        Age = c.Int(nullable: false),
                        FacebookUrl = c.String(),
                        TwitterUrl = c.String(),
                        InstagramUrl = c.String(),
                        LinkedInUrl = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        PostName = c.String(),
                        PostUrl = c.String(),
                        PostContent = c.String(),
                        ViewCount = c.Int(nullable: false),
                        InActive = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Author_AuthorId = c.Int(),
                        Template_TemplateId = c.Int(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Authors", t => t.Author_AuthorId)
                .ForeignKey("dbo.Templates", t => t.Template_TemplateId)
                .Index(t => t.Author_AuthorId)
                .Index(t => t.Template_TemplateId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CategoryDescription = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.MetaSEOs",
                c => new
                    {
                        MetaId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        KeyWords = c.String(),
                        OpenGraphImageUrl = c.String(),
                        PageUrl = c.String(),
                        PostId_PostId = c.Int(),
                    })
                .PrimaryKey(t => t.MetaId)
                .ForeignKey("dbo.Posts", t => t.PostId_PostId)
                .Index(t => t.PostId_PostId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                        TagDescription = c.String(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.Templates",
                c => new
                    {
                        TemplateId = c.Int(nullable: false, identity: true),
                        TemplateName = c.String(),
                    })
                .PrimaryKey(t => t.TemplateId);
            
            CreateTable(
                "dbo.CategoryPosts",
                c => new
                    {
                        Category_CategoryId = c.Int(nullable: false),
                        Post_PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_CategoryId, t.Post_PostId })
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_PostId, cascadeDelete: true)
                .Index(t => t.Category_CategoryId)
                .Index(t => t.Post_PostId);
            
            CreateTable(
                "dbo.TagPosts",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Post_PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Post_PostId })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_PostId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Post_PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Template_TemplateId", "dbo.Templates");
            DropForeignKey("dbo.TagPosts", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.TagPosts", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.MetaSEOs", "PostId_PostId", "dbo.Posts");
            DropForeignKey("dbo.CategoryPosts", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.CategoryPosts", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Posts", "Author_AuthorId", "dbo.Authors");
            DropIndex("dbo.TagPosts", new[] { "Post_PostId" });
            DropIndex("dbo.TagPosts", new[] { "Tag_TagId" });
            DropIndex("dbo.CategoryPosts", new[] { "Post_PostId" });
            DropIndex("dbo.CategoryPosts", new[] { "Category_CategoryId" });
            DropIndex("dbo.MetaSEOs", new[] { "PostId_PostId" });
            DropIndex("dbo.Posts", new[] { "Template_TemplateId" });
            DropIndex("dbo.Posts", new[] { "Author_AuthorId" });
            DropTable("dbo.TagPosts");
            DropTable("dbo.CategoryPosts");
            DropTable("dbo.Templates");
            DropTable("dbo.Tags");
            DropTable("dbo.MetaSEOs");
            DropTable("dbo.Categories");
            DropTable("dbo.Posts");
            DropTable("dbo.Authors");
        }
    }
}
