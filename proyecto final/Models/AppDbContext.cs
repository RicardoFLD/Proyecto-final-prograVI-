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
}
