using Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infra.Data;
public class DbContexto : DbContext
{
    public DbContexto(DbContextOptions options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
