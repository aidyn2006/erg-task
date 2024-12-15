using AutoMapper;
using ERG_Task.Models;

namespace ERG_Task.DTOs;

public class GenealogyProfile : Profile
{
    public GenealogyProfile()
    {
        CreateMap<Genealogy, GenealogyDto>();
        CreateMap<GenealogyDto, Genealogy>();
    }
}