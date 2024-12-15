using ERG_Task.Models;

namespace ERG_Task.Repository;

public interface IInvoiceHistoryRepository
{
    Task<IEnumerable<InvoiceHistory>> GetAllAsync();
    Task<InvoiceHistory> GetByIdAsync(int id);
    Task AddAsync(InvoiceHistory invoiceHistory);
    Task UpdateAsync(InvoiceHistory invoiceHistory);
    Task DeleteAsync(int id);
}