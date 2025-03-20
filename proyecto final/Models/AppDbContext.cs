using System.Collections.Generic;
using System.Data.Entity;

public class AppDbContext : DbContext
{
    public DbSet<Grado> Grados { get; set; }
}
