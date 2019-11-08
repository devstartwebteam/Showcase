namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPosts1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "PostName", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "PostUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "PostContent", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "PostContent", c => c.String());
            AlterColumn("dbo.Posts", "PostUrl", c => c.String());
            AlterColumn("dbo.Posts", "PostName", c => c.String());
        }
    }
}
