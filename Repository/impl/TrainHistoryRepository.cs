using ERG_Task.Data;
using ERG_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace ERG_Task.Repository.impl;

public class TrainHistoryRepository : ITrainHistoryRepository
{
    private readonly AppDbContext _context;

    public TrainHistoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TrainHistory>> GetAllAsync()
    {
        return await _context.TrainHistories.ToListAsync();
    }

    public async Task<TrainHistory?> GetByIdAsync(int id)
    {
        return await _context.TrainHistories.FirstOrDefaultAsync(th => th.Id==id);
    }

    public async Task AddAsync(TrainHistory train)
    {
        _context.TrainHistories.Add(train);
        _context.SaveChanges();
    }

    public async Task UpdateAsync(TrainHistory train)
    {
        _context.TrainHistories.Update(train);
        _context.SaveChanges();
    }

    public async Task DeleteAsync(int id)
    {
        var train = _context.TrainHistories.FirstOrDefault(th => th.Id == id);
        if (train != null)
        {

        _context.TrainHistories.Remove(train);
        _context.SaveChanges();
        }
    }
}