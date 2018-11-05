namespace SAGE_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjetos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projetos",
                c => new
                    {
                        ProjetoId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Descricao = c.String(),
                        DataProva = c.DateTime(nullable: false),
                        NumVagas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjetoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Projetos");
        }
    }
}
