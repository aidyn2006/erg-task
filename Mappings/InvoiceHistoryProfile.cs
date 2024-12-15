using AutoMapper;
using ERG_Task.Models;

namespace ERG_Task.DTOs;

public class InvoiceHistoryProfile : Profile
{
    public InvoiceHistoryProfile()
    {
        CreateMap<InvoiceHistory, InvoiceHistoryDto>();
        CreateMap<InvoiceHistoryDto, InvoiceHistory>();
    }
}