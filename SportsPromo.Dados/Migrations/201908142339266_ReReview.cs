namespace SportsPromo.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReReview : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PROVA_TEM_CATEGORIA",
                c => new
                    {
                        ProvaCategoriaId = c.Long(nullable: false),
                        CategoriaProvaId = c.Long(nullable: false),
                        Categoria_CategoriaId = c.Long(),
                        Prova_ProvaId = c.Long(),
                    })
                .PrimaryKey(t => new { t.ProvaCategoriaId, t.CategoriaProvaId })
                .ForeignKey("dbo.CATEGORIA", t => t.Categoria_CategoriaId)
                .ForeignKey("dbo.Provas", t => t.Prova_ProvaId)
                .Index(t => t.Categoria_CategoriaId)
                .Index(t => t.Prova_ProvaId);
            
            AddColumn("dbo.Provas", "ProvaLocal", c => c.String());
            AddColumn("dbo.Provas", "Esporte_EsporteId", c => c.Long());
            AlterColumn("dbo.Provas", "ProvaEventoId", c => c.Long(nullable: false));
            CreateIndex("dbo.Provas", "Esporte_EsporteId");
            AddForeignKey("dbo.Provas", "Esporte_EsporteId", "dbo.ESPORTE", "ESPORTE_ID");
            DropColumn("dbo.Provas", "ProvaEvento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Provas", "ProvaEvento", c => c.Long(nullable: false));
            DropForeignKey("dbo.PROVA_TEM_CATEGORIA", "Prova_ProvaId", "dbo.Provas");
            DropForeignKey("dbo.PROVA_TEM_CATEGORIA", "Categoria_CategoriaId", "dbo.CATEGORIA");
            DropForeignKey("dbo.Provas", "Esporte_EsporteId", "dbo.ESPORTE");
            DropIndex("dbo.PROVA_TEM_CATEGORIA", new[] { "Prova_ProvaId" });
            DropIndex("dbo.PROVA_TEM_CATEGORIA", new[] { "Categoria_CategoriaId" });
            DropIndex("dbo.Provas", new[] { "Esporte_EsporteId" });
            AlterColumn("dbo.Provas", "ProvaEventoId", c => c.String());
            DropColumn("dbo.Provas", "Esporte_EsporteId");
            DropColumn("dbo.Provas", "ProvaLocal");
            DropTable("dbo.PROVA_TEM_CATEGORIA");
        }
    }
}
