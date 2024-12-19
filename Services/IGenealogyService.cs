using ERG_Task.DTOs;
using ERG_Task.Models;

namespace ERG_Task.Services.impl;

public interface IGenealogyService
{
    public Task<Genealogy> CreateGenealogyAsync(GenealogyDto genealogyDto);
    public Task<Genealogy> GetGenealogyByIdAsync(int id);
    public Task<List<Genealogy>> GetGenealogyAsync();
    public Task<Genealogy> UpdateGenealogyAsync(int id, GenealogyDto genealogyDto);
    public Task<string> DeleteGenealogyAsync(int id);
    public Task<List<Genealogy>> GetEventsByYearAsync(int year);

}