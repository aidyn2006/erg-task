using AutoMapper;
using ERG_Task.Models;

namespace ERG_Task.DTOs;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Event, EventDto>();
        CreateMap<EventDto, Event>();
        CreateMap<Event, EventHistory>();
    }
}