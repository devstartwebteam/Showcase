namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedStringLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "CommentContent", c => c.String(nullable: false, maxLength: 400));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "CommentContent", c => c.String(nullable: false));
        }
    }
}
