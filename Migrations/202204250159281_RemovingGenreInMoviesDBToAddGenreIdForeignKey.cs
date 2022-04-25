namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingGenreInMoviesDBToAddGenreIdForeignKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
        }
    }
}
