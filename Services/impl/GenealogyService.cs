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



    

    public async Task<Genealogy> CreateNewGenealogyAsync(int eventId, float dimensionX)
    {
        if (eventId <= 0)
            throw new ArgumentException("Invalid event ID.");
    
        var parentEvent = await _eventRepository.GetByIdAsync(eventId);
        
        var childEvent = new Event
        {
            ProductId = ProductId.ВЗВЕШЕН,
            PackageId = 21,
            InvoiceId = 11,
            StatusId = StatusId.В_ПУТИ,
            SupplyId = 7,
            DateCreate = DateTime.UtcNow,
            DateStart = DateTime.UtcNow,
            DateEvent = DateTime.UtcNow,
            Initial_Dimension_X = 100,
            Final_Dimension_X = 500,
            Comment = "Nothing to write",
            Name = "Child Event",
        };
        await _eventRepository.AddAsync(childEvent);
    
        if (dimensionX > 0)
        {
            if (parentEvent.Final_Dimension_X >= dimensionX)
            {
                parentEvent.Final_Dimension_X -= dimensionX;
                await _eventRepository.UpdateAsync(parentEvent);
            }
            else
            {
                throw new ArgumentException("DimensionX больше чем у Парент Файнал Дайменшна.");
            }
        }
    
        var genealogy = new Genealogy
        {
            ParentEventId = eventId,
            ChildEventId = childEvent.Id,
            DimensionX = dimensionX,
            DateCreate = DateTime.UtcNow,
            EventParent = parentEvent,
            EventChild = childEvent
        };
    
        await _genealogyRepository.AddAsync(genealogy);
    
        return genealogy;
    }

    public async Task<List<Genealogy>> CreateGenealogyListAsync(int[] eventIds, float dimensionX)
    {
        if (eventIds == null || !eventIds.Any())
            throw new ArgumentNullException(nameof(eventIds));
    
        var genealogies = new List<Genealogy>();
    
        var childEvent = new Event
        {
            ProductId = ProductId.ВЗВЕШЕН,
            PackageId = 21,
            InvoiceId = 11,
            StatusId = StatusId.В_ПУТИ,
            SupplyId = 7,
            DateCreate = DateTime.UtcNow,
            DateStart = DateTime.UtcNow,
            DateEvent = DateTime.UtcNow,
            Initial_Dimension_X = 100,
            Final_Dimension_X = 500,
            Comment = "Nothing to write",
            Name = "Child Event",
        };
        await _eventRepository.AddAsync(childEvent);
    
        foreach (var eventId in eventIds)
        {
            var parentEvent = await _eventRepository.GetByIdAsync(eventId);
    
            if (dimensionX > 0)
            {
                if (parentEvent.Final_Dimension_X >= dimensionX)
                {
                    parentEvent.Final_Dimension_X -= dimensionX;
                    await _eventRepository.UpdateAsync(parentEvent);
                }
                else
                {
                    throw new ArgumentException("DimensionX больше чем у Парент Файнал Дайменшна.");
                }
            }
    
            var genealogy = new Genealogy
            {
                ParentEventId = eventId,
                ChildEventId = childEvent.Id,
                DimensionX = dimensionX,
                DateCreate = DateTime.UtcNow,
                EventParent = parentEvent,
                EventChild = childEvent
            };
    
            await _genealogyRepository.AddAsync(genealogy);
            genealogies.Add(genealogy);
        }
    
        return genealogies;
    }


    public async Task<string> DeleteEventAsync(int id, bool isHardDelete)
    {
        var eventEntity = await _eventRepository.GetByIdAsync(id);
        if (eventEntity == null)
            throw new NotFoundException($"Event with id: {id} was not found.");
    
        var genealogies = await _genealogyRepository.GetGenealogiesByChildIdAsync(id);
    
        if (isHardDelete)
        {
            
            if (genealogies != null && genealogies.Any())
            {
                foreach (var genealogy in genealogies)
                {
                    if (genealogy.ParentEventId.HasValue)
                    {
                        var parentEvent = await _eventRepository.GetByIdAsync(Convert.ToInt32(genealogy.ParentEventId.Value));
                        if (parentEvent != null)
                        {
                            parentEvent.Final_Dimension_X += (genealogy.DimensionX)/genealogies.Count();
                            await _eventRepository.UpdateAsync(parentEvent);
                        }
                    }
                    await _genealogyRepository.DeleteAsync(genealogy.Id);
                }
            }
            await _eventRepository.DeleteAsync(eventEntity.Id);
        }
        else
        {
            if (genealogies != null && genealogies.Any())
            {
                foreach (var genealogy in genealogies)
                {
                    if (genealogy.ParentEventId.HasValue)
                    {
                        var parentEvent = await _eventRepository.GetByIdAsync(Convert.ToInt32(genealogy.ParentEventId.Value));
                        if (parentEvent != null)
                        {
                            parentEvent.Final_Dimension_X += genealogy.DimensionX;
                            await _eventRepository.UpdateAsync(parentEvent);
                        }
                    }
                }
            }
    
            eventEntity.StatusId = StatusId.УДАЛЕН; 
            await _eventRepository.UpdateAsync(eventEntity);
        }
    
        return "Event successfully deleted.";
    }



}