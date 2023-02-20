namespace MovieBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CinemaValMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cinemas", "Logo", c => c.String(nullable: false));
            AlterColumn("dbo.Cinemas", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Cinemas", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cinemas", "Description", c => c.String());
            AlterColumn("dbo.Cinemas", "Name", c => c.String());
            AlterColumn("dbo.Cinemas", "Logo", c => c.String());
        }
    }
}
