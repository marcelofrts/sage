namespace SAGE_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaterias : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        MateriaId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Descricao = c.String(),
                        Cor = c.String(),
                    })
                .PrimaryKey(t => t.MateriaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Materias");
        }
    }
}
