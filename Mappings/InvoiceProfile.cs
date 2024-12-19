using AutoMapper;
using ERG_Task.Models;

namespace ERG_Task.DTOs;

public class InvoiceProfile : Profile
{
    public InvoiceProfile()
    {
        CreateMap<Invoice, InvoiceDto>();
        CreateMap<InvoiceDto, Invoice>();
        CreateMap<Invoice, InvoiceHistory>();
    }
}