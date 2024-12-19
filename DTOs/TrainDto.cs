using ERG_Task.utils;

namespace ERG_Task.DTOs;

public class TrainDto
{
    public TrainStatusId TrainStatusId { get; set; }
    public string NameTrain { get; set; }
    public string Comment { get; set; }
}