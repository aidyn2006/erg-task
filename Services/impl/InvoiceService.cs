using AutoMapper;
using ERG_Task.DTOs;
using ERG_Task.Exception;
using ERG_Task.Models;
using ERG_Task.Repository;
using ERG_Task.Services.impl;

namespace ERG_Task.Services;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _repository;
    private readonly IMapper _mapper;
    private readonly IInvoiceHistoryRepository _invoiceHistoryRepository;

    public InvoiceService(IInvoiceRepository repository, IMapper mapper, IInvoiceHistoryRepository invoiceHistoryRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _invoiceHistoryRepository = invoiceHistoryRepository;
    }

    public async Task<Invoice> CreateInvoiceAsync(InvoiceDto invoiceDto)
    {
        if (invoiceDto == null)
            throw new ArgumentNullException(nameof(invoiceDto));

        var newInvoice = _mapper.Map<Invoice>(invoiceDto);

        newInvoice.DateInvoice = DateTime.Now;
        newInvoice.DateCreate=DateTime.Now;
        newInvoice.DateShipping=DateTime.Now;

        await _repository.AddAsync(newInvoice);

        var newInvoiceHistory = _mapper.Map<InvoiceHistory>(newInvoice);
        newInvoiceHistory.InvoiceId = newInvoice.Id;
        newInvoiceHistory.DateModify=DateTime.Now;
       
        await _invoiceHistoryRepository.AddAsync(newInvoiceHistory);
        
        return newInvoice;    }

    public async Task<Invoice> GetInvoiceByIdAsync(int id)
    {
        var byId=await _repository.GetByIdAsync(id);
        if (byId == null)
        {
            throw new NotFoundException($"Invoice with id: {id} was not found");
        }
        return byId;    }

    public async Task<List<Invoice>> GetInvoiceAsync()
    {
        var byId=await _repository.GetAllAsync();
        if (byId == null)
        {
            throw new NotFoundException("There was no invoices found");
        }
        return byId.ToList();    }

    public async Task<Invoice> UpdateInvoiceAsync(int id, InvoiceDto invoiceDto)
    {
        var existingGenealogy = await _repository.GetByIdAsync(id);
        if (existingGenealogy == null)
        {
            throw new NotFoundException($"Invoice with id: {id} was not found.");
        }

        _mapper.Map(invoiceDto, existingGenealogy);
        
        
        await _repository.UpdateAsync(existingGenealogy);
        
        var newEventHistory= _mapper.Map<InvoiceHistory>(existingGenealogy);
        
        newEventHistory.DateModify = DateTime.UtcNow;
        
        await _invoiceHistoryRepository.AddAsync(newEventHistory);
        
        return existingGenealogy;     }

    public async Task<string> DeleteInvoiceAsync(int id)
    {
        var existing = _repository.GetByIdAsync(id);
        if (existing == null)
        {
            throw new NotFoundException($"Genealogy with id: {id} was not found.");
        }
        await _repository.DeleteAsync(id);
        return "Succesfuly deleted";    }
}