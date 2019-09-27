namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModelAgain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Likes", c => c.Int(nullable: false));
            DropColumn("dbo.Posts", "InActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "InActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Posts", "Likes");
        }
    }
}
