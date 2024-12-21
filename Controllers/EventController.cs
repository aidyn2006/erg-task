using ERG_Task.DTOs;
using ERG_Task.Models;
using ERG_Task.Services.impl;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ERG_Task.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class EventController : Controller
{
    private readonly IEventService _eventService;
    
    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "This operation retrieves all events.")]
    [SwaggerResponse(200, Description = "Successful response with a list of events.")]
    [SwaggerResponse(204, Description = "No content - no events found.")]
    [SwaggerResponse(500, Description = "Internal server error.")]
    public async Task<IActionResult> GetAll([FromQuery] int? year,[FromQuery] int? status, 
        [FromQuery] DateTime? dateStart,[FromQuery] DateTime? dateCreate)
    {
        var supplies = await _eventService.GetEventsAsync(year, status, dateStart, dateCreate);

        if (supplies == null || !supplies.Any())
        {
            return NoContent();
        }
        return Ok(supplies);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "This operation retrieves a event by ID.")]
    [SwaggerResponse(200, Description = "Successful response with the event object.")]
    [SwaggerResponse(404, Description = "Event not found.")]
    [SwaggerResponse(500, Description = "Internal server error.")]
    public async Task<IActionResult> GetEventById([FromRoute] int id)
    {
        var supply = await _eventService.GetEventByIdAsync(id);

        if (supply == null)
        {
            return NotFound($"Event with ID {id} not found.");
        }

        return Ok(supply);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "This operation creates a new events.")]
    [SwaggerResponse(201, Description = "event created successfully.")]
    [SwaggerResponse(400, Description = "Invalid input.")]
    [SwaggerResponse(500, Description = "Internal server error.")]
    public async Task<IActionResult> CreateEvent([FromBody] EventDto eventDto)
    {
        var createdSupply = await _eventService.CreateEventAsync(eventDto);
        return CreatedAtAction(nameof(GetEventById), new { id = createdSupply.Id }, createdSupply);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "This operation updates an existing event by ID.")]
    [SwaggerResponse(200, Description = "Event updated successfully.")]
    [SwaggerResponse(404, Description = "Event not found.")]
    [SwaggerResponse(400, Description = "Invalid input.")]
    [SwaggerResponse(500, Description = "Internal server error.")]
    public async Task<IActionResult> UpdateEvent([FromRoute] int id, [FromBody] EventDto eventDto)
    {
        var updatedSupply = await _eventService.UpdateEventAsync(id, eventDto);

        if (updatedSupply == null)
        {
            return NotFound($"Event with ID {id} not found.");
        }

        return Ok(updatedSupply);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "This operation deletes a event by ID.")]
    [SwaggerResponse(204, Description = "Events deleted successfully.")]
    [SwaggerResponse(404, Description = "Event not found.")]
    [SwaggerResponse(500, Description = "Internal server error.")]
    public async Task<string> DeleteEvent([FromRoute] int id)
    {
        return await _eventService.DeleteEventAsync(id);
    }
    
}