namespace ASPComplete.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("Insert INTO Movies (Name,ReleaseDate,AddedDate,Stock,GenereId) Values(1,'Bright (I)','2017/01/01','2017/02/01',5,2)");
            Sql("Insert INTO Movies (Name,ReleaseDate,AddedDate,Stock,GenereId) Values(2,'Star Wars: The Last Jedi ','2017/02/11','2017/03/15',7,4)");
            Sql("Insert INTO Movies (Name,ReleaseDate,AddedDate,Stock,GenereId) Values(3,'Jumanji: Welcome to the Jungle ','2017/05/19','2017/06/20',10,1)");
            Sql("Insert INTO Movies (Name,ReleaseDate,AddedDate,Stock,GenereId) Values(4,'Justice League','2017/11/01','2017/12/10',15,5)");

        }

        public override void Down()
        {
        }
    }
}
