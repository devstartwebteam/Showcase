namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPosts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PostImage", c => c.Binary());
            AddColumn("dbo.Posts", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Posts", "LastModified", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "LastModified");
            DropColumn("dbo.Posts", "Created");
            DropColumn("dbo.Posts", "PostImage");
        }
    }
}
