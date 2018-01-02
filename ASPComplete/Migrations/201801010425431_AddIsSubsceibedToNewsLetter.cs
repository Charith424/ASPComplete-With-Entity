namespace ASPComplete.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubsceibedToNewsLetter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubsceibedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubsceibedToNewsLetter");
        }
    }
}
