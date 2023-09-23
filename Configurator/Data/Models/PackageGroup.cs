namespace Configurator.Data.Models;

public class PackageGroup
{
    public int Id { get; set; }
    public required string PackageGroupName { get; set; }

    public IEnumerable<Package> Packages { get; set; }
}