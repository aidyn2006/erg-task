using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERG_Task.DTOs;
using ERG_Task.Models;
using ERG_Task.Repository.impl;
using ERG_Task.Services.impl;
using ERG_Task.Exception;
using ERG_Task.Services;

namespace ERG_Task.Tests
{
    public class SupplyServiceTests
    {
        private readonly Mock<ISupplyRepository> _mockSupplyRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly SupplyService _supplyService;

        public SupplyServiceTests()
        {
            _mockSupplyRepository = new Mock<ISupplyRepository>();
            _mockMapper = new Mock<IMapper>();
            _supplyService = new SupplyService(_mockSupplyRepository.Object, _mockMapper.Object);
        }
        
        [Fact]
        public async Task CreateSupplyAsync_ShouldReturnSupply_WhenSupplyDtoIsValid()
        {
            var supplyDto = new SupplyDto { };
            var supply = new Supply {};

            _mockMapper.Setup(m => m.Map<Supply>(It.IsAny<SupplyDto>())).Returns(supply);
            _mockSupplyRepository.Setup(r => r.AddAsync(It.IsAny<Supply>())).Returns(Task.CompletedTask);

            var result = await _supplyService.CreateSupplyAsync(supplyDto);

            Assert.NotNull(result);
            Assert.Equal(supply, result);
            _mockSupplyRepository.Verify(r => r.AddAsync(It.IsAny<Supply>()), Times.Once);
        }

        
        

        [Fact]
        public async Task GetSupplyAsync_ShouldReturnSupplies_WhenSuppliesExist()
        {
            var supplies = new List<Supply> { new Supply { Id = 1 }, new Supply { Id = 2 } };
            _mockSupplyRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(supplies);

            var result = await _supplyService.GetSupplyAsync(null);

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task UpdateSupplyAsync_ShouldThrowNotFoundException_WhenSupplyDoesNotExist()
        {
            var supplyId = 1;
            var supplyDto = new SupplyDto();
            _mockSupplyRepository.Setup(r => r.GetByIdAsync(supplyId)).ReturnsAsync((Supply)null);
            
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => _supplyService.UpdateSupplyAsync(supplyId, supplyDto));
            Assert.Equal("Supply with id: 1 was not found.", exception.Message);
        }

        [Fact]
        public async Task DeleteSupplyAsync_ShouldReturnSuccessMessage_WhenSupplyIsDeleted()
        {
            var supplyId = 1;
            var existingSupply = new Supply { Id = supplyId };
            _mockSupplyRepository.Setup(r => r.GetByIdAsync(supplyId)).ReturnsAsync(existingSupply);
            _mockSupplyRepository.Setup(r => r.DeleteAsync(supplyId)).Returns(Task.CompletedTask);

            var result = await _supplyService.DeleteSupplyAsync(supplyId);

            Assert.Equal("Succesfuly deleted", result);
            _mockSupplyRepository.Verify(r => r.DeleteAsync(supplyId), Times.Once);
        }
    }
}
