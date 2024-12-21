using ERG_Task.DTOs;
using ERG_Task.Models;

namespace ERG_Task.Services.impl;

public interface ISupplyService
{
    public Task<Supply> CreateSupplyAsync(SupplyDto supplyDto);
    public Task<Supply> GetSupplyByIdAsync(int id);
    public Task<List<Supply>> GetSupplyAsync(int? year);
    public Task<Supply> UpdateSupplyAsync(int id, SupplyDto supplyDto);
    public Task<string> DeleteSupplyAsync(int id);
    
}