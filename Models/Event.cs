using ERG_Task.utils;

namespace ERG_Task.Models;

public class Event 
{
    public int Id { get; set; }
    public ProductId ProductId { get; set; }
    public int? PackageId { get; set; }
    public int? InvoiceId { get; set; }
    public StatusId StatusId { get; set; }
    public int? SupplyId { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEvent { get; set; }
    public DateTime DateCreate { get; set; }
    public string? Name { get; set; }
    public float? Initial_Dimension_X { get; set; }
    public float? Final_Dimension_X { get; set; }
    public string? Comment { get; set; }
    public ICollection<EventHistory> EventHistories { get; set; } = new List<EventHistory>();
    public  Invoice? Invoice { get; set; }
    public  Supply? Supply { get; set; }
    
}