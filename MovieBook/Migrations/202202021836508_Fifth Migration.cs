namespace MovieBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FifthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "UserID", c => c.String());
            DropColumn("dbo.Bookings", "UserEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "UserEmail", c => c.String());
            DropColumn("dbo.Bookings", "UserID");
        }
    }
}
