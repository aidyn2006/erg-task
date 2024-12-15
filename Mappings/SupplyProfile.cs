using AutoMapper;
using ERG_Task.Models;

namespace ERG_Task.DTOs;

public class SupplyProfile : Profile
{
    public SupplyProfile()
    {
        CreateMap<Supply, SupplyDto>();
        CreateMap<SupplyDto, Supply>();
    }
}