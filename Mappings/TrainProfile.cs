using AutoMapper;
using ERG_Task.Models;

namespace ERG_Task.DTOs;

public class TrainProfile : Profile
{
    public TrainProfile()
    {
        CreateMap<Train, TrainDto>();
        CreateMap<TrainDto, Train>();
    }
}