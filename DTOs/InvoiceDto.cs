namespace ERG_Task.DTOs;

public class InvoiceDto
{
    public string NumberInvoice { get; set; }
    public DateTime DateInvoice { get; set; }
    public DateTime DateShipping { get; set; }
    public int TypeId { get; set; }
}