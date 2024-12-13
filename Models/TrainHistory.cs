namespace ERG_Task.Models;

public class TrainHistory
{
    public int Id { get; set; }
    public DateTime DateModify { get; set; }
    public int TrainId { get; set; }
    public int TrainStatusId { get; set; }
    public DateTime DateCreate { get; set; }
    public string NameTrain { get; set; }
    public string Comment { get; set; }
}