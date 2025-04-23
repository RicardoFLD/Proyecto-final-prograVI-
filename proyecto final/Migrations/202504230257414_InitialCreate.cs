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
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                        Id_Grado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdentificadorCarrera)
                .ForeignKey("dbo.Grados", t => t.Id_Grado, cascadeDelete: true)
                .Index(t => t.Id_Grado);
            
            CreateTable(
                "dbo.Grados",
                c => new
                    {
                        IdentificadorGrado = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdentificadorGrado);
            
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
            DropForeignKey("dbo.Carreras", "Id_Grado", "dbo.Grados");
            DropIndex("dbo.Carreras", new[] { "Id_Grado" });
            DropTable("dbo.Materias");
            DropTable("dbo.Grados");
            DropTable("dbo.Carreras");
        }
    }
}
