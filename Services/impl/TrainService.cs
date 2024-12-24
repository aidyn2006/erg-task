using AutoMapper;
using ERG_Task.DTOs;
using ERG_Task.Exception;
using ERG_Task.Models;
using ERG_Task.Repository;
using ERG_Task.Services.impl;
using ERG_Task.utils;

namespace ERG_Task.Services;

public class TrainService : ITrainService
{
    private readonly ITrainRepository _trainRepository;
    private readonly IMapper _mapper;
    private readonly ITrainHistoryRepository _trainHistoryRepository;

    public TrainService(ITrainRepository trainRepository, IMapper mapper,
        ITrainHistoryRepository trainHistoryRepository)
    {
        _trainRepository = trainRepository;
        _mapper = mapper;
        _trainHistoryRepository = trainHistoryRepository;
    }

    public async Task<Train> CreateTrainAsync(TrainDto trainDto)
    {
        if (trainDto == null)
            throw new ArgumentNullException(nameof(trainDto));

        var newEvent = _mapper.Map<Train>(trainDto);

        newEvent.DateCreate = DateTime.UtcNow;
        await _trainRepository.AddAsync(newEvent);

        var newEventHistory = _mapper.Map<TrainHistory>(newEvent);

        newEventHistory.TrainId = newEvent.Id;
        newEventHistory.DateModify = DateTime.UtcNow;

        await _trainHistoryRepository.AddAsync(newEventHistory);
        return newEvent;
    }

    public async Task<Train> GetTrainByIdAsync(int id)
    {
        var byId = await _trainRepository.GetByIdAsync(id);
        if (byId == null)
        {
            throw new NotFoundException($"Train with id: {id} was not found");
        }

        return byId;
    }

    public async Task<List<Train>> GetTrainAsync(int? year,int? status)
    {
        var trains = await _trainRepository.GetAllAsync();
        if (trains == null)
        {
            throw new NotFoundException("There was no trains found");
        }

        if (year.HasValue)
        {
            trains=trains.Where(e=>e.DateCreate.Year==year.Value).ToList();
        }

        if (status.HasValue)
        {
         trains=trains.Where(e=>e.TrainStatusId==(TrainStatusId)status).ToList();   
        }
        return trains.ToList();
    }

    public async Task<Train> UpdateTrainAsync(int id, TrainDto trainDto)
    {
        var existingEvent = await _trainRepository.GetByIdAsync(id);
        if (existingEvent == null)
        {
            throw new NotFoundException($"Train with id: {id} was not found.");
        }

        _mapper.Map(trainDto, existingEvent);

        existingEvent.DateCreate = DateTime.UtcNow;

        await _trainRepository.UpdateAsync(existingEvent);



        var newEventHistory = _mapper.Map<TrainHistory>(existingEvent);

        newEventHistory.TrainId = existingEvent.Id;
        newEventHistory.DateModify = DateTime.UtcNow;

        await _trainHistoryRepository.AddAsync(newEventHistory);
        return existingEvent;
    }

    public async Task<string> DeleteTrainAsync(int id)
    {
        var existingEvent = _trainRepository.GetByIdAsync(id);
        if (existingEvent == null)
        {
            throw new NotFoundException($"train with id: {id} was not found.");
        }

        await _trainRepository.DeleteAsync(id);
        return "Succesfuly deleted";
    }

    // public Task<Train> GetAllJoinsAsync(int id)
    // {
    //     var existingEvent = _trainRepository.GetByIdAsync(id);
    //     if (existingEvent == null)
    //     {
    //         throw new NotFoundException($"train with id: {id} was not found.");
    //     }
    //
    //     return existingEvent;
    // }
}