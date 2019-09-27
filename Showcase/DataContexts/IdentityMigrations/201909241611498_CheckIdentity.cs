namespace Showcase.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckIdentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.AspNetUsers", "AuthorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AuthorId");
            DropColumn("dbo.AspNetUsers", "UserId");
        }
    }
}
