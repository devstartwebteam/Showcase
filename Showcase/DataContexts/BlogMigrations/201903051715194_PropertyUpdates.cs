namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "WorkoutDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Workouts", "WorkoutType", c => c.String());
            DropColumn("dbo.Workouts", "WorkoutTpe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workouts", "WorkoutTpe", c => c.String());
            DropColumn("dbo.Workouts", "WorkoutType");
            DropColumn("dbo.Workouts", "WorkoutDate");
        }
    }
}
