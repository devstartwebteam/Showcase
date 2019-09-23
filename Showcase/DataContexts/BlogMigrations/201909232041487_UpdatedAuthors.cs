namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAuthors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Authors", "LastModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Authors", "ProfileImage", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "ProfileImage");
            DropColumn("dbo.Authors", "LastModified");
            DropColumn("dbo.Authors", "Created");
        }
    }
}
