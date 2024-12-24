using AutoMapper;
using ERG_Task.DTOs;
using ERG_Task.Exception;
using ERG_Task.Models;
using ERG_Task.Repository;
using ERG_Task.Services.impl;
using ERG_Task.utils;

namespace ERG_Task.Services;

public class PackageService : IPackageService
{
    private readonly IPackageRepository _packageRepository;
    private readonly IMapper _mapper;
    private readonly IPackageHistoryRepository _packageHistoryRepository;

    public PackageService(IPackageRepository packageRepository, IMapper mapper, IPackageHistoryRepository packageHistoryRepository)
    {
        _packageRepository = packageRepository;
        _mapper = mapper;
        _packageHistoryRepository = packageHistoryRepository;
    }

    public async Task<Package> CreatePackageAsync(PackageDto packageDto)
    {
        if (packageDto == null)
            throw new ArgumentNullException(nameof(packageDto));

        var newEvent = _mapper.Map<Package>(packageDto);

        newEvent.LoadingDate = DateTime.UtcNow;
       

        await _packageRepository.AddAsync(newEvent);

        var newEventHistory= _mapper.Map<PackageHistory>(newEvent);
        
        newEventHistory.PackageId =newEvent.Id;
        newEventHistory.DateModify = DateTime.UtcNow;
        
        await _packageHistoryRepository.AddAsync(newEventHistory);
        
        return newEvent;    }

    public async Task<Package> GetPackageByIdAsync(int id)
    {
        var byId=await _packageRepository.GetByIdAsync(id);
        if (byId == null)
        {
            throw new NotFoundException($"Package with id: {id} was not found");
        }

        return byId;    }

    public async Task<List<Package>> GetPackageAsync(int? type,int? status)
    {
        var typeId=await _packageRepository.GetAllAsync(type,status);
        if (typeId == null)
        {
            throw new NotFoundException("There was no package found");
        }
        return typeId.ToList();
    }

    public async Task<Package> UpdatePackageAsync(int id, PackageDto packageDto)
    {
        var existingEvent = await _packageRepository.GetByIdAsync(id);
        if (existingEvent == null)
        {
            throw new NotFoundException($"Package with id: {id} was not found.");
        }

        _mapper.Map(packageDto, existingEvent);
        
        existingEvent.LoadingDate = DateTime.UtcNow;


        await _packageRepository.UpdateAsync(existingEvent);

        

        var newEventHistory= _mapper.Map<PackageHistory>(existingEvent);
        
        newEventHistory.PackageId =existingEvent.Id;
        newEventHistory.DateModify = DateTime.UtcNow;
        
        await _packageHistoryRepository.AddAsync(newEventHistory);
        return existingEvent;
    }

    public async Task<string> DeletePackageAsync(int id)
    {
        var existingEvent = _packageRepository.GetByIdAsync(id);
        if (existingEvent == null)
        {
            throw new NotFoundException($"Event with id: {id} was not found.");
        }
        await _packageRepository.DeleteAsync(id);
        return "Succesfuly deleted";    }

    // public Task<Package> GetJoin(int id)
    // {
    //     var existingEvent = _packageRepository.GetByIdAsync(id);
    //     if (existingEvent == null)
    //     {
    //         throw new NotFoundException($"Event with id: {id} was not found.");
    //     }    
    // }
}