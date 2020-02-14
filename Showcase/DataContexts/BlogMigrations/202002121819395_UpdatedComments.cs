namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedComments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CommentContent = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        Author_AuthorId = c.Int(),
                        Post_PostId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Authors", t => t.Author_AuthorId)
                .ForeignKey("dbo.Posts", t => t.Post_PostId)
                .Index(t => t.Author_AuthorId)
                .Index(t => t.Post_PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.Comments", "Author_AuthorId", "dbo.Authors");
            DropIndex("dbo.Comments", new[] { "Post_PostId" });
            DropIndex("dbo.Comments", new[] { "Author_AuthorId" });
            DropTable("dbo.Comments");
        }
    }
}
