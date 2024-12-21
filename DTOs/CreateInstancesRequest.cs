namespace ERG_Task.DTOs;

public class CreateInstancesRequest
{
    public CreateTrainRequest trainRequest { get; set; }
    public List<TransportInformation> transportInformation { get; set; }=new List<TransportInformation>();
}