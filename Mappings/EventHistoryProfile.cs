using AutoMapper;
using ERG_Task.Models;

namespace ERG_Task.DTOs;

public class EventHistoryProfile : Profile
{
    public EventHistoryProfile()
    {
        CreateMap<EventHistory, EventHistoryDto>();
        CreateMap<EventHistoryDto, EventHistory>();
    }
}