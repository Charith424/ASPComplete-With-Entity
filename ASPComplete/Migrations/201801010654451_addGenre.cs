namespace ASPComplete.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGenre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Generes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "GenereId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "GenereId");
            AddForeignKey("dbo.Movies", "GenereId", "dbo.Generes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenereId", "dbo.Generes");
            DropIndex("dbo.Movies", new[] { "GenereId" });
            DropColumn("dbo.Movies", "GenereId");
            DropTable("dbo.Generes");
        }
    }
}
