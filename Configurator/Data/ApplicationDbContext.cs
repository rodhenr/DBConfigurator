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
}