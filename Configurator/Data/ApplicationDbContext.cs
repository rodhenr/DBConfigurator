using Configurator.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Configurator.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Package> Packages { get; set; }
    public DbSet<PackageGroup> PackageGroups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.Entity<PackageGroup>().HasData(
            new PackageGroup { Id = 1, PackageGroupName = "Folha" },
            new PackageGroup { Id = 2, PackageGroupName = "Contábil" },
            new PackageGroup { Id = 3, PackageGroupName = "Traduções" }
        );

        modelBuilder.Entity<Package>().HasData(
            new Package { Id = 1, PackageGroupId = 3, TableName = "TRAD_Aluno" },
            new Package { Id = 2, PackageGroupId = 3, TableName = "TRAD_Escola" },
            new Package { Id = 3, PackageGroupId = 3, TableName = "TRAD_Professor" }
        );
    }
}