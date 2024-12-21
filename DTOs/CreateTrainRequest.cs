using ERG_Task.utils;

namespace ERG_Task.DTOs;

public class CreateTrainRequest
{
    public string Name { get; set; }
    public StatusId StatusId { get; set; }
    public DateTime DateCreate { get; set; }
}