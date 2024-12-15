using AutoMapper;
using ERG_Task.Models;

namespace ERG_Task.DTOs;

public class TrainHistoryProfile : Profile
{
    public TrainHistoryProfile()
    {
        CreateMap<TrainHistory, TrainHistoryDto>();
        CreateMap<TrainHistoryDto, TrainHistory>();
    }
}