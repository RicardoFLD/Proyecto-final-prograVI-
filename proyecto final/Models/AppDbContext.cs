using proyecto_final.Models;
using System.Collections.Generic;
using System.Data.Entity;

public class AppDbContext : DbContext
{
    public AppDbContext() : base("name=AppDbContext")
    {
    }
    public DbSet<Grado> Grados { get; set; }
    public DbSet<Materia> Materias { get; set; }
    public DbSet<Carreras> Carreras { get; set; }
    public DbSet<Distrito> Distritos { get; set; }
    public DbSet<Canton> Cantones { get; set; }
    public DbSet<Provincia> Provincias { get; set; }
    public DbSet<Alumno> Alumnos { get; set; }
}
