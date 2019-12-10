namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSnippetProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PostSnippet", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "PostSnippet");
        }
    }
}
