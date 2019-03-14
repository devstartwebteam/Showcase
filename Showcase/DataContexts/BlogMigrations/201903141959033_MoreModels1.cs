namespace Showcase.DataContexts.BlogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreModels1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "WorkoutDistance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workouts", "WorkoutDistance");
        }
    }
}
