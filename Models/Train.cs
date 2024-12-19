using ERG_Task.utils;

namespace ERG_Task.Models;

public class Train
{
    public int Id { get; set; }
    public TrainStatusId TrainStatusId { get; set; }
    public DateTime DateCreate { get; set; }    
    public string NameTrain { get; set; }
    public string Comment { get; set; }
    public ICollection<TrainHistory> TrainHistory { get; set; } = new List<TrainHistory>();
    public ICollection<Package> Packages { get; set; } = new List<Package>();
}