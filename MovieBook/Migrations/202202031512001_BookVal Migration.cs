namespace MovieBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookValMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "UserID", c => c.String(nullable: false));
            AlterColumn("dbo.Bookings", "Movie", c => c.String(nullable: false));
            AlterColumn("dbo.Bookings", "Cinema", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "Cinema", c => c.String());
            AlterColumn("dbo.Bookings", "Movie", c => c.String());
            AlterColumn("dbo.Bookings", "UserID", c => c.String());
        }
    }
}
