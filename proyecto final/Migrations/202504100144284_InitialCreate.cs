namespace proyecto_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carreras",
                c => new
                    {
                        IdentificadorCarrera = c.Int(nullable: false, identity: true),
                        Id_Grado = c.Int(nullable: false),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdentificadorCarrera)
                .ForeignKey("dbo.Gradoes", t => t.Id_Grado, cascadeDelete: true)
                .Index(t => t.Id_Grado);
            
            CreateTable(
                "dbo.Gradoes",
                c => new
                    {
                        IdGrado = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdGrado);
            
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        IdentificadorMateria = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Codigo = c.String(nullable: false),
                        NumeroCreditos = c.Int(nullable: false),
                        NumeroHoras = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdentificadorMateria);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carreras", "Id_Grado", "dbo.Gradoes");
            DropIndex("dbo.Carreras", new[] { "Id_Grado" });
            DropTable("dbo.Materias");
            DropTable("dbo.Gradoes");
            DropTable("dbo.Carreras");
        }
    }
}
