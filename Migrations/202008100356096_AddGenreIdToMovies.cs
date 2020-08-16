namespace MovieRentaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreIdToMovies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genre_Id" });
            RenameColumn(table: "dbo.Movies", name: "genre_Id", newName: "genreId");
            AlterColumn("dbo.Movies", "genreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "genreId");
            AddForeignKey("dbo.Movies", "genreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "genreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genreId" });
            AlterColumn("dbo.Movies", "genreId", c => c.Int());
            RenameColumn(table: "dbo.Movies", name: "genreId", newName: "genre_Id");
            CreateIndex("dbo.Movies", "genre_Id");
            AddForeignKey("dbo.Movies", "genre_Id", "dbo.Genres", "Id");
        }
    }
}
