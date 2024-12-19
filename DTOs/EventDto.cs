using ERG_Task.utils;

namespace ERG_Task.DTOs;

public class EventDto
{
    public ProductId ProductId { get; set; }
    public int? PackageId { get; set; }
    public int? InvoiceId { get; set; }
    public StatusId StatusId { get; set; }
    public int? SupplyId { get; set; }
    public string? Name { get; set; }
    public float? Initial_Dimension_X { get; set; }
    public float? Final_Dimension_X { get; set; }
    public string? Comment { get; set; }
}