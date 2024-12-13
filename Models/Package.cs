namespace ERG_Task.Models;

public class Package
{
    public int Id { get; set; }
    public int? ParentPackageId { get; set; }
    public int? TrainId { get; set; }
    public int StatusId { get; set; }
    public string? Name { get; set; }
    public int TypeId { get; set; }
    public int? OrderInTrain { get; set; }
    public DateTime? LoadingDate { get; set; }
    public string Comment { get; set; }
    public ICollection<PackageHistory> Packages { get; set; }= new List<PackageHistory>();
    public ICollection<Event> Events { get; set; } = new List<Event>();
}