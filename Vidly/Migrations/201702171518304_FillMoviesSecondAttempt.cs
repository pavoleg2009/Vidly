namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillMoviesSecondAttempt : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES (1, 'The Hangover', 3, 11/06/2009, 21/06/2009, 5)");
            Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES (2, 'Terminator', 16, 26/10/1984, 07/03/2014, 12)");
            Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES (3, 'Die Hard', 1, 20/06/1998, 17/02/2015, 0)");
            Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES (4, 'Toy Story', 3, 22/11/1995, 01/01/2014, 1)");
            Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES (5, 'Titanic', 13, 20/02/1997, GetDate(), 8)");
        }

        public override void Down()
        {
        }
    }
}
