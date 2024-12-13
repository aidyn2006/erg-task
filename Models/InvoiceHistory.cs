namespace ERG_Task.Models;

public class InvoiceHistory
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public DateTime DateModify { get; set; }
    public DateTime DateInvoice { get; set; }
    public string NumberInvoice { get; set; }
    public DateTime DateCreate { get; set; }
}