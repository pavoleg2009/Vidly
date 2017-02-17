namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillGenreTable : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Genres (Name) VALUES ('Action')");
            Sql("INSERT INTO Genres (Name) VALUES ('Adventure')");
            Sql("INSERT INTO Genres (Name) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (Name) VALUES ('Crime')");
            Sql("INSERT INTO Genres (Name) VALUES ('Drama')");
            Sql("INSERT INTO Genres (Name) VALUES ('Fantasy')");
            Sql("INSERT INTO Genres (Name) VALUES ('Historical')");
            Sql("INSERT INTO Genres (Name) VALUES ('Historical fiction')");
            Sql("INSERT INTO Genres (Name) VALUES ('Horror')");
            Sql("INSERT INTO Genres (Name) VALUES ('Mystery')");
            Sql("INSERT INTO Genres (Name) VALUES ('Philosophical')");
            Sql("INSERT INTO Genres (Name) VALUES ('Political')");
            Sql("INSERT INTO Genres (Name) VALUES ('Romance')");
            Sql("INSERT INTO Genres (Name) VALUES ('Saga')");
            Sql("INSERT INTO Genres (Name) VALUES ('Satire')");
            Sql("INSERT INTO Genres (Name) VALUES ('Science fiction')");
            Sql("INSERT INTO Genres (Name) VALUES ('Thriller')");
            Sql("INSERT INTO Genres (Name) VALUES ('Western')");
        }
        
        public override void Down()
        {
        }
    }
}
