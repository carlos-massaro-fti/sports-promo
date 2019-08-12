namespace SportsPromo.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GENERO",
                c => new
                    {
                        GENERO_ID = c.Long(nullable: false, identity: true),
                        GENERO_NOME = c.String(),
                    })
                .PrimaryKey(t => t.GENERO_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GENERO");
        }
    }
}
