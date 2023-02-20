namespace MovieBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SixMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "BookPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "BookPrice", c => c.Double(nullable: false));
        }
    }
}
