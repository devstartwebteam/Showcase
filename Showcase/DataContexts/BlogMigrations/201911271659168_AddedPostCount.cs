namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPostCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostLocations", "PostCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostLocations", "PostCount");
        }
    }
}
