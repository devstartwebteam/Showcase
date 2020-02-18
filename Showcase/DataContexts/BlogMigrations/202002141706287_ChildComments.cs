namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChildComments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "ParentCommentId", c => c.Int());
            CreateIndex("dbo.Comments", "ParentCommentId");
            AddForeignKey("dbo.Comments", "ParentCommentId", "dbo.Comments", "CommentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ParentCommentId", "dbo.Comments");
            DropIndex("dbo.Comments", new[] { "ParentCommentId" });
            DropColumn("dbo.Comments", "ParentCommentId");
        }
    }
}
