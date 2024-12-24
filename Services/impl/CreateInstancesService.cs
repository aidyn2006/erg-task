using AutoMapper;
using ERG_Task.Data;
using ERG_Task.DTOs;
using ERG_Task.Models;
using ERG_Task.Services.impl;

namespace ERG_Task.Services;

public class CreateInstancesService : ICreateInstancesService
{
    public readonly IMapper _mapper;
    private readonly IPackageService _packageService;
    private readonly IEventService _eventService;
    private readonly ITrainService _trainService;
    private readonly AppDbContext _context;

    public CreateInstancesService(IMapper mapper, IPackageService packageService, IEventService eventService, AppDbContext context)
    {
        _mapper = mapper;
        _packageService = packageService;
        _eventService = eventService;
        _context = context;
    }

    public async Task<CreateInstancesRequest> CreateInstancesAsync(CreateInstancesRequest createInstancesRequest)
    {
        if (createInstancesRequest == null)
        {
            throw new ArgumentNullException(nameof(createInstancesRequest));
        }

        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var transportInfo = createInstancesRequest.TransportInformations?.FirstOrDefault();
                if (transportInfo == null)
                {
                    throw new InvalidOperationException("Transport information is missing.");
                }

                var packageDto = transportInfo.Package;
                if (packageDto != null)
                {
                    await _packageService.CreatePackageAsync(packageDto);
                }
                else
                {
                    throw new InvalidOperationException("Package is missing in transport information.");
                }

                var eventToCreate = transportInfo.Event;
                if (eventToCreate != null)
                {
                    await _eventService.CreateEventAsync(eventToCreate);
                }
                else
                {
                    throw new InvalidOperationException("Event is missing in transport information.");
                }

                await transaction.CommitAsync();
            }
            catch (System.Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"Error: {ex.Message}");
                throw; 
            }
        }
        return createInstancesRequest;  
    }
}
