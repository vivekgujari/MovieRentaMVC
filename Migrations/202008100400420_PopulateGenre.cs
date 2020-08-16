namespace MovieRentaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Romantic')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Documentary')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Animation')");
        }
        
        public override void Down()
        {
        }
    }
}
