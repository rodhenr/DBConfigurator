using Configurator.Data.Models;

namespace Configurator.Interfaces;

public interface IPackagesService
{
    Task<IEnumerable<PackageGroup>> GetPackageGroupsAsync();
    Task<IEnumerable<Package>> GetPackagesAsync(int packageGroupId);
}