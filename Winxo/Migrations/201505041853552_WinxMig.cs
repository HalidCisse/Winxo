namespace Winxo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WinxMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personnels",
                c => new
                    {
                        PersonnelGuid = c.Guid(nullable: false),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.PersonnelGuid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Personnels");
        }
    }
}
