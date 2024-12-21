using ERG_Task.DTOs;
using ERG_Task.Models;

namespace ERG_Task.Services.impl;

public interface IEventService
{
    public Task<Event> CreateEventAsync(EventDto eventToCreate);
    public Task<Event> GetEventByIdAsync(int id);
    public Task<List<Event>> GetEventsAsync(int? year, int? status, DateTime? daaStart, DateTime? dataCreate);
    public Task<Event> UpdateEventAsync(int id, EventDto eventToUpdate);
    public Task<string> DeleteEventAsync(int id);
    
}