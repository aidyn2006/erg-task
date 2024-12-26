using ERG_Task.DTOs;
using ERG_Task.Models;

namespace ERG_Task.Services.impl;

public interface IGenealogyService
{
    public Task<Genealogy> CreateGenealogyAsync(GenealogyDto genealogyDto);
    public Task<Genealogy> GetGenealogyByIdAsync(int id);
    public Task<List<Genealogy>> GetGenealogyAsync(int? year);
    public Task<Genealogy> UpdateGenealogyAsync(int id, GenealogyDto genealogyDto);
    public Task<string> DeleteGenealogyAsync(int id);
    public Task<Genealogy> CreateNewGenealogyAsync(EventDto eventDto, float dimensionX);
    public  Task<Genealogy> CreateListEvent(List<EventDto> eventDtoList, float dimensionX);
    public Task<string> DeleteEventAsync(int id, bool isHardDelete);

}