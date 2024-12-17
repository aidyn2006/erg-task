namespace ERG_Task.DTOs;

public class PackageDto
{
    public int? ParentPackageId { get; set; }
    public int? TrainId { get; set; }
    public int StatusId { get; set; }
    public string? Name { get; set; }
    public int TypeId { get; set; }
    public int? OrderInTrain { get; set; }
    public string Comment { get; set; }
}