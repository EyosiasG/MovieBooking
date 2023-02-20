namespace MovieBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieValMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "ImageURL", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Genre", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Actors", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Producer", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Director", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Writer", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Writer", c => c.String());
            AlterColumn("dbo.Movies", "Director", c => c.String());
            AlterColumn("dbo.Movies", "Producer", c => c.String());
            AlterColumn("dbo.Movies", "Actors", c => c.String());
            AlterColumn("dbo.Movies", "Genre", c => c.String());
            AlterColumn("dbo.Movies", "ImageURL", c => c.String());
            AlterColumn("dbo.Movies", "Description", c => c.String());
        }
    }
}
