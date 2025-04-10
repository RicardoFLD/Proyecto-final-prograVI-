namespace proyecto_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gradoes",
                c => new
                    {
                        IdGrado = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.IdGrado);
            
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        IdentificadorMateria = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Codigo = c.Int(nullable: false),
                        NumeroCreditos = c.Int(nullable: false),
                        NumeroHoras = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdentificadorMateria);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Materias");
            DropTable("dbo.Gradoes");
        }
    }
}
