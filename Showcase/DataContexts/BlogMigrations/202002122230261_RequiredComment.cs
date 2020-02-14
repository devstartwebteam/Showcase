namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredComment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "CommentContent", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "CommentContent", c => c.String());
        }
    }
}
