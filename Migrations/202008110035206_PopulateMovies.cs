namespace MovieRentaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("Set Identity_insert Movies ON");
            Sql("Insert into Movies (Id, Name, genreId, InStock, DateAdded, ReleaseDate) values (1, 'Bahubali', 1, 5, '05/21/2016', '05/19/2016')");
            Sql("Insert into Movies (Id, Name, genreId, InStock, DateAdded, ReleaseDate) values (2, 'Terminator', 3, 6, '05/21/2018', '05/19/2018')");
            Sql("Insert into Movies (Id, Name, genreId, InStock, DateAdded, ReleaseDate) values (3, 'Titani', 2, 3, '05/21/2008', '02/19/1999')");
            Sql("Insert into Movies (Id, Name, genreId, InStock, DateAdded, ReleaseDate) values (4, 'Ratatouli', 6, 1, '03/21/2010', '03/25/2010')");
        }
        
        public override void Down()
        {
        }
    }
}
