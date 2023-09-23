namespace Configurator.Data.Models;

public class Package
{
    public int Id { get; set; }
    public required int PackageGroupId { get; set; }
    public required string TableName { get; set; }

    public PackageGroup? PackageGroups { get; set; }
}