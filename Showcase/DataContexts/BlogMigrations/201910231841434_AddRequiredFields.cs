namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Templates", "TemplateName", c => c.String(nullable: false));
            AlterColumn("dbo.ToDoLists", "TaskName", c => c.String(nullable: false));
            AlterColumn("dbo.Workouts", "WorkoutTitle", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workouts", "WorkoutTitle", c => c.String());
            AlterColumn("dbo.ToDoLists", "TaskName", c => c.String());
            AlterColumn("dbo.Templates", "TemplateName", c => c.String());
        }
    }
}
