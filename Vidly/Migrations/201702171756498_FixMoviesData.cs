namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixMoviesData : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies " +
                "SET DateAdded = CAST(22-12-2014 as DATETIME)" +
                "WHERE Id=1");
        }
        
        public override void Down()
        {
        }
    }
}
