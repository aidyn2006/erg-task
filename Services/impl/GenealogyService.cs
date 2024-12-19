using AutoMapper;
using ERG_Task.DTOs;
using ERG_Task.Exception;
using ERG_Task.Models;
using ERG_Task.Repository;
using ERG_Task.Services.impl;

namespace ERG_Task.Services;

public class GenealogyService : IGenealogyService
{
    private readonly IGenealogyRepository _genealogyRepository;
    private readonly IMapper _mapper;

    public GenealogyService(IGenealogyRepository genealogyRepository, IMapper mapper)
    {
        _genealogyRepository = genealogyRepository;
        _mapper = mapper;
    }

    public async Task<Genealogy> CreateGenealogyAsync(GenealogyDto genealogyDto)
    {
        if (genealogyDto == null)
            throw new ArgumentNullException(nameof(genealogyDto));

        var genealogy = _mapper.Map<Genealogy>(genealogyDto);

        genealogy.DateCreate=DateTime.UtcNow;
        
        await _genealogyRepository.AddAsync(genealogy);

        return genealogy;
    }

    public async Task<Genealogy> GetGenealogyByIdAsync(int id)
    {
        var byId=await _genealogyRepository.GetByIdAsync(id);
        if (byId == null)
        {
            throw new NotFoundException($"Genealogy with id: {id} was not found");
        }
        return byId;    
    }

    public async Task<List<Genealogy>> GetGenealogyAsync()
    {
        var byId=await _genealogyRepository.GetAllAsync();
        if (byId == null)
        {
            throw new NotFoundException("There was no genealogy found");
        }
        return byId.ToList();
        
    }

    public async Task<Genealogy> UpdateGenealogyAsync(int id, GenealogyDto genealogyDto)
    {
        var existingGenealogy = await _genealogyRepository.GetByIdAsync(id);
        if (existingGenealogy == null)
        {
            throw new NotFoundException($"Genealogy with id: {id} was not found.");
        }

        _mapper.Map(genealogyDto, existingGenealogy);
        
        
        await _genealogyRepository.UpdateAsync(existingGenealogy);
        
        return existingGenealogy;    
    }

    public async Task<string> DeleteGenealogyAsync(int id)
    {
        var existing = _genealogyRepository.GetByIdAsync(id);
        if (existing == null)
        {
            throw new NotFoundException($"Genealogy with id: {id} was not found.");
        }
        await _genealogyRepository.DeleteAsync(id);
        return "Succesfuly deleted";
    }
    public async Task<List<Genealogy>> GetEventsByYearAsync(int year)
    {
        var events = await _genealogyRepository.GetAllAsync();
        events = events.Where(s => s.DateCreate.Year == year).ToList();

        return events.ToList();
    }
}