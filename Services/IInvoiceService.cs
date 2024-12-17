using ERG_Task.DTOs;
using ERG_Task.Models;

namespace ERG_Task.Services.impl;

public interface IInvoiceService
{
    public Task<Invoice> CreateInvoiceAsync(InvoiceDto invoiceDto);
    public Task<Invoice> GetInvoiceByIdAsync(int id);
    public Task<List<Invoice>> GetInvoiceAsync();
    public Task<Invoice> UpdateInvoiceAsync(int id, InvoiceDto invoiceDto);
    public Task<string> DeleteInvoiceAsync(int id);
}