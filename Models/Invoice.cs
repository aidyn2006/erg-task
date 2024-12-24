using ERG_Task.utils;

namespace ERG_Task.Models;

public class Invoice
{
    public int Id { get; set; }
    public string NumberInvoice { get; set; }
    public DateTime DateInvoice { get; set; }
    public DateTime DateShipping { get; set; }
    public DateTime DateCreate { get; set; }
    public TypeId TypeId { get; set; }
    public virtual ICollection<InvoiceHistory> InvoiceHistories { get; set; } = new List<InvoiceHistory>();
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

}