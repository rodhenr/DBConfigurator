using Configurator.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Configurator.Data;

public class DatabaseService
{
    private readonly ApplicationDbContext _context;

    public DatabaseService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Package>> GetPackagesAsync()
    {
        return await _context
            .Packages
            .Include(cc => cc.PackageGroups)
            .AsNoTracking()
            .ToListAsync();
    }
}