using AutoMapper;
using ERG_Task.Data;
using ERG_Task.DTOs;
using ERG_Task.Exception;
using ERG_Task.Models;
using ERG_Task.Repository;
using ERG_Task.Services.impl;
using ERG_Task.utils;

namespace ERG_Task.Services;

public class GenealogyService : IGenealogyService
{
    private readonly IGenealogyRepository _genealogyRepository;
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    

    public GenealogyService(IGenealogyRepository genealogyRepository, IEventRepository eventRepository, IMapper mapper)
    {
        _genealogyRepository = genealogyRepository;
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<Genealogy> CreateGenealogyAsync(GenealogyDto genealogyDto)
    {
        if (genealogyDto == null)
            throw new ArgumentNullException(nameof(genealogyDto));

        var genealogy = _mapper.Map<Genealogy>(genealogyDto);

        genealogy.DateCreate = DateTime.UtcNow;

        await _genealogyRepository.AddAsync(genealogy);

        return genealogy;
    }

    public async Task<Genealogy> GetGenealogyByIdAsync(int id)
    {
        var byId = await _genealogyRepository.GetByIdAsync(id);
        if (byId == null)
        {
            throw new NotFoundException($"Genealogy with id: {id} was not found");
        }

        return byId;
    }

    public async Task<List<Genealogy>> GetGenealogyAsync(int? year)
    {
        var byId = await _genealogyRepository.GetAllAsync();
        if (byId == null)
        {
            throw new NotFoundException("There was no genealogy found");
        }

        if (year.HasValue)
        {
            byId = byId.Where(genealogy => genealogy.DateCreate.Year == year.Value);
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




   public async Task<Genealogy> CreateNewGenealogyAsync(EventDto eventDto, float dimensionX)
    {
        if (eventDto == null)
            throw new ArgumentNullException(nameof(eventDto));
    
        var eventEntity = _mapper.Map<Event>(eventDto);
        eventEntity.DateCreate = DateTime.UtcNow;
        eventEntity.DateStart = DateTime.UtcNow;
        eventEntity.DateEvent = DateTime.UtcNow;
        eventEntity.Initial_Dimension_X = dimensionX;
    
        
        await _eventRepository.AddAsync(eventEntity);
    
        var genealogy = new Genealogy
        {
            ParentEventId = null,  
            ChildEventId = eventEntity.Id,
            DimensionX = dimensionX,
            DateCreate = DateTime.UtcNow
        };
    
        
        await _genealogyRepository.AddAsync(genealogy);
    
        return genealogy;
    }

    public async Task<Genealogy> CreateListEvent(List<EventDto> eventDtoList, float dimensionX)
    {
        if (eventDtoList == null || !eventDtoList.Any())
            throw new ArgumentNullException(nameof(eventDtoList));
    
        var events = _mapper.Map<List<Event>>(eventDtoList);
    
        foreach (var eventEntity in events)
        {
            eventEntity.DateCreate = DateTime.UtcNow;
            eventEntity.DateStart = DateTime.UtcNow;
            eventEntity.DateEvent = DateTime.UtcNow;
            eventEntity.Initial_Dimension_X = dimensionX;
        }
    
        
        await _eventRepository.AddEventsAsync(events);
    
        
        var genealogy = new Genealogy
        {
            ParentEventId = null, 
            ChildEventId = events.Last().Id,
            DimensionX = dimensionX,
            DateCreate = DateTime.UtcNow
        };
    
        
        await _genealogyRepository.AddAsync(genealogy);
    
        return genealogy;
    }

    public async Task<string> DeleteEventAsync(int id, bool isHardDelete)
    {
        var eventEntity = await _eventRepository.GetByIdAsync(id);
        if (eventEntity == null)
            throw new NotFoundException($"Event with id: {id} was not found.");

        if (isHardDelete)
        {
            
            var genealogies = await _genealogyRepository.GetGenealogiesByChildIdAsync(id);

            if (genealogies != null && genealogies.Any())
            {
                foreach (var genealogy in genealogies)
                {
                    
                    if (genealogy.ParentEventId != null)
                    {
                        var parentEvent = await _genealogyRepository.GetByIdAsync((int)genealogy.ParentEventId);
                        if (parentEvent != null)
                        {
                            parentEvent.DimensionX += genealogy.DimensionX;
                            await _genealogyRepository.UpdateAsync(parentEvent); 
                        }
                    }

                    await _eventRepository.DeleteAsync(id); 
                }
            }

            await _eventRepository.DeleteAsync(id);  
        }
        else
        {
            eventEntity.StatusId = StatusId.УДАЛЕН; 
            await _eventRepository.UpdateAsync(eventEntity); 
        }

        return "Event successfully deleted.";
    }


}