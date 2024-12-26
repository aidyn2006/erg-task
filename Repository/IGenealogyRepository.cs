using System.Collections;
using ERG_Task.Models;

namespace ERG_Task.Repository;

public interface IGenealogyRepository
{
    Task<IEnumerable<Genealogy>> GetAllAsync();
    Task<Genealogy> GetByIdAsync(int id);
    Task AddAsync(Genealogy genealogy);
    Task UpdateAsync(Genealogy genealogy);
    Task DeleteAsync(int id);
    Task<List<Genealogy>> GetGenealogiesByChildIdAsync(int id);
}