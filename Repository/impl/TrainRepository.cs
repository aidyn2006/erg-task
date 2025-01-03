using ERG_Task.Data;
using ERG_Task.Models;

namespace ERG_Task.Repository.impl;

using Microsoft.EntityFrameworkCore;

public class TrainRepository : ITrainRepository
{
    private readonly AppDbContext _context;

    public TrainRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Train>> GetAllAsync()
    {
        return await _context.Trains
            .Include(t => t.TrainHistory)  // Загружаем историю поезда
            .Include(t => t.Packages)  // Загружаем пакеты
            // Загружаем связанные счета для событий
            // .ThenInclude(p => p.Supply)  // Загружаем поставки для пакетов
            .ToListAsync();
    }


    public async Task<Train?> GetByIdAsync(int id)
    {
        return await _context.Trains
            .Include(t => t.TrainHistory)
            .Include(t => t.Packages)
            .ThenInclude(p => p.Events)  // Загружаем события для пакетов
            .ThenInclude(e => e.Invoice)  
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AddAsync(Train train)
    {
        await _context.Trains.AddAsync(train);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Train train)
    {
        _context.Trains.Update(train);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var train = await _context.Trains.FindAsync(id);
        if (train != null)
        {
            _context.Trains.Remove(train);
            await _context.SaveChangesAsync();
        }
    }
}
