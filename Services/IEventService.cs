using ERG_Task.DTOs;
using ERG_Task.Models;

namespace ERG_Task.Services.impl;

public interface IEventService
{
    public Task<Event> CreateEventAsync(EventDto eventToCreate);
    public Task<Event> GetEventByIdAsync(int id);
    public Task<List<Event>> GetEventsAsync();
    public Task<Event> UpdateEventAsync(int id, EventDto eventToUpdate);
    public Task<string> DeleteEventAsync(int id);
    public Task<List<Event>> GetEventsByStatusAsync(int categoryId);
    public Task<List<Event>> GetEventsByYearAsync(int year);
    


}