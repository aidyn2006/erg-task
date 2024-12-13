namespace ERG_Task.Models;

public class PackageHistory
{
    public int Id { get; set; }
    public DateTime DateModify { get; set; }
    public int PackageId { get; set; } 
    public int? ParentPackageId { get; set; }
    public int? TrainId { get; set; }
    public string? Name { get; set; }
    public int TypeId { get; set; }
    public int OrderInTrain { get; set; }
    public string Comment { get; set; }
}