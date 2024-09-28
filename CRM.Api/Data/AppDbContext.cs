using CRM.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace CRM.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Cidade> Cidades { get; set; } = null;
    public DbSet<Estado> Estados { get; set; } = null;

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
