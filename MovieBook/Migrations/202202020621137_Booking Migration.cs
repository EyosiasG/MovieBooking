namespace MovieBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Movie = c.String(),
                        Cinema = c.String(),
                        Time = c.DateTime(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Email)
                .ForeignKey("dbo.AspNetUsers", t => t.Email)
                .Index(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Email", "dbo.AspNetUsers");
            DropIndex("dbo.Bookings", new[] { "Email" });
            DropTable("dbo.Bookings");
        }
    }
}
