namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "Created", c => c.DateTime());
            DropColumn("dbo.Tags", "CreateDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "CreateDate", c => c.DateTime());
            DropColumn("dbo.Tags", "Created");
        }
    }
}
