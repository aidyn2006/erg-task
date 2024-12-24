using ERG_Task.DTOs;
using ERG_Task.Models;
using ERG_Task.Services.impl;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ERG_Task.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class TrainController : Controller
{
    private readonly ITrainService _trainService;

    public TrainController(ITrainService trainService)
    {
        _trainService = trainService;
    }
    
    
        [HttpGet]
        [SwaggerOperation(Summary = "This operation retrieves all trains.")]
        [SwaggerResponse(200, Description = "Successful response with a list of trains.")]
        [SwaggerResponse(204, Description = "No content - no trains found.")]
        [SwaggerResponse(500, Description = "Internal server error.")]
        public async Task<IActionResult> GetAll([FromQuery] int? year, [FromQuery] int? status)
        {
            var supplies = await _trainService.GetTrainAsync(year,status);

            if (supplies == null || !supplies.Any())
            {
                return NoContent();
            }
            return Ok(supplies);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "This operation retrieves a train by ID.")]
        [SwaggerResponse(200, Description = "Successful response with the train object.")]
        [SwaggerResponse(404, Description = "Train not found.")]
        [SwaggerResponse(500, Description = "Internal server error.")]
        public async Task<IActionResult> GetEventById([FromRoute] int id )
        {
            var supply = await _trainService.GetTrainByIdAsync(id);

            if (supply == null)
            {
                return NotFound($"Train with ID {id} not found.");
            }

            return Ok(supply);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "This operation creates a new train.")]
        [SwaggerResponse(201, Description = "Train created successfully.")]
        [SwaggerResponse(400, Description = "Invalid input.")]
        [SwaggerResponse(500, Description = "Internal server error.")]
        public async Task<IActionResult> CreateEvent([FromBody] TrainDto trainDto)
        {
            var createdSupply = await  _trainService.CreateTrainAsync(trainDto);
            return CreatedAtAction(nameof(GetEventById), new { id = createdSupply.Id }, createdSupply);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "This operation updates an existing trrain by ID.")]
        [SwaggerResponse(200, Description = "Train updated successfully.")]
        [SwaggerResponse(404, Description = "Train not found.")]
        [SwaggerResponse(400, Description = "Invalid input.")]
        [SwaggerResponse(500, Description = "Internal server error.")]
        public async Task<IActionResult> UpdateEvent([FromRoute] int id, [FromBody] TrainDto trainDto)
        {
            var updatedSupply = await _trainService.UpdateTrainAsync(id, trainDto);

            if (updatedSupply == null)
            {
                return NotFound($"Train with ID {id} not found.");
            }

            return Ok(updatedSupply);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "This operation deletes a train by ID.")]
        [SwaggerResponse(204, Description = "Train deleted successfully.")]
        [SwaggerResponse(404, Description = "Train not found.")]
        [SwaggerResponse(500, Description = "Internal server error.")]
        public async Task<string> DeleteEvent([FromRoute] int id)
        {
            return await _trainService.DeleteTrainAsync(id);
        }
        
        
        
        
        
        
}