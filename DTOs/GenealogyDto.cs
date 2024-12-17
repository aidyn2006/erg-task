namespace ERG_Task.DTOs;

public class GenealogyDto
{
    public long? ParentEventId { get; set; }
    public long? ChildEventId { get; set; }
    public float DimensionX { get; set; }
    public DateTime DateCreate { get; set; }
    
}