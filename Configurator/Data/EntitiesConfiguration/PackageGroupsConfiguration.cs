using Configurator.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Configurator.Data.EntitiesConfiguration;

public class PackageGroupsConfiguration : IEntityTypeConfiguration<PackageGroup>
{
    public void Configure(EntityTypeBuilder<PackageGroup> builder)
    {
        builder
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
}