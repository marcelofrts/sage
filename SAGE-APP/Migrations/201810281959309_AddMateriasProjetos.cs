namespace SAGE_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMateriasProjetos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MateriasProjetos",
                c => new
                    {
                        MateriaProjetoId = c.Int(nullable: false, identity: true),
                        ProjetoId = c.Int(nullable: false),
                        MateriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MateriaProjetoId, t.ProjetoId, t.MateriaId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MateriasProjetos");
        }
    }
}
