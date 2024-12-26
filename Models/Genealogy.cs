namespace ERG_Task.Models;

public class Genealogy
{
    public int Id { get; set; }
    public long? ParentEventId { get; set; }
    public long? ChildEventId { get; set; }
    public float DimensionX { get; set; }
    public DateTime DateCreate { get; set; }
    
    public Event EventParent { get; set; }
    public Event EventChild { get; set; }
}