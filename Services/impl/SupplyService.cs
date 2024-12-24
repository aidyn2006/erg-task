using AutoMapper;
using ERG_Task.DTOs;
using ERG_Task.Exception;
using ERG_Task.Models;
using ERG_Task.Repository.impl;
using ERG_Task.Services.impl;

namespace ERG_Task.Services;

public class SupplyService : ISupplyService
{
    private readonly ISupplyRepository _supplyRepository;
    private readonly IMapper _mapper;

    public SupplyService(ISupplyRepository supplyRepository, IMapper mapper)
    {
        _supplyRepository = supplyRepository;
        _mapper = mapper;
    }

    public async Task<Supply> CreateSupplyAsync(SupplyDto supplyDto)
    {
        if (supplyDto == null)
            throw new ArgumentNullException(nameof(supplyDto));

        var supply = _mapper.Map<Supply>(supplyDto);

        supply.DateCreate=DateTime.UtcNow;
        
        await _supplyRepository.AddAsync(supply);

        return supply;    
    }

    public async Task<Supply> GetSupplyByIdAsync(int id)
    {
        var byId=await _supplyRepository.GetByIdAsync(id);
        if (byId == null)
        {
            throw new NotFoundException($"Supply with id: {id} was not found");
        }
        return byId;      
    }

    
    public async Task<List<Supply>> GetSupplyAsync(int? year)
    {
        var byId=await _supplyRepository.GetAllAsync();
        if (byId == null)
        {
            throw new NotFoundException("There was no suppply found");
        }

        if (year.HasValue)
        {
            byId=byId.Where(p => p.DateCreate.Year == year.Value);
        }
        return byId.ToList();    }

    public async Task<Supply> UpdateSupplyAsync(int id, SupplyDto supplyDto)
    {
        var existingGenealogy = await _supplyRepository.GetByIdAsync(id);
        if (existingGenealogy == null)
        {
            throw new NotFoundException($"Supply with id: {id} was not found.");
        }

        _mapper.Map(supplyDto, existingGenealogy);
        
        
        await _supplyRepository.UpdateAsync(existingGenealogy);
        
        return existingGenealogy;       }

    public async Task<string> DeleteSupplyAsync(int id)
    {
        var existing = _supplyRepository.GetByIdAsync(id);
        if (existing == null)
        {
            throw new KeyNotFoundException($"Supply with id: {id} was not found.");
        }
        await _supplyRepository.DeleteAsync(id);
        return "Succesfuly deleted";    
    }
    
    

    
}