namespace Listki.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Listks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UporabnikiId = c.Int(nullable: false),
                        Naslov = c.String(),
                        Vsebina = c.String(),
                        Datum_kreiranja = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Uporabnikis", t => t.UporabnikiId, cascadeDelete: true)
                .Index(t => t.UporabnikiId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Listks", "UporabnikiId", "dbo.Uporabnikis");
            DropIndex("dbo.Listks", new[] { "UporabnikiId" });
            DropTable("dbo.Listks");
        }
    }
}
