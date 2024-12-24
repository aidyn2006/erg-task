using ERG_Task.Models;

namespace ERG_Task.DTOs;

public class EventJoins
{
    public Event Event { get; set; }
    public Supply Supply { get; set; }
    public Invoice Invoice { get; set; }
    public Package Package { get; set; }
}