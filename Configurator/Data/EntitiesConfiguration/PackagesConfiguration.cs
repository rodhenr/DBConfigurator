using Configurator.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Configurator.Data.EntitiesConfiguration;

public class PackagesConfiguration : IEntityTypeConfiguration<Package>
{
    public void Configure(EntityTypeBuilder<Package> builder)
    {
        builder
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasKey(p => new { p.PackageGroupId, p.TableName });

        builder.HasOne(p => p.PackageGroups)
            .WithMany(p => p.Packages)
            .HasForeignKey(p => p.PackageGroupId);
    }
}