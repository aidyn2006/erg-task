using AutoMapper;
using ERG_Task.Models;

namespace ERG_Task.DTOs;

public class PackageHistoryProfile : Profile
{
    public PackageHistoryProfile()
    {
        CreateMap<PackageHistory, PackageHistoryDto>();
        CreateMap<PackageHistoryDto, PackageHistory>();
    }
}