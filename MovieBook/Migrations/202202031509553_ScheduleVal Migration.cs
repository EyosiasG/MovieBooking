namespace MovieBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleValMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "Movie", c => c.String(nullable: false));
            AlterColumn("dbo.Schedules", "Cinema", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "Cinema", c => c.String());
            AlterColumn("dbo.Schedules", "Movie", c => c.String());
        }
    }
}
