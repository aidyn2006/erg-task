using ERG_Task.Data;
using ERG_Task.Models;
using ERG_Task.utils;
using Microsoft.EntityFrameworkCore;

namespace ERG_Task.Repository.impl;

public class PackageRepository : IPackageRepository
{
    private readonly AppDbContext _context;

    public PackageRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Package>> GetAllAsync(int? type,int? status)
    {
        return await _context.Packages
            .Where(t => (!type.HasValue || t.TypeId == (TypeId)type.Value) && 
                        (!status.HasValue || t.StatusId == (StatusId)status.Value))
            .Include(s => s.Events)
            .Include(s=>s.Packages)
            .ToListAsync();
    }

    public async Task<Package> GetByIdAsync(int id)
    {
        var res= await _context.Packages
            .Include(s => s.Events)
            .ThenInclude(p=>p.Invoice)
            .Include(p=>p.Events)
            .ThenInclude(p=>p.Supply)
            .Include(p => p.Packages) 
            .FirstOrDefaultAsync(p => p.Id == id);

        return res;
    }

    public async Task AddAsync(Package package)
    {
        await _context.Packages.AddAsync(package);
        await _context.SaveChangesAsync();    
    }

    public async Task UpdateAsync(Package package)
    {
        _context.Packages.Update(package);
        await _context.SaveChangesAsync();    }

    public async Task DeleteAsync(int id)
    {
        var package = await _context.Packages.FindAsync(id);
        if (package != null)
        {
            _context.Packages.Remove(package);
            await _context.SaveChangesAsync();
        }    
    }
}