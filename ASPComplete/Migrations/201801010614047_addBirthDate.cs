namespace ASPComplete.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBirthDate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate = '2017/01/10' WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
