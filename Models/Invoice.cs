namespace ERG_Task.Models;

public class Invoice
{
    public int Id { get; set; }
    public string NumberInvoice { get; set; }
    public DateTime DateInvoice { get; set; }
    public DateTime DateShipping { get; set; }
    public DateTime DateCreate { get; set; }
    public int TypeId { get; set; }
    public ICollection<InvoiceHistory> InvoiceHistories { get; set; } = new List<InvoiceHistory>();
    public ICollection<Event> Events { get; set; } = new List<Event>();

}