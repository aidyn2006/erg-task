using AutoMapper;
using ERG_Task.DTOs;
using ERG_Task.Models;
using ERG_Task.Repository;
using ERG_Task.Services;
using Moq;
using Xunit;

namespace ERG_Task.Tests;

public class TrainServiceTest
{
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<ITrainRepository> _trainRepository;
    private readonly Mock<ITrainHistoryRepository> _trainHistoryRepository;
    private readonly TrainService _trainService;

    public TrainServiceTest()
    {
        _mapper = new Mock<IMapper>();
        _trainRepository = new Mock<ITrainRepository>();
        _trainHistoryRepository = new Mock<ITrainHistoryRepository>();

        _trainService = new TrainService(_trainRepository.Object, _mapper.Object, _trainHistoryRepository.Object);
    }
    
    [Fact]
    public async Task Should_Not_Call_Repository_If_Dto_Is_Null()
    {
        TrainDto? trainDto = null;

        await Assert.ThrowsAsync<ArgumentNullException>(() => _trainService.CreateTrainAsync(trainDto));

        _trainRepository.Verify(t => t.AddAsync(It.IsAny<Train>()), Times.Never);
    }

    [Fact]
    public async Task Create_Train_Should_Return_Created_Train()
    {
        var train = new TrainDto() { };
        var trains = new Train() { };
        var trainHistory = new TrainHistory();

        
        _mapper.Setup(m=>m.Map<Train>(It.IsAny<TrainDto>())).Returns(trains);
        _trainRepository.Setup(t=>t.AddAsync(It.IsAny<Train>())).Returns(Task.CompletedTask);
        
        _mapper.Setup(i=>i.Map<TrainHistory>(It.IsAny<Train>())).Returns(trainHistory);
        _trainHistoryRepository.Setup(t=>t.AddAsync(It.IsAny<TrainHistory>())).Returns(Task.CompletedTask);
        
        var result=await _trainService.CreateTrainAsync(train);
        
        Assert.NotNull(result);
        Assert.Equal(result,trains);
        
        _trainRepository.Verify(t=>t.AddAsync(It.IsAny<Train>()), Times.Once);
        _trainHistoryRepository.Verify(t=>t.AddAsync(It.IsAny<TrainHistory>()), Times.Once);
    }

    [Fact]
    public async Task Update_Train_Should_Return_Updated_Train()
    {
        var train = new TrainDto() { };
        var trains = new Train() { };
        var trainHistory = new TrainHistory();
        int traindId = 1;
        
        _trainRepository.Setup(t=>t.GetByIdAsync(1)).ReturnsAsync(trains);  
        _mapper.Setup(m=>m.Map<Train>(It.IsAny<TrainDto>())).Returns(trains);

        _mapper.Setup(m => m.Map<TrainHistory>(It.IsAny<Train>())).Returns(trainHistory);
        
        var result=await _trainService.UpdateTrainAsync(traindId, train);
        
        Assert.NotNull(result);
        Assert.Equal(result,trains);
        
        _trainRepository.Verify(m=>m.UpdateAsync(It.IsAny<Train>()),Times.Once);
        _trainHistoryRepository.Verify(t=>t.AddAsync(It.IsAny<TrainHistory>()),Times.Once);
    }

    [Fact]
    public async Task Get_Train_Should_Return_Train()
    {
        int trainId = 1;
        
        var train =new Train() { };
        
        _trainRepository.Setup(t=>t.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(train);
        
        var result=_trainService.GetTrainByIdAsync(trainId);
        
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    
}