using ERG_Task.DTOs;
using ERG_Task.Models;

namespace ERG_Task.Services.impl;

public interface ITrainService
{
    public Task<Train> CreateTrainAsync(TrainDto trainDto);
    public Task<Train> GetTrainByIdAsync(int id);
    public Task<List<Train>> GetTrainAsync();
    public Task<Train> UpdateTrainAsync(int id, TrainDto trainDto);
    public Task<string> DeleteTrainAsync(int id);  
    public Task<List<Train>> GetTrainsByStatusAsync(int status);
    public Task<List<Train>> GetTrainsByYearAsync(int year);

}