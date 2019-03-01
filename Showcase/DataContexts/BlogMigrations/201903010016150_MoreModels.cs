namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoLists",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskName = c.String(),
                        TaskDescription = c.String(),
                        TaskMessage = c.String(),
                        Active = c.Boolean(nullable: false),
                        Project_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId)
                .Index(t => t.Project_ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoLists", "Project_ProjectId", "dbo.Projects");
            DropIndex("dbo.ToDoLists", new[] { "Project_ProjectId" });
            DropTable("dbo.ToDoLists");
        }
    }
}
