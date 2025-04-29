namespace proyecto_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumno",
                c => new
                    {
                        IdentificadorAlumno = c.Int(nullable: false, identity: true),
                        Fecha_Ingreso = c.DateTime(nullable: false),
                        Cedula = c.String(nullable: false),
                        Genero = c.String(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Nombre = c.String(nullable: false),
                        PrimerApellido = c.String(nullable: false),
                        SegundoApellido = c.String(nullable: false),
                        DireccionFisica = c.String(nullable: false),
                        TelefonoPrincipal = c.String(nullable: false),
                        TelefonoSecundario = c.String(nullable: false),
                        CorreoElectronico = c.String(nullable: false),
                        IdentificadorProvincia = c.Int(nullable: false),
                        IdentificadorCanton = c.Int(nullable: false),
                        IdentificadorDistrito = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdentificadorAlumno)
                .ForeignKey("dbo.Canton", t => t.IdentificadorCanton, cascadeDelete: true)
                .ForeignKey("dbo.Distrito", t => t.IdentificadorDistrito, cascadeDelete: true)
                .ForeignKey("dbo.Provincia", t => t.IdentificadorProvincia, cascadeDelete: true)
                .Index(t => t.IdentificadorProvincia)
                .Index(t => t.IdentificadorCanton)
                .Index(t => t.IdentificadorDistrito);
            
            CreateTable(
                "dbo.Canton",
                c => new
                    {
                        IdentificadorCanton = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        FechaInsercion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        usuarioModificacion = c.String(nullable: false),
                        IdentificadorProvincia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdentificadorCanton)
                .ForeignKey("dbo.Provincia", t => t.IdentificadorProvincia, cascadeDelete: true)
                .Index(t => t.IdentificadorProvincia);
            
            CreateTable(
                "dbo.Distrito",
                c => new
                    {
                        IdentificadorDistrito = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        FechaInsercion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        usuarioModificacion = c.String(nullable: false),
                        IdentificadorCanton = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdentificadorDistrito)
                .ForeignKey("dbo.Canton", t => t.IdentificadorCanton, cascadeDelete: true)
                .Index(t => t.IdentificadorCanton);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        IdentificadorProvincia = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        FechaInsercion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        usuarioModificacion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdentificadorProvincia);
            
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
            DropForeignKey("dbo.Canton", "IdentificadorProvincia", "dbo.Provincia");
            DropForeignKey("dbo.Alumno", "IdentificadorProvincia", "dbo.Provincia");
            DropForeignKey("dbo.Distrito", "IdentificadorCanton", "dbo.Canton");
            DropForeignKey("dbo.Alumno", "IdentificadorDistrito", "dbo.Distrito");
            DropForeignKey("dbo.Alumno", "IdentificadorCanton", "dbo.Canton");
            DropIndex("dbo.Carreras", new[] { "Id_Grado" });
            DropIndex("dbo.Distrito", new[] { "IdentificadorCanton" });
            DropIndex("dbo.Canton", new[] { "IdentificadorProvincia" });
            DropIndex("dbo.Alumno", new[] { "IdentificadorDistrito" });
            DropIndex("dbo.Alumno", new[] { "IdentificadorCanton" });
            DropIndex("dbo.Alumno", new[] { "IdentificadorProvincia" });
            DropTable("dbo.Materias");
            DropTable("dbo.Grados");
            DropTable("dbo.Carreras");
            DropTable("dbo.Provincia");
            DropTable("dbo.Distrito");
            DropTable("dbo.Canton");
            DropTable("dbo.Alumno");
        }
    }
}
