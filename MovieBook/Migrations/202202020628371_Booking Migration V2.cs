namespace MovieBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingMigrationV2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "Email", "dbo.AspNetUsers");
            DropIndex("dbo.Bookings", new[] { "Email" });
            DropPrimaryKey("dbo.Bookings");
            AddColumn("dbo.Bookings", "BookingID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Bookings", "BookingID");
            DropColumn("dbo.Bookings", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "Email", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Bookings");
            DropColumn("dbo.Bookings", "BookingID");
            AddPrimaryKey("dbo.Bookings", "Email");
            CreateIndex("dbo.Bookings", "Email");
            AddForeignKey("dbo.Bookings", "Email", "dbo.AspNetUsers", "Id");
        }
    }
}
