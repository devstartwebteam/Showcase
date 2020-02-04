namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "PostContent", c => c.String());
            AlterColumn("dbo.Posts", "PostSnippet", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "PostSnippet", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Posts", "PostContent", c => c.String(nullable: false));
        }
    }
}
