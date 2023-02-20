namespace MovieBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "UserEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "UserEmail");
        }
    }
}
