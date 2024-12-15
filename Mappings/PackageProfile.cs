using AutoMapper;
using ERG_Task.Models;

namespace ERG_Task.DTOs;

public class PackageProfile : Profile
{
    public PackageProfile()
    {
        CreateMap<Package, PackageDto>();
        CreateMap<PackageDto, Package>();
    }
}