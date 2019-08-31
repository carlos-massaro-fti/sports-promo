namespace SportsPromo.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CATEGORIA",
                c => new
                    {
                        CATEGORIA_ID = c.Long(nullable: false, identity: true),
                        CATEGORIA_NOME = c.String(nullable: false, maxLength: 256),
                        CategoriaIdadeMin = c.Int(nullable: false),
                        CategoriaIdadeMax = c.Int(nullable: false),
                        CategoriaGeneroId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.CATEGORIA_ID)
                .ForeignKey("dbo.GENERO", t => t.CategoriaGeneroId)
                .Index(t => t.CategoriaGeneroId);
            
            CreateTable(
                "dbo.GENERO",
                c => new
                    {
                        GENERO_ID = c.Long(nullable: false, identity: true),
                        GENERO_NOME = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.GENERO_ID);
            
            CreateTable(
                "dbo.INSCRICAO",
                c => new
                    {
                        INSCRICAO_ID = c.Long(nullable: false, identity: true),
                        INSCRICAO_NOME = c.String(nullable: false, maxLength: 256),
                        INSCRICAO_EMAIL = c.String(nullable: false, maxLength: 256),
                        INSCRICAO_NASCIMENTO = c.DateTime(nullable: false),
                        INSCRICAO_RFID = c.String(nullable: false, maxLength: 256),
                        INSCRICAO_EQUIPE_ID = c.Long(nullable: false),
                        INSCRICAO_GENERO_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.INSCRICAO_ID)
                .ForeignKey("dbo.EQUIPE", t => t.INSCRICAO_EQUIPE_ID)
                .ForeignKey("dbo.GENERO", t => t.INSCRICAO_GENERO_ID)
                .Index(t => t.INSCRICAO_EQUIPE_ID)
                .Index(t => t.INSCRICAO_GENERO_ID);
            
            CreateTable(
                "dbo.EQUIPE",
                c => new
                    {
                        EQUIPE_ID = c.Long(nullable: false, identity: true),
                        EQUIPE_NOME = c.String(nullable: false, maxLength: 256),
                        EquipeProvaId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.EQUIPE_ID)
                .ForeignKey("dbo.Provas", t => t.EquipeProvaId)
                .Index(t => t.EquipeProvaId);
            
            CreateTable(
                "dbo.Provas",
                c => new
                    {
                        ProvaId = c.Long(nullable: false, identity: true),
                        ProvaEsporteId = c.Long(nullable: false),
                        ProvaComecaEm = c.DateTime(nullable: false),
                        ProvaLocal = c.String(),
                        ProvaEventoId = c.Long(nullable: false),
                        Esporte_EsporteId = c.Long(),
                        Evento_EventoId = c.Long(),
                    })
                .PrimaryKey(t => t.ProvaId)
                .ForeignKey("dbo.ESPORTE", t => t.Esporte_EsporteId)
                .ForeignKey("dbo.EVENTO", t => t.Evento_EventoId)
                .Index(t => t.Esporte_EsporteId)
                .Index(t => t.Evento_EventoId);
            
            CreateTable(
                "dbo.ESPORTE",
                c => new
                    {
                        ESPORTE_ID = c.Long(nullable: false, identity: true),
                        ESPORTE_NOME = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.ESPORTE_ID);
            
            CreateTable(
                "dbo.EVENTO",
                c => new
                    {
                        EventoId = c.Long(nullable: false, identity: true),
                        EventoLocal = c.String(),
                        EventoDataInicio = c.DateTime(nullable: false),
                        EventoDataFinal = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventoId);
            
            CreateTable(
                "dbo.MARCO",
                c => new
                    {
                        MARCO_ID = c.Long(nullable: false, identity: true),
                        MARCO_LAT = c.Decimal(nullable: false, precision: 20, scale: 8),
                        MARCO_LON = c.Decimal(nullable: false, precision: 20, scale: 8),
                        MarcoProvaId = c.Long(nullable: false),
                        MarcoReceptorId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.MARCO_ID)
                .ForeignKey("dbo.Provas", t => t.MarcoProvaId)
                .ForeignKey("dbo.RECEPTOR", t => t.MarcoReceptorId)
                .Index(t => t.MarcoProvaId)
                .Index(t => t.MarcoReceptorId);
            
            CreateTable(
                "dbo.RECEPTOR",
                c => new
                    {
                        RECEPTOR_ID = c.Long(nullable: false, identity: true),
                        RECEPTOR_CODIGO = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.RECEPTOR_ID);
            
            CreateTable(
                "dbo.CHECAGEM",
                c => new
                    {
                        CHECAGEM_ID = c.Long(nullable: false, identity: true),
                        ChecagemReceptorId = c.Long(nullable: false),
                        CHECAGEM_EM = c.DateTime(nullable: false),
                        CHECAGEM_RFID = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.CHECAGEM_ID)
                .ForeignKey("dbo.RECEPTOR", t => t.ChecagemReceptorId)
                .Index(t => t.ChecagemReceptorId);
            
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
            
            CreateTable(
                "dbo.USUARIO",
                c => new
                    {
                        USUARIO_ID = c.Long(nullable: false, identity: true),
                        USUARIO_NOME = c.String(nullable: false, maxLength: 256),
                        USUARIO_EMAIL = c.String(nullable: false, maxLength: 256),
                        USUARIO_EH_ATIVADO = c.Boolean(nullable: false),
                        USUARIO_SENHA = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.USUARIO_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CATEGORIA", "CategoriaGeneroId", "dbo.GENERO");
            DropForeignKey("dbo.INSCRICAO", "INSCRICAO_GENERO_ID", "dbo.GENERO");
            DropForeignKey("dbo.INSCRICAO", "INSCRICAO_EQUIPE_ID", "dbo.EQUIPE");
            DropForeignKey("dbo.EQUIPE", "EquipeProvaId", "dbo.Provas");
            DropForeignKey("dbo.PROVA_TEM_CATEGORIA", "Prova_ProvaId", "dbo.Provas");
            DropForeignKey("dbo.PROVA_TEM_CATEGORIA", "Categoria_CategoriaId", "dbo.CATEGORIA");
            DropForeignKey("dbo.MARCO", "MarcoReceptorId", "dbo.RECEPTOR");
            DropForeignKey("dbo.CHECAGEM", "ChecagemReceptorId", "dbo.RECEPTOR");
            DropForeignKey("dbo.MARCO", "MarcoProvaId", "dbo.Provas");
            DropForeignKey("dbo.Provas", "Evento_EventoId", "dbo.EVENTO");
            DropForeignKey("dbo.Provas", "Esporte_EsporteId", "dbo.ESPORTE");
            DropIndex("dbo.PROVA_TEM_CATEGORIA", new[] { "Prova_ProvaId" });
            DropIndex("dbo.PROVA_TEM_CATEGORIA", new[] { "Categoria_CategoriaId" });
            DropIndex("dbo.CHECAGEM", new[] { "ChecagemReceptorId" });
            DropIndex("dbo.MARCO", new[] { "MarcoReceptorId" });
            DropIndex("dbo.MARCO", new[] { "MarcoProvaId" });
            DropIndex("dbo.Provas", new[] { "Evento_EventoId" });
            DropIndex("dbo.Provas", new[] { "Esporte_EsporteId" });
            DropIndex("dbo.EQUIPE", new[] { "EquipeProvaId" });
            DropIndex("dbo.INSCRICAO", new[] { "INSCRICAO_GENERO_ID" });
            DropIndex("dbo.INSCRICAO", new[] { "INSCRICAO_EQUIPE_ID" });
            DropIndex("dbo.CATEGORIA", new[] { "CategoriaGeneroId" });
            DropTable("dbo.USUARIO");
            DropTable("dbo.PROVA_TEM_CATEGORIA");
            DropTable("dbo.CHECAGEM");
            DropTable("dbo.RECEPTOR");
            DropTable("dbo.MARCO");
            DropTable("dbo.EVENTO");
            DropTable("dbo.ESPORTE");
            DropTable("dbo.Provas");
            DropTable("dbo.EQUIPE");
            DropTable("dbo.INSCRICAO");
            DropTable("dbo.GENERO");
            DropTable("dbo.CATEGORIA");
        }
    }
}
