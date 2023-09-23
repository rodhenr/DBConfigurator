using Configurator.Data.Models;
using Configurator.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Configurator.Data;

public class PackagesService : IPackagesService
{
    private readonly ApplicationDbContext _context;

    public PackagesService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PackageGroup>> GetPackageGroupsAsync()
    {
        var data = await _context
            .PackageGroups
            .AsNoTracking()
            .ToListAsync();

        if (data is null) throw new Exception("Data is null!");

        return data;
    }

    public async Task<IEnumerable<Package>> GetPackagesAsync(int packageGroupId)
    {
        return await _context
            .Packages
            .Where(p => p.PackageGroupId == packageGroupId)
            .AsNoTracking()
            .ToListAsync();
    }
}