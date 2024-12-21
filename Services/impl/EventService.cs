using AutoMapper;
using ERG_Task.DTOs;
using ERG_Task.Exception;
using ERG_Task.Models;
using ERG_Task.Repository;
using ERG_Task.Services.impl;
using ERG_Task.utils;

namespace ERG_Task.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly IEventHistoryRepository _eventHistoryRepository;
    private readonly IMapper _mapper;

    public EventService(IEventRepository eventRepository, IMapper mapper, IEventHistoryRepository eventHistoryRepository)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
        _eventHistoryRepository = eventHistoryRepository;
    }

    public async Task<Event> CreateEventAsync(EventDto eventToCreate)
    {
        if (eventToCreate == null)
            throw new ArgumentNullException(nameof(eventToCreate));

        var newEvent = _mapper.Map<Event>(eventToCreate);

        newEvent.DateCreate = DateTime.UtcNow;
        newEvent.DateStart = DateTime.UtcNow;
        newEvent.DateEvent = DateTime.UtcNow;

        await _eventRepository.AddAsync(newEvent);

        var newEventHistory= _mapper.Map<EventHistory>(newEvent);
        
        newEventHistory.EventId = (int)newEvent.Id;
        newEventHistory.DateModify = DateTime.UtcNow;
        
        await _eventHistoryRepository.AddAsync(newEventHistory);
        
        return newEvent;
    }


    public async Task<Event> GetEventByIdAsync(int id)
    {
        var byId=await _eventRepository.GetByIdAsync(id);
        if (byId == null)
        {
            throw new NotFoundException($"Event with id: {id} was not found");
        }

        return byId;
    }

    public async Task<List<Event>> GetEventsAsync(int? year,int? status, DateTime? daaStart, DateTime? dataCreate)
    {
        var events=await _eventRepository.GetAllAsync();
        if (events == null)
        {
            throw new NotFoundException("There was no events found");
        }

        if (year.HasValue)
        {
            events = events.Where(e => e.DateCreate.Year == year.Value);
        }

        if (status.HasValue)
        {
            events=events.Where(e=>e.StatusId==(StatusId)status).ToList();
        }

        if (daaStart.HasValue && dataCreate.HasValue)
        {
            events = events.Where(e => e.DateStart >= daaStart.Value && e.DateStart <= dataCreate.Value).ToList();
        }

        
        else if (daaStart.HasValue) 
        {
            events = events.Where(e => e.DateStart >= daaStart.Value).ToList();
        }
        
        else if (dataCreate.HasValue) 
        {
            events = events.Where(e => e.DateStart <= dataCreate.Value).ToList();
        }
        
        return events.ToList();
    }

    public async Task<Event> UpdateEventAsync(int id, EventDto eventToUpdate)
    {
        var existingEvent = await _eventRepository.GetByIdAsync(id);
        if (existingEvent == null)
        {
            throw new NotFoundException($"Event with id: {id} was not found.");
        }

        _mapper.Map(eventToUpdate, existingEvent);
        
        existingEvent.DateStart = DateTime.UtcNow; 
        existingEvent.DateEvent = DateTime.UtcNow;
        existingEvent.DateCreate = DateTime.UtcNow;

        await _eventRepository.UpdateAsync(existingEvent);

        

        var newEventHistory= _mapper.Map<EventHistory>(existingEvent);
        
        newEventHistory.EventId = (int)existingEvent.Id;
        newEventHistory.DateModify = DateTime.UtcNow;
        
        await _eventHistoryRepository.AddAsync(newEventHistory);
        return existingEvent;
    }


    public async Task<string> DeleteEventAsync(int id)
    {
        var existingEvent = _eventRepository.GetByIdAsync(id);
        if (existingEvent == null)
        {
            throw new NotFoundException($"Event with id: {id} was not found.");
        }
        await _eventRepository.DeleteAsync(id);
        return "Succesfuly deleted";
    }
    
}