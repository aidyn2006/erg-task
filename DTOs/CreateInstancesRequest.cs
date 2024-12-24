namespace ERG_Task.DTOs;

public class CreateInstancesRequest
{
    public CreateTrainRequest TrainRequest { get; set; }
    public List<TransportInformation> TransportInformations { get; set; }=new List<TransportInformation>();
}