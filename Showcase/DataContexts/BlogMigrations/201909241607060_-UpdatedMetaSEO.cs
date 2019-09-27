namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMetaSEO : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MetaSEOs", new[] { "PostId_PostId" });
            RenameColumn(table: "dbo.MetaSEOs", name: "PostId_PostId", newName: "MetaPostId");
            DropPrimaryKey("dbo.MetaSEOs");
            AlterColumn("dbo.MetaSEOs", "MetaPostId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.MetaSEOs", "MetaPostId");
            CreateIndex("dbo.MetaSEOs", "MetaPostId");
            DropColumn("dbo.MetaSEOs", "MetaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MetaSEOs", "MetaId", c => c.Int(nullable: false, identity: true));
            DropIndex("dbo.MetaSEOs", new[] { "MetaPostId" });
            DropPrimaryKey("dbo.MetaSEOs");
            AlterColumn("dbo.MetaSEOs", "MetaPostId", c => c.Int());
            AddPrimaryKey("dbo.MetaSEOs", "MetaId");
            RenameColumn(table: "dbo.MetaSEOs", name: "MetaPostId", newName: "PostId_PostId");
            CreateIndex("dbo.MetaSEOs", "PostId_PostId");
        }
    }
}
