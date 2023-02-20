namespace MovieBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Actors", c => c.String());
            AddColumn("dbo.Movies", "Director", c => c.String());
            AddColumn("dbo.Movies", "Writer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Writer");
            DropColumn("dbo.Movies", "Director");
            DropColumn("dbo.Movies", "Actors");
        }
    }
}
