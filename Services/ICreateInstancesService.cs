using ERG_Task.DTOs;

namespace ERG_Task.Services.impl;

public interface ICreateInstancesService
{
    public Task<CreateInstancesRequest> CreateInstancesAsync(CreateInstancesRequest createInstancesRequest);
}