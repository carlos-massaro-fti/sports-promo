namespace SportsPromo.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nova : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ESPORTE",
                c => new
                    {
                        ESPORTE_ID = c.Long(nullable: false, identity: true),
                        ESPORTE_NOME = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.ESPORTE_ID);
            
            AlterColumn("dbo.GENERO", "GENERO_NOME", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GENERO", "GENERO_NOME", c => c.String());
            DropTable("dbo.ESPORTE");
        }
    }
}
