namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPostImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostImages",
                c => new
                    {
                        PostImageId = c.Int(nullable: false),
                        Thumbnail = c.Binary(),
                        Slider = c.Binary(),
                        PageBody = c.Binary(),
                        PageBanner = c.Binary(),
                    })
                .PrimaryKey(t => t.PostImageId)
                .ForeignKey("dbo.Posts", t => t.PostImageId)
                .Index(t => t.PostImageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostImages", "PostImageId", "dbo.Posts");
            DropIndex("dbo.PostImages", new[] { "PostImageId" });
            DropTable("dbo.PostImages");
        }
    }
}
