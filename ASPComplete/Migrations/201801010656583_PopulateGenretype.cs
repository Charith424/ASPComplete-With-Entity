namespace ASPComplete.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenretype : DbMigration
    {
        public override void Up()
        {
            Sql("Insert INTO Generes (Id,Genre) Values(1,'Comedy')");
            Sql("Insert INTO Generes (Id,Genre) Values(2,'Crime')");
            Sql("Insert INTO Generes (Id,Genre) Values(3,'Drama')");
            Sql("Insert INTO Generes (Id,Genre) Values(4,'Fantasy')");
            Sql("Insert INTO Generes (Id,Genre) Values(5,'Horror')");
        }

        public override void Down()
        {
        }
    }
}
